using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
	public class GlobalMessageGump : Gump
	{
        string url;
		public GlobalMessageGump(string name, string message, bool hasurl, string urlb) : base(0, 0)
		{
			Closable = true;
			Dragable = true;
			Resizable = false;

            url = urlb;

            if(hasurl)
                AddBackground(209, 132, 274, 197, 9270);
            else
                AddBackground(209, 132, 274, 172, 9270);

			AddLabel(222, 144, 999, "Wiadomosc od " + name);
			/* AddAlphaRegion( 217, 163, 256, 128 ) */; 
			AddHtml(222, 163, 256, 128, "" + message, false, true);

            if (hasurl)
            {
                AddAlphaRegion(237, 297, 236, 25);
                AddLabel(240, 300, 3, "" + url);
                AddButton(216, 302, 1209, 1210, 1, GumpButtonType.Reply, 0);
            }
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        sender.Send(new LaunchBrowser(url));
                        break;
                    }
            }
		}
	}
}
