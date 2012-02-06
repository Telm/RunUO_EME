using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Engines.PartySystem;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Server.Mobiles;

namespace Server.Gumps
{
    public class WrodzoneGump : Gump
    {
        private static Mobile m_Player, m_Leader;
        public const double racialBonus = 5.0;


        private static int[][] SkilleZablokowane = new int[][]{
            //pierwsze 4 liczby podaja skille zablokowane na eme, kolejne liczby to sa skille osobliwe dla danej rasy
			new int[]{19,32,49,51},
			new int[]{19,32,49,51},
			new int[]{19,32,49,51,9,33,8,24},        //Black Numenorean
			new int[]{19,32,49,51},        //Dunland
			new int[]{19,32,49,51,9,25,23,0},        //East
			new int[]{19,32,49,51,33,28,24,23},        //Sin
			new int[]{19,32,49,51,33,28,24,30},        //Nol
			new int[]{19,32,49,51,25,30,22,47},        //Gon
			new int[]{19,32,49,51,33,28,23,11},        //Dun
			new int[]{19,32,49,51,0,25,30,23},        //Hob
			new int[]{19,32,49,51,30,25,23,28},        //Kha
			new int[]{19,32,49,51,9,25,45,23},        //Cor
			new int[]{19,32,49,51,25,30,33,23},        //Roh
			new int[]{19,32,49,51},        //Bree	
			new int[]{19,32,49,51},
			new int[]{19,32,49,51},
			new int[]{19,32,49,51,25,30,22,23},  //human
		};
        private bool SkillZablokowany(int race, int j, Mobile from)
        {
            foreach (int i in SkilleZablokowane[race])
            {
                //from.SendAsciiMessage("foreach {0}", i);
                if (i == j)
                {
                    //from.SendAsciiMessage("porownuje skill to skilli {0} zablokowanych danej rasy {1}",i, j);
                    return true;
                }           
                //return false;
            }
            return false; // takiego skilla nie ma, to jest po prostu inne poazanie "false" ;)
        }
        private int SzukaRasy(Mobile from)
        {
            for (int i = 0; i <= Race.AllRaces.Count; i++ )
            {
                //m_Player.SendAsciiMessage("foreach {0}", i);

                if (Race.Races[i] == from.Race)
                {
                    //m_Player.SendAsciiMessage("porownuje skill to skilli {0} zablokowanych danej rasy {1}", i, j);
                    return i;
                }
                //return false;
            }
            return 1; // to jest rasa elfow, wiec jak nie znajdzie lasy playera, to bedzie traktowany w gumpie jak elf;)
        }
        public WrodzoneGump(Mobile player, Mobile player2)
            : base(0, 0)
        {
            m_Player = player;
            if (m_Player == player2)
            {

                int race = m_Player.Race.RaceID;
                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);
                AddBackground(40, 50, 650, 300, 9400);
                AddLabel(65, 55, 0, @"Wybierz 3 zdolnosci wrodzone wpisujac wartosc w miejsce '-' (lacznie 100%) i zatwierdz:");
                AddButton(650, 55, 11400, 11402, 1, GumpButtonType.Reply, 0);
                //Pokolei lecimy przez wszystkie skille i dodajemy dla kazdego button i label
                for (int i = 0; i < 51; i += 4)
                {
                    for (int n = 0; n < 4; n++)
                    {
                        if ( SkillZablokowany(race, i+n, m_Player) == true)
                        {
                                AddLabel(65 + n * 150, 75 + i * 5, 133, (i + n) + " " + m_Player.Skills[i + n].Name);
                                continue;                   
                        }
                        AddTextEntry(45 + n * 150, 75 + i * 5, 200, 180, 100, i + n, @"-");
                        AddLabel(65 + n * 150, 75 + i * 5, 0, (i + n) + " " + m_Player.Skills[i + n].Name);
                    }
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Player == null || m_Player == null)
                return;
            //Crash Prevention
            Mobile pmob = sender.Mobile;
            int race = pmob.Race.RaceID;
            Dictionary<string, int> BaseSkill = new Dictionary<string, int>();
            int n = 0;
            int t = 0;
            for (int i = 0; i < 52; i++)
            {

                n++;
                string text = "-";
                if (SkillZablokowany(race, i, pmob) == true)
                {
                    //pmob.SendAsciiMessage("przeciw crashowi");
                    m_Player.Skills[i].Cap = 0;
                    continue;
                }
                text = info.GetTextEntry(i).Text;
                if(BaseSkill.Count<3)
                {
                    if (text == "-")
                    {
                    }
                    else
                    {
                        try
                        {
                            t = t + Convert.ToInt32(text);
                            BaseSkill.Add(pmob.Skills[i].Name, Convert.ToInt32(text));
                            if (Convert.ToInt32(text) > 50)
                            {
                                pmob.SendAsciiMessage("maksymalna wartosc jednego skilla to 50%");
                                BaseSkill.Clear();

                            }
                        }
                        catch (OverflowException)
                        {
                            pmob.SendAsciiMessage("{0} is outside the range of the Int32 type.", text);
                            BaseSkill.Clear();
                        }
                        catch (FormatException)
                        {
                            pmob.SendAsciiMessage("Zly format, tylko cyfry sa akceptowane");
                            BaseSkill.Clear();
                        }


                    }

                }
                else
                {
                    if (t > 100 && n == 51)
                    {
                        pmob.SendAsciiMessage("Suma nie moze byc wieksza niz 100");
                        BaseSkill.Clear();
                        //m_Player.SendGump(new WrodzoneGump(m_Player, m_Player));
                    }
                    else if (t < 100 && n == 51)
                    {
                        pmob.SendAsciiMessage("Suma nie moze byc mniejsza niz 100");
                        BaseSkill.Clear();
                        //m_Player.SendGump(new WrodzoneGump(m_Player, m_Player));
                    }
                }

            }
            if (BaseSkill.Count < 3)
            {
                pmob.SendAsciiMessage("wybrano za malo skilli");
                int i = 1;
                pmob.SendGump(new WrodzoneGump(pmob, pmob));
            }
            else
            {
                for (int j = 0; j < 52; j++)
                {
                    int value = 0;
                    //pmob.SendAsciiMessage("SkillCap dla wszystkich skilli ma wartosc : {0}", pmob.Skills[j].Cap);
                    if (BaseSkill.TryGetValue(pmob.Skills[j].Name, out value))
                    {
                        pmob.Skills[j].Base = value;
                        //pmob.Skills[j].Cap = 100;
                        AddSkillItems(pmob.Skills[j].Name, pmob);
                        //pmob.SendAsciiMessage("Dla wybranych skilli SkillCap ma wartosc : {0}", pmob.Skills[j].Cap);
                    }
                    else
                    {

                    }
                }
                //pmob.SendAsciiMessage("SkillsCap ma wartosc : {0}", pmob.Skills.Cap);
                pmob.SendGump(new MiastoStartoweGump(pmob, pmob));

            }


// tworzenie itemkow startowych
        }
        private static void EquipItem(Item item)
        {
            EquipItem(item, false);
        }

        private static void EquipItem(Item item, bool mustEquip)
        {
            if (!Core.AOS)
                item.LootType = LootType.Newbied;

            if (m_Player != null && m_Player.EquipItem(item))
                return;

            Container pack = m_Player.Backpack;

            if (!mustEquip && pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        private static void PackItem(Item item)
        {
            if (!Core.AOS)
                item.LootType = LootType.Newbied;

            Container pack = m_Player.Backpack;

            if (pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        private static void PackInstrument()
        {
            switch (Utility.Random(6))
            {
                case 0: PackItem(new Drums()); break;
                case 1: PackItem(new Harp()); break;
                case 2: PackItem(new LapHarp()); break;
                case 3: PackItem(new Lute()); break;
                case 4: PackItem(new Tambourine()); break;
                case 5: PackItem(new TambourineTassel()); break;
            }
        }

        private static void PackScroll(int circle)
        {
            switch (Utility.Random(8) * (circle + 1))
            {
                case 0: PackItem(new ClumsyScroll()); break;
                case 1: PackItem(new CreateFoodScroll()); break;
                case 2: PackItem(new FeeblemindScroll()); break;
                case 3: PackItem(new HealScroll()); break;
                case 4: PackItem(new MagicArrowScroll()); break;
                case 5: PackItem(new NightSightScroll()); break;
                case 6: PackItem(new ReactiveArmorScroll()); break;
                case 7: PackItem(new WeakenScroll()); break;
                case 8: PackItem(new AgilityScroll()); break;
                case 9: PackItem(new CunningScroll()); break;
                case 10: PackItem(new CureScroll()); break;
                case 11: PackItem(new HarmScroll()); break;
                case 12: PackItem(new MagicTrapScroll()); break;
                case 13: PackItem(new MagicUnTrapScroll()); break;
                case 14: PackItem(new ProtectionScroll()); break;
                case 15: PackItem(new StrengthScroll()); break;
                case 16: PackItem(new BlessScroll()); break;
                case 17: PackItem(new FireballScroll()); break;
                case 18: PackItem(new MagicLockScroll()); break;
                case 19: PackItem(new PoisonScroll()); break;
                case 20: PackItem(new TelekinisisScroll()); break;
                case 21: PackItem(new TeleportScroll()); break;
                case 22: PackItem(new UnlockScroll()); break;
                case 23: PackItem(new WallOfStoneScroll()); break;
            }
        }

        private static Item NecroHue(Item item)
        {
            item.Hue = 0x2C3;

            return item;
        }

        private static void AddSkillItems(string skillname, Mobile m)
        {
            bool elf = (m.Race == Race.Elf);

            switch (skillname)
            {
                case "Alchemy":
                    {
                        PackItem(new Bottle(4));
                        PackItem(new MortarPestle());

                        int hue = Utility.RandomPinkHue();

                        if (elf)
                        {
                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue));
                            else
                                EquipItem(new MaleElvenRobe(hue));
                        }
                        else
                        {
                            EquipItem(new Robe(Utility.RandomPinkHue()));
                        }
                        break;
                    }
                case "Anatomy":
                    {
                        PackItem(new Bandage(3));

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                        {
                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue));
                            else
                                EquipItem(new MaleElvenRobe(hue));
                        }
                        else
                        {
                            EquipItem(new Robe(Utility.RandomPinkHue()));
                        }
                        break;
                    }
                case "Animal Lore":
                    {


                        int hue = Utility.RandomBlueHue();

                        if (elf)
                        {
                            EquipItem(new WildStaff());

                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(hue));
                            else
                                EquipItem(new MaleElvenRobe(hue));
                        }
                        else
                        {
                            EquipItem(new ShepherdsCrook());
                            EquipItem(new Robe(hue));
                        }
                        break;
                    }
                case "Archery":
                    {
                        PackItem(new Arrow(25));

                        if (elf)
                            EquipItem(new ElvenCompositeLongbow());
                        else
                            EquipItem(new Bow());

                        break;
                    }
                case "Arms Lore":
                    {
                        if (elf)
                        {
                            switch (Utility.Random(3))
                            {
                                case 0: EquipItem(new Leafblade()); break;
                                case 1: EquipItem(new RuneBlade()); break;
                                case 2: EquipItem(new DiamondMace()); break;
                            }
                        }
                        else
                        {
                            switch (Utility.Random(3))
                            {
                                case 0: EquipItem(new Kryss()); break;
                                case 1: EquipItem(new Katana()); break;
                                case 2: EquipItem(new Club()); break;
                            }
                        }

                        break;
                    }
                case "Begging":
                    {
                        if (elf)
                            EquipItem(new WildStaff());
                        else
                            EquipItem(new GnarledStaff());
                        break;
                    }
                case "Blacksmithy":
                    {
                        PackItem(new Tongs());
                        PackItem(new Pickaxe());
                        PackItem(new Pickaxe());
                        PackItem(new IronIngot(50));
                        EquipItem(new HalfApron(Utility.RandomYellowHue()));
                        break;
                    }
                case "Bushido":
                    {
                        EquipItem(new Hakama());
                        /* EquipItem( new Kasa() ); */
                        EquipItem(new BookOfBushido());
                        break;
                    }
                case "Bowcraft/Fletching":
                    {
                        PackItem(new Board(14));
                        PackItem(new Feather(5));
                        PackItem(new Shaft(5));
                        break;
                    }
                case "Camping":
                    {
                        PackItem(new Bedroll());
                        PackItem(new Kindling(5));
                        break;
                    }
                case "Carpentry":
                    {
                        PackItem(new Board(10));
                        PackItem(new Saw());
                        EquipItem(new HalfApron(Utility.RandomYellowHue()));
                        break;
                    }
                case "Cartography":
                    {
                        PackItem(new BlankMap());
                        PackItem(new BlankMap());
                        PackItem(new BlankMap());
                        PackItem(new BlankMap());
                        PackItem(new Sextant());
                        break;
                    }
                case "Cooking":
                    {
                        PackItem(new Kindling(2));
                        PackItem(new RawLambLeg());
                        PackItem(new RawChickenLeg());
                        PackItem(new RawFishSteak());
                        PackItem(new SackFlour());
                        PackItem(new Pitcher(BeverageType.Water));
                        break;
                    }
                case "Chivalry":
                    {
                        if (Core.ML)
                            PackItem(new BookOfChivalry((ulong)0x3FF));

                        break;
                    }
                case "Detecting Hidden":
                    {
                        EquipItem(new Cloak(0x455));
                        break;
                    }
                case "Discordance":
                    {
                        PackInstrument();
                        break;
                    }
                case "Fencing":
                    {
                        if (elf)
                            EquipItem(new Leafblade());
                        else
                            EquipItem(new Kryss());

                        break;
                    }
                case "Fishing":
                    {
                        EquipItem(new FishingPole());

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                        {
                            Item i = new Circlet();
                            i.Hue = hue;
                            EquipItem(i);
                        }
                        else
                        {
                            EquipItem(new FloppyHat(Utility.RandomYellowHue()));
                        }

                        break;
                    }
                case "Healing":
                    {
                        PackItem(new Bandage(50));
                        PackItem(new Scissors());
                        break;
                    }
                case "Herding":
                    {
                        if (elf)
                            EquipItem(new WildStaff());
                        else
                            EquipItem(new ShepherdsCrook());

                        break;
                    }
                case "Hiding":
                    {
                        EquipItem(new Cloak(0x455));
                        break;
                    }
                case "Inscription":
                    {
                        PackItem(new BlankScroll(2));
                        PackItem(new BlueBook());
                        break;
                    }
                case "Item Identification":
                    {
                        if (elf)
                            EquipItem(new WildStaff());
                        else
                            EquipItem(new GnarledStaff());
                        break;
                    }
                case "Lockpicking":
                    {
                        PackItem(new Lockpick(20));
                        break;
                    }
                case "Lumberjacking":
                    {
                        EquipItem(new Hatchet());
                        break;
                    }
                case "Mace Fighting":
                    {
                        if (elf)
                            EquipItem(new DiamondMace());
                        else
                            EquipItem(new Club());

                        break;
                    }
                case "Magery":
                    {
                        BagOfReagents regs = new BagOfReagents(30);

                        if (!Core.AOS)
                        {
                            foreach (Item item in regs.Items)
                                item.LootType = LootType.Newbied;
                        }

                        PackItem(regs);

                        regs.LootType = LootType.Regular;

                        PackScroll(0);
                        PackScroll(1);
                        PackScroll(2);

                        Spellbook book = new Spellbook((ulong)0x382A8C38);

                        EquipItem(book);

                        book.LootType = LootType.Blessed;

                        if (elf)
                        {
                            EquipItem(new Circlet());

                            if (m.Female)
                                EquipItem(new FemaleElvenRobe(Utility.RandomBlueHue()));
                            else
                                EquipItem(new MaleElvenRobe(Utility.RandomBlueHue()));
                        }
                        else
                        {
                            EquipItem(new WizardsHat());
                            EquipItem(new Robe(Utility.RandomBlueHue()));
                        }

                        break;
                    }
                case "Mining":
                    {
                        PackItem(new Pickaxe());
                        break;
                    }
                case "Musicianship":
                    {
                        PackInstrument();
                        break;
                    }
                case "Necromancy":
                    {
                        if (Core.ML)
                        {
                            Container regs = new BagOfNecroReagents(50);

                            PackItem(regs);

                            regs.LootType = LootType.Regular;
                        }

                        break;
                    }
                case "Ninjitsu":
                    {
                        EquipItem(new Hakama(0x2C3));	//Only ninjas get the hued one.
                        /* EquipItem( new Kasa() ); */
                        EquipItem(new BookOfNinjitsu());
                        break;
                    }
                case "Parrying":
                    {
                        EquipItem(new WoodenShield());
                        break;
                    }
                case "Peacemaking":
                    {
                        PackInstrument();
                        break;
                    }
                case "Poisoning":
                    {
                        PackItem(new LesserPoisonPotion());
                        PackItem(new LesserPoisonPotion());
                        break;
                    }
                case "Provocation":
                    {
                        PackInstrument();
                        break;
                    }
                case "Snooping":
                    {
                        PackItem(new Lockpick(20));
                        break;
                    }
                case "SpiritSpeak":
                    {
                        EquipItem(new Cloak(0x455));
                        break;
                    }
                case "Stealing":
                    {
                        PackItem(new Lockpick(20));
                        break;
                    }
                case "Swordsmanship":
                    {
                        if (elf)
                            EquipItem(new RuneBlade());
                        else
                            EquipItem(new Katana());

                        break;
                    }
                case "Tactics":
                    {
                        if (elf)
                            EquipItem(new RuneBlade());
                        else
                            EquipItem(new Katana());

                        break;
                    }
                case "Tailoring":
                    {
                        PackItem(new BoltOfCloth());
                        PackItem(new SewingKit());
                        break;
                    }
                case "Tracking":
                    {
                        if (m_Player != null)
                        {
                            Item shoes = m_Player.FindItemOnLayer(Layer.Shoes);

                            if (shoes != null)
                                shoes.Delete();
                        }

                        int hue = Utility.RandomYellowHue();

                        if (elf)
                            EquipItem(new ElvenBoots(hue));
                        else
                            EquipItem(new Boots(hue));

                        EquipItem(new SkinningKnife());
                        break;
                    }
                case "Veterinary":
                    {
                        PackItem(new Bandage(5));
                        PackItem(new Scissors());
                        break;
                    }
                case "Wrestling":
                    {
                        if (elf)
                            EquipItem(new LeafGloves());
                        else
                            EquipItem(new LeatherGloves());

                        break;
                    }
                case "Tinkering":
                    {
                        PackItem(new TinkerTools());

                        break;
                    }
            }
        }
    }
}