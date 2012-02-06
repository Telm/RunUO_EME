//////////////////////////////////////////////////////////////////////
//Item Picker Gump
//Scripted By: Blurry Dude
//Notes:
//Just use the command [item and you'll figure the rest out.
//Not the most amazing script ever written or anything, but not bad for one of my first way back.
//////////////////////////////////////////////////////////////////////
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
    public class ItemPicker : Gump
    {
        Mobile caller;

        public static void Initialize()
        {
#if(RunUo2_0)
            CommandSystem.Register("item", AccessLevel.GameMaster, new CommandEventHandler(item_OnCommand));
#else
            Register("item", AccessLevel.GameMaster, new CommandEventHandler(item_OnCommand));
#endif
        }

        [Usage("item")]
        [Description("Makes a call to your custom gump.")]
        public static void item_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from.HasGump(typeof(ItemPicker)))
                from.CloseGump(typeof(ItemPicker));
            from.SendGump(new ItemPicker(1));
        }

        public ItemPicker(int firstItem) : base( 0, 0 )
        {
            string item = firstItem.ToString();
            this.Closable=true;
            this.Disposable=true;
            this.Dragable=true;
            AddPage(0);
            AddBackground(0, 0, 920, 650, 5100);
            AddRadio(154, 5, 209, 208, false, 0);
            AddLabel(178, 5, 0, @"Multi");
            AddRadio(222, 5, 209, 208, false, 1);
            AddLabel(245, 5, 0, @"Add");
            AddRadio(276, 5, 209, 208, true, 2);
            AddLabel(299, 5, 0, @"Tile");
        //    AddTextEntry( int x, int y, int width, int height, int hue, int entryID, string initialText )
        //    AddTextEntry(700, 5,  200, 20, 0, 0, item);

            AddButton(885, 4, 1151, 1152, 0, GumpButtonType.Reply, 0);

            AddButton(330, 4, 11400, 11402, 20001, GumpButtonType.Reply, 0);
            AddLabel(345, 5, 0, @"1");
            AddButton(360, 4, 11400, 11402, 20002, GumpButtonType.Reply, 0);
            AddLabel(375, 5, 0, @"2");
            AddButton(390, 4, 11400, 11402, 20003, GumpButtonType.Reply, 0);
            AddLabel(405, 5, 0, @"3");
            AddButton(420, 4, 11400, 11402, 20004, GumpButtonType.Reply, 0);
            AddLabel(435, 5, 0, @"4");
            AddButton(450, 4, 11400, 11402, 20005, GumpButtonType.Reply, 0);
            AddLabel(465, 5, 0, @"5");
            AddButton(480, 4, 11400, 11402, 20006, GumpButtonType.Reply, 0);
            AddLabel(495, 5, 0, @"6");
            AddButton(510, 4, 11400, 11402, 20007, GumpButtonType.Reply, 0);
            AddLabel(525, 5, 0, @"7");
            AddButton(540, 4, 11400, 11402, 20008, GumpButtonType.Reply, 0);
            AddLabel(555, 5, 0, @"8");
            AddButton(570, 4, 11400, 11402, 20009, GumpButtonType.Reply, 0);
            AddLabel(585, 5, 0, @"9");
            AddButton(600, 4, 11400, 11402, 20010, GumpButtonType.Reply, 0);
            AddLabel(615, 5, 0, @"10");
            AddButton(630, 4, 11400, 11402, 20011, GumpButtonType.Reply, 0);
            AddLabel(645, 5, 0, @"11");
            AddButton(660, 4, 11400, 11402, 20012, GumpButtonType.Reply, 0);
            AddLabel(675, 5, 0, @"12");
            AddButton(690, 4, 11400, 11402, 20013, GumpButtonType.Reply, 0);
            AddLabel(705, 5, 0, @"13");
            AddButton(720, 4, 11400, 11402, 20014, GumpButtonType.Reply, 0);
            AddLabel(735, 5, 0, @"14");
            AddButton(750, 4, 11400, 11402, 20015, GumpButtonType.Reply, 0);
            AddLabel(765, 5, 0, @"15");
            AddButton(780, 4, 11400, 11402, 20016, GumpButtonType.Reply, 0);
            AddLabel(795, 5, 0, @"16");
            AddButton(810, 4, 11400, 11402, 20017, GumpButtonType.Reply, 0);
            AddLabel(825, 5, 0, @"17");

            int itemID = firstItem;
            int itemCount = 1;
            int colCount = 1;
            int rowCount = 1;
            int prevPage = 0;
            int nextPage = 2;
            int curPage = 1;
            int ButtonX = 22;
            int ButtonY = 105;
            int ItemX = 14;
            int ItemY = 40;

            while(itemCount <= 1000)
            {
                AddPage(curPage);
                AddButton(91, 7, 2471, 2470, 0, GumpButtonType.Page, nextPage);
                AddButton(7, 7, 2468, 2467, 0, GumpButtonType.Page, prevPage);
                while(rowCount <= 6)
                {
                    while(colCount <= 18)
                    {
                        AddItem(ItemX, ItemY, itemID);
                        AddButton(ButtonX, ButtonY, 9026, 9027, itemID, GumpButtonType.Reply, 0);

                        colCount++;
                        itemID++;
                        ItemX += 50;
                        itemCount++;
                        ButtonX += 50;
                    }
                    ItemX = 14;
                    ButtonX = 22;
                    rowCount++;
                    colCount = 1;
                    ItemY += 100;
                    ButtonY += 100;
                }
                ItemY = 40;
                ButtonY = 105;
                curPage++;
                prevPage++;
                nextPage++;
                rowCount = 1;
            }

        }
  
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            int item = info.ButtonID;

            switch(info.ButtonID)
            {
                case 0:
                { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); break; }
                case 20001: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(1)); break; }
                case 20002: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(1000)); break; }
                case 20003: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(2000)); break; }
                case 20004: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(3000)); break; }
                case 20005: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(4000)); break; }
                case 20006: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(5000)); break; }
                case 20007: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(6000)); break; }
                case 20008: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(7000)); break; }
                case 20009: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(8000)); break; }
                case 20010: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(9000)); break; }
                case 20011: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(10000)); break; }
                case 20012: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(11000)); break; }
                case 20013: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(12000)); break; }
                case 20014: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(13000)); break; }
                case 20015: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(14000)); break; }
                case 20016: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(15000)); break; }
                case 20017: { if (from.HasGump(typeof(ItemPicker))) from.CloseGump(typeof(ItemPicker)); from.SendGump(new ItemPicker(15382)); break; }
                default:
                {
                    string com1 = "";
                    string com2 = " set movable false";
 
                    if(info.IsSwitched(0) == true)
                    { com1 = ".m add item "; }
                    else if(info.IsSwitched(1) == true)
                    { com1 = ".add item "; }
                    else if(info.IsSwitched(2) == true)
                    { com1 = ".tile item "; }
                    else
                    {
                        com1 = ".m set itemid ";
                    }

                    CommandSystem.Handle( from, String.Format( com1 + item + com2 ) );
                    from.SendGump(new ItemPicker(item));
                break;
                }
            }
        }
    }
}