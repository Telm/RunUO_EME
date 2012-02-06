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
    public class MiastoStartoweGump : Gump
    {
        private Mobile m_Player, m_Leader;
		public const double racialBonus = 5.0;

		private static string[] Miasta = new string[]{
			"null",
			"Bree",
			"Dale",
			"Dol Amroth",
			"Dunharrow",
			"Edoras",
			"Ered Engrin",
			"Ered Luin",
			"Esgaroth",
			"Forochel",
			"Helm's Deep",
			"Imladris",
			"Lothlorien",
			"Minas Tirith",
			"Mining Outpost",
			"Mithlond",
			"Moria",
			"Shire",
			"Shrel Kain",
			"Tharbad",
			"Umbar",
			"Wulf's Fort"
		};
		
		private static int[][] MiastaLoc = new int[][]{	//(xLoc, yLoc, Zloc, enabled)
			new int[] {0,0,0,0},
			new int[] {2223,1106,-80,1},	//1 - Bree
			new int[] {4085,523,-70,0},	//2 - Dale
			new int[] {3025,3641,-80,0},	//3 - Dol Amroth
			new int[] {3498,2792,-70,1},	//4 - Dunharrow
			new int[] {3217,2653,-40,1},	//5 - Edoras
			new int[] {4828,821,-50,0},	//6 - Ered Engrin
			new int[] {770,972,-45,1},	//7 - Ered Luin
			new int[] {4244,748,-75,1},	//8 - Esgaroth
			new int[] {1663,237,-80,0},	//9 - Forochel
			new int[] {3042,2631,-51,1},	//10- Helm's Deep
			new int[] {3075,1016,-60,1},	//11 - Imladris
			new int[] {3395,1767,-80,1},	//12 - Lothlorien
			new int[] {4167,3075,-96,1},	//13 - Minas Tirith
			new int[] {3909,3030,-70,1},	//14 - Mining Outpost
			new int[] {1212,1247,-80,1},	//15 - Mithlond
			new int[] {6112,341,-80,0},	//16 - Moria
			new int[] {1901,1170,-80,1},	//17 - Shire
			new int[] {5480,1632,-80,1},	//18 - Shrel Kain
			new int[] {2574,1797,-80,1},	//19 - Tharbad
			new int[] {2785,3946,-38,1},	//20 - Umbar
			new int[] {2913,2096,-70,1}	//21 - Wulf's Fort
		};		
		
		private static int[][] MiastaRasy = new int[][]{
			new int[]{0}, //Humek
			new int[]{0},
			new int[]{20},	//Black Numenorean
			new int[]{21},	//Dunland
			new int[]{18},	//East
			new int[]{11,12},	//Sin
			new int[]{11,12},	//Nol
			new int[]{13},	//Gon
			new int[]{1},	//Dun
			new int[]{17},	//Hob
			new int[]{6,7,16},	//Kha
			new int[]{20},	//Cor
			new int[]{5},	//Roh
			new int[]{0},	//bre
            new int[]{0},	
    		new int[]{0},	
			new int[]{1, 8, 21}	//Humek
		};		
	
        public MiastoStartoweGump(Mobile player, Mobile player2)
            : base(0, 0)
        {
            m_Player = player;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(50, 50, 300, 300, 9400);

            AddLabel(55, 55, 0, @"Wybierz miasto startowe");
			
			int i = 0;
			foreach (int Miasto in MiastaRasy[m_Player.Race.RaceID]){
				m_Player.SendAsciiMessage("Miasto " + Miasto + ": " + MiastaLoc[Miasto][3]);
				if (MiastaLoc[Miasto][3] == 1)
					AddButton(55, 75+i*20, 11400, 11402, Miasto, GumpButtonType.Reply, 0);
				AddLabel(75, 75+i*20, 0, Miasta[Miasto] );
				i++;
			}
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Player == null || m_Player == null)
                return;
            Mobile pmob = sender.Mobile;
            //Crash Prevention
            if (info.ButtonID == 0)
            {
                pmob.SendGump(new MiastoStartoweGump(pmob, pmob));
            }
            else
            {
                pmob.Map = Server.Map.Trammel;
                pmob.X = MiastaLoc[info.ButtonID][0];
                pmob.Y = MiastaLoc[info.ButtonID][1];
                pmob.Z = MiastaLoc[info.ButtonID][2];
            }
        }
    }
}