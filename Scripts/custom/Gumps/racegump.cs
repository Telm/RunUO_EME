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
    public class RaceGump : Gump
    {
        private Mobile m_Player, m_Leader;
		public const double racialBonus = 5.0;
		
		/* wyremowane bo nie ma skilli rasowych
         * private static int[][] SkilleRasowe = new int[][]{
			new int[]{},
			new int[]{},
			new int[]{0, 34},	//Black Numenorean
			new int[]{2, 20},	//Dunland
			new int[]{34, 38},	//East
			new int[]{8, 34},	//Sin
			new int[]{4, 23},	//Nol
			new int[]{4, 37},	//Gon
			new int[]{38, 21},	//Dun
			new int[]{13, 18},	//Hob
			new int[]{4, 45},	//Kha
			new int[]{12, 34},	//Cor
			new int[]{2, 35},	//Roh
			new int[]{11, 34},	//Bree
			//new int[]{18, 44}	//Esg
		};*/

		/* Wyremowane, bo na razie nie ma skilli zablokowanych
		private static int[][] SkilleZablokowane = new int[][]{
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{6,9,15},	//Black Numenorean
			new int[]{23,25,46},	//Dunland
			new int[]{23,25,46},	//East
			new int[]{6,24,28,33},	//Sin
			new int[]{6,28,30,32,33},	//Nol
			new int[]{23,25,46},	//Gon
			new int[]{6,28,33},	//Dun
			new int[]{0,2,4,5,7,23,35,46},	//Hob
			new int[]{0,2,6,20,23,24,25,28,32,33,35,46},	//Kha
			new int[]{23,25,46,30,32,20},	//Cor
			new int[]{0,23,25,46,30},	//Roh
			new int[]{23,25,46}	//Bree
		};	*/
        private static int[][] SkilleRasowe = new int[][]{
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
            			new int[]{},
			new int[]{},
			new int[]{},
			//new int[]{}
		};

		private static int[][] SkilleZablokowane = new int[][]{
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
			new int[]{},
            			new int[]{},
			new int[]{},
			new int[]{},
			//new int[]{}
		};

        private static int[][] StatyRasowe = new int[][]{
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},	//Black Numenorean
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
	        			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{0,0,0},
			//new int[]{1,2,3}	//Esg	
		};

/*		

		private static int[][] StatyRasowe = new int[][]{
			new int[]{0,0,0},
			new int[]{0,0,0},
			new int[]{1,1,5},	//Black Numenorean
			new int[]{1,2,3},	//Dunland
			new int[]{1,2,3},	//East
			new int[]{1,2,3},	//Sin
			new int[]{1,2,3},	//Nol
			new int[]{1,2,3},	//Gon
			new int[]{1,2,3},	//Dun
			new int[]{1,2,3},	//Hob
			new int[]{1,2,3},	//Kha
			new int[]{1,2,3},	//Cor
			new int[]{1,2,3},	//Roh
			new int[]{1,2,3},	//Bree			
			//new int[]{1,2,3}	//Esg			
		};				
		*/
		private static string[] PowitanieRasowe = new string[]{
			"jakie powitanie rasowe",
			"nieprawidlowa rasa",
			"As salam alaykum!",	//BN
			"Witojcie panocku!",	//Dnl
			"<jakies powitanie rasowe>",	//Eas
			"Mae govannen!",		//Sin
			"Aiya!",				//Nol
			"<jakies powitanie rasowe>",	//Gon
			"<jakies powitanie rasowe>",	//Dun
			"Witaj! Masz mo¿e ochote na powid³a œliwkowe?",	//Hob
			"Vem!",	//Kha
			"Arrr me maty!",	//Cor
			"<jakies powitanie rasowe>",	//Roh
			"<jakies powitanie rasowe>",	//Bre
			"<jakies powitanie rasowe>"	,	//Esg
            "<jakies powitanie rasowe>"	,	//Esg
            "<jakies powitanie rasowe>"	,	//Humek

		};
		
        public RaceGump(Mobile player, Mobile player2)
            : base(0, 0)
        {
            m_Player = player;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

			ZerujSkille();
						
            AddPage(0);

            AddBackground(50, 50, 180, 350, 9400);

            AddLabel(55, 55, 0, @"Wybierz rase");
			
			AddButton(55, 75, 11400, 11402, 2, GumpButtonType.Reply, 0);
            AddButton(55, 95, 11400, 11402, 16, GumpButtonType.Reply, 0);
            AddButton(55, 115, 11400, 11402, 4, GumpButtonType.Reply, 0);
            AddButton(55, 135, 11400, 11402, 5, GumpButtonType.Reply, 0);
            AddButton(55, 155, 11400, 11402, 6, GumpButtonType.Reply, 0);
            AddButton(55, 175, 11400, 11402, 7, GumpButtonType.Reply, 0);
            AddButton(55, 195, 11400, 11402, 8, GumpButtonType.Reply, 0);
            AddButton(55, 215, 11400, 11402, 9, GumpButtonType.Reply, 0);
            AddButton(55, 235, 11400, 11402, 10, GumpButtonType.Reply, 0);
            AddButton(55, 255, 11400, 11402, 11, GumpButtonType.Reply, 0);
            AddButton(55, 275, 11400, 11402, 12, GumpButtonType.Reply, 0);
            //AddButton(55, 295, 11400, 11402, 0, GumpButtonType.Reply, 0);
            //AddButton(55, 315, 11400, 11402, 14, GumpButtonType.Reply, 0);
            		
			AddLabel(75, 75, 0, @"Czarny Numenorejczyk");		
			//AddLabel(75, 95, 0, @"Dunlandczyk");		
            AddLabel(75, 95, 0, @"Czlowiek");		
			AddLabel(75, 115,0, @"Easterling");		
			AddLabel(75, 135, 0, @"Sindar");
			AddLabel(75, 155, 0, @"Noldor");	
			AddLabel(75, 175, 0, @"Gondorczyk");		
			AddLabel(75, 195, 0, @"Dunedain");			
			AddLabel(75, 215, 0, @"Hobbit");			
			AddLabel(75, 235, 0, @"Khazad");			
			AddLabel(75, 255, 0, @"Korsarz");			
			AddLabel(75, 275, 0, @"Rohirrim");			
			//AddLabel(75, 295, 0, @"Czlowiek z Bree");
            //AddLabel(75, 295, 0, @"Czlowiek");	
			//AddLabel(75, 315, 0, @"Czlowiek z Esgaroth");			

        }
		
		public void ZerujSkille(){
			for (int i = 0; i < 53; i++){
				m_Player.Skills[i].Base = 0;	
				//m_Player.Skills[i].Cap = 40;
				//m_Player.RemoveSkillMod( new DefaultSkillMod( (SkillName)i, true, racialBonus ));
			}
		}

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Player == null || m_Player == null)
                return;
            //Crash Prevention
            Mobile pmob = sender.Mobile;
			//Ustawiamy skille rasowe
			/*foreach (int Skill in SkilleRasowe[info.ButtonID]){
                pmob.SendAsciiMessage("Skill rasowy: " + Skill);
                pmob.Skills[Skill].Base = 25;
                pmob.AddSkillMod(new DefaultSkillMod((SkillName)Skill, true, racialBonus));
                pmob.Skills[Skill].Cap = 40;				
			} 
			
			//Ustawiamy skille zablokowane
			foreach (int Skill in SkilleZablokowane[info.ButtonID]){
                pmob.SendAsciiMessage("Skill zablokowany: " + Skill);
                pmob.Skills[Skill].Base = 0;
                pmob.Skills[Skill].Cap = 0;				
			} */			
			
			//Uwzgledniamy modyfikatory statow
            pmob.Str += StatyRasowe[info.ButtonID][0];
            pmob.Dex += StatyRasowe[info.ButtonID][1];
            pmob.Int += StatyRasowe[info.ButtonID][2];
			
			//Wysylamy wiadomosc powitalna
            pmob.SendAsciiMessage(PowitanieRasowe[info.ButtonID]);
			
			//Zapisujemy wybor rasy
            pmob.Race = Race.Races[info.ButtonID];
            pmob.SendAsciiMessage("rasa button: " + Race.Races[info.ButtonID]);
            pmob.SendAsciiMessage("rasa: " + m_Player.Race);

			//Wysylamy gumpa z wyborem skilli
            if (pmob.Race == Race.Races[0] || pmob.Race == Race.Races[1] )
                pmob.SendGump(new RaceGump(pmob, pmob));
			else{
                //string name = m_Player.Name;
                //string name = pmob.Name + " (" + pmob.Race.Name + ")";
                //m_Player.SendAsciiMessage("Real name: " + RealName + " show name: " + ShowName);
                //pmob.Name = name;
                pmob.SendGump(new WrodzoneGump(pmob, pmob));
				//m_Player.SendGump(new NameGump(m_Player, m_Player));
				}
        }
    }
}