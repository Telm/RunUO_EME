using System;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Commands
{
    public class GlobalMessageCommands
    {
        public static void Initialize()
        {
            CommandSystem.Register("gump", AccessLevel.GameMaster, new CommandEventHandler(On_GlobalMessage));
        }

        private static void On_GlobalMessage(CommandEventArgs e)
        {
            Mobile from = (Mobile)e.Mobile;

            from.CloseGump(typeof(MessageComposeGump));
            from.SendGump(new MessageComposeGump());
        }
    }
}