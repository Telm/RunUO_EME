using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using System.Collections;

namespace Server.Gumps
{
	public class MessageComposeGump : Gump
	{
        public MessageComposeGump()
            : base(0, 0)
		{
			Closable = true;
			Dragable = true;
			Resizable = false;

			AddBackground( 23, 15, 293, 463, 5100 );
			
            // Message
            AddLabel(54, 24, 0, "Wiadomosc");
            AddRadio(30, 25, 5052, 5050, true, 2); // Message
			AddAlphaRegion( 57, 49, 246, 73 );
			AddTextEntry(57, 49, 246, 73, 70, 5, ""); // Message

            // Web Url
            AddLabel(56, 133, 0, "Adres internetowy (np.link do newsa)");
            AddRadio(30, 134, 5052, 5050, false, 3);  // Web Url
			AddAlphaRegion( 57, 153, 246, 21 );
			AddTextEntry(57, 153, 246, 21, 3, 6, "http://"); // Web Url

            // Long Message
            AddLabel(58, 182, 0, "Dluzsza wiadomosc");
            AddRadio(30, 182, 5052, 5050, false, 4); // Long Message
			AddAlphaRegion( 57, 204, 246, 73 );
            AddLabel(42, 229, 999, "1");
			AddTextEntry(57, 204, 246, 73, 70, 7, ""); // Long Message
			AddAlphaRegion( 57, 294, 246, 73 );
            AddLabel(42, 318, 999, "2");
			AddTextEntry(57, 294, 246, 73, 70, 8, "");  // Long Message

            // Plus Web Url
            AddLabel(34, 381, 999, "Jesli chcesz wyslac wiadomosc i link na koncu");
            AddLabel(35, 398, 999, "wpisz adres tutaj.");
			AddAlphaRegion( 28, 419, 282, 25 );
			AddTextEntry(28, 419, 282, 25, 3, 9, "http://"); // Plus Web Url

			AddButton( 133, 451, 1147, 1149, 1, GumpButtonType.Reply, 0); // Okay
		}

        /*
         * 1 = Okay
         * 2 = Message Radio
         * 3 = Web Url Radio
         * 4 = Long Message Radio
         * 5 = Message Text
         * 6 = Web Url Text
         * 7 = Long Message Text
         * 8 = Long Message Text
         * 9 = Plus Web Url Text
         */

        public ArrayList BuildPlayerList()
        {
            ArrayList list = new ArrayList();

            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m;

                    if (pm.NetState != null)
                        list.Add(pm);
                }
            }

            return list;
        }

        public void SendMessageGumps(Mobile sender, int i, string msg, string url, ArrayList list)
        {
            bool hasurl = false;

            if (url != "nourl")
                hasurl = true;

            for (int ii = 0; ii < list.Count; ++ii)
            {
                PlayerMobile pm = (PlayerMobile)list[ii];

                pm.CloseGump(typeof(GlobalMessageGump));
                pm.SendGump(new GlobalMessageGump(sender.Name, msg, hasurl, url));
            }
            list.Clear();
        }

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

            ArrayList players = (ArrayList)BuildPlayerList();

            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.SendMessage("Zdecydowales nie wyslac wiadomosci.");
                        break;
                    }
                case 1:
                    {
                        bool plusurl = false;

                        TextRelay entryu = info.GetTextEntry(9);
                        string plus = (entryu == null ? "" : entryu.Text);

                        if (plus != "http://")
                            plusurl = true;

                        if (info.IsSwitched(2)) // Message
                        {
                            TextRelay entry = info.GetTextEntry(5);
                            string text = (entry == null ? "" : entry.Text);

                            if(plusurl)
                                SendMessageGumps(from, 1, text, plus, players);
                            else
                                SendMessageGumps(from, 1, text, "nourl", players);
                        }
                        else if (info.IsSwitched(3)) // Web Url
                        {
                            TextRelay entry = info.GetTextEntry(6);
                            string text = (entry == null ? "" : entry.Text);

                            string msg = "Mistrz gry zasugerowal ci odwiedzenie tego linku,kliknij w krysztal zeby otworzyc strone";

                            if (plusurl)
                                SendMessageGumps(from, 2, msg, text, players);
                            else
                                SendMessageGumps(from, 2, msg, text, players);
                        }
                        else if (info.IsSwitched(4)) // Long Message
                        {
                            TextRelay entry1 = info.GetTextEntry(7);
                            string text1 = (entry1 == null ? "" : entry1.Text);

                            TextRelay entry2 = info.GetTextEntry(8);
                            string text2 = (entry2 == null ? "" : entry2.Text);

                            string msg = text1 + " " + text2;

                            if (plusurl)
                                SendMessageGumps(from, 3, msg, plus, players);
                            else
                                SendMessageGumps(from, 3, msg, "nourl", players);
                        }
                        else
                            return;

                        break;
                    }
            }
		}
	}
}
