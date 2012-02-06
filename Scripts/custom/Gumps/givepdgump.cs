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
using System.Threading;
using System.Data;
using System.Data.Odbc;
using Server.Engines.MyRunUO;


namespace Server.Gumps
{
    public class GivePDGump : Gump
    {
        private Mobile m_Player;
        private Mobile m_GM;
		public const double racialBonus = 5.0;
		private static DatabaseCommandQueue m_Command;
		
        public GivePDGump(Mobile player, Mobile gm)
            : base(0, 0)
        {
            m_Player = player;
			m_GM = gm;
			
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(50, 50, 550, 300, 9400);

            AddLabel(55, 55, 175, @"Konto:");
			AddLabel(95, 55, 175, m_Player.Account.Username);
            AddLabel(55, 75, 175, @"Nazwa postaci:");
			AddLabel(145, 75, 175, m_Player.Name);
            AddLabel(55, 95, 175, @"Suma PD:");
            AddLabel(55, 115, 175, @"Suma PD w tym cyklu:");
            AddLabel(55, 155, 175, @"Ilosc PD:");
			AddTextEntry(115, 155, 200, 180, 0, 0, @"0");	
			AddLabel(55, 175, 175, @"Reason:");
			AddTextEntry(105, 175, 200, 180, 0, 1, @"Bo tak");	
            AddButton(55, 195, 11400, 11402, 0, GumpButtonType.Reply, 0);	

			int ilosc = ((PlayerMobile)player).ListaPD.Count;

			if (ilosc > 1){
				int max = ilosc - 5;
				if (max < 0) max = 0;			
				ArrayList ListaPD = ((PlayerMobile)player).ListaPD;
				
				int y = 55;
				for (int i = ilosc - 1; i >= max; i--){
				//	if(i < 0) continue;
					object[] entry = ListaPD[i] as object[];
					AddLabel(350, y, 175, @"Ilosc PD:");
					AddLabel(350, y+20, 175, @"Od:");
					AddLabel(350, y+40, 175, @"Reason:");
					
					AddLabel(425, y, 175, Convert.ToString(entry[0]));
					AddLabel(425, y+20, 175, Convert.ToString(entry[1]));
					AddLabel(425, y+40, 175, Convert.ToString(entry[2]));				
					y += 70;
				}
			}
		}

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (m_Player == null || m_GM == null)
                return;
            //Crash Prevention
			TextRelay textentry = (TextRelay)info.GetTextEntry(0);
            int Amount = Convert.ToInt16(textentry.Text.Trim()); 
			
			textentry = (TextRelay)info.GetTextEntry(1);
            string Reason = textentry.Text.Trim();  
			
			string GM_name = m_GM.Account.Username;
			
			((PlayerMobile)m_Player).ListaPD.Add( new Object[3]{Amount, GM_name, Reason});
			((PlayerMobile)m_Player).PDcount += Amount;
			
			m_Player.SendAsciiMessage("Otrzymales " + Amount + "PD od " + GM_name + ". Opis: " + Reason + ". Aktualna ilosc PD: " + ((PlayerMobile)m_Player).PDcount);
			m_GM.SendAsciiMessage("Reason: " + Reason + ", from: " + GM_name + ", Amount: " + Amount);
			//Object[] PDEntry = new Object[2]{Amount, Reason};
		//	((PlayerMobile)m_Player).ListaPD.Add(PDEntry);
			foreach (Object[] entry in ((PlayerMobile)m_Player).ListaPD)
            {
				m_GM.SendAsciiMessage("amount: " + entry[0] + ", gm: " + entry[1] + ", reason: " + entry[2]);
            }			
			
			
		/*	try{
				m_Command = new DatabaseCommandQueue( "MyRunUO: Status database updated in {0:F1} seconds", "MyRunUO Status Database Thread" );
				m_Command.Enqueue( String.Format( "INSERT INTO test VALUES (1)" ) );
			}
			catch ( Exception e )
			{
				Console.WriteLine( "MyRunUO: Error updating status database" );
				Console.WriteLine( e );
			}*/
		
        }
    }
}