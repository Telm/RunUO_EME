using Server.Commands;
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;

namespace Server.Commands
{
    public class TameCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Tame", AccessLevel.GameMaster, new CommandEventHandler(Tame_OnCommand));
        }


        [Usage("Tame <text>")]
        [Description("Wybierz zwierze, ktore chcesz oswoic")]
        public static void Tame_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.Target = new TameTarget();
            from.SendMessage("Jakie zwierze chcesz oswoic?");
        }


        private class TameTarget : Target
        {
            public TameTarget(): base(15, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                PlayerMobile pm = (PlayerMobile)from;
                if (targeted is BaseCreature)
                {

                    BaseCreature Tamata = (BaseCreature)targeted;
                    Tamata.Controlled = true;
                    Tamata.ControlMaster = from;
                }

                else

                    from.SendMessage("Mozesz oswoic na raz tylko jedno zwierze!");
            }
        }
    }
}
    
