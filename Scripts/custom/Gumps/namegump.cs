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
    public class NameGump : Gump
    {
        private Mobile m_Player, m_Leader;
		public const double racialBonus = 5.0;
		
        public NameGump(Mobile player, Mobile player2)
            : base(0, 0)
        {
            m_Player = player;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(50, 50, 600, 300, 9400);

            AddLabel(55, 55, 175, @"Tutaj wpisz nazwe, ktora pojawiala sie bedzie");
			AddLabel(55, 75, 175, @"postaciom ktore Cie nie znaja");
			AddTextEntry(55, 90, 200, 180, 0, 0, m_Player.Name);
            AddLabel(55, 115, 175, @"Tutaj wpisz swoje prawdziwe imie");
			AddTextEntry(55, 145, 200, 180, 0, 1, @"Imie");	
            AddButton(55, 175, 11400, 11402, 0, GumpButtonType.Reply, 0);			
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (m_Player == null || m_Player == null)
                return;
            //Crash Prevention
			TextRelay textentry = (TextRelay)info.GetTextEntry(0);
            string RealName = textentry.Text.Trim();  
			
			textentry = (TextRelay)info.GetTextEntry(1);
            string ShowName = textentry.Text.Trim();  
			
			ShowName += " (" + m_Player.Race.Name + ")";
			m_Player.SendAsciiMessage("Real name: " + RealName + " show name: " + ShowName );
			m_Player.Name = ShowName;
			PlayerMobile m_PlayerMobile = m_Player as PlayerMobile;
			m_PlayerMobile.RealName = RealName;
        }
    }
}