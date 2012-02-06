using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Commands
{
    public class TellNameCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("TellName", AccessLevel.Player, new CommandEventHandler(TellName_OnCommand));
        }

        [Usage("TellName ")]
        [Description("Komenda ktora pozwala graczowi podac swoje prawdziwe imie innemu graczowi. Podajesz komus imie, ale serial tego kogos zapisuje sie u ciebie")]
        public static void TellName_OnCommand(CommandEventArgs arg)
        {
            arg.Mobile.Target = new AddName();
        }
        private class AddName : Target
        {
            public AddName()
                : base(-1, true, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile m_From, object targeted)
            {
                if (targeted is Mobile)
                {
                    Mobile m_Target = (Mobile)targeted;
                    if (((PlayerMobile)m_From).KnewNames.Contains(m_Target.Serial) == false)
                    {
                        ((PlayerMobile)m_From).KnewNames.Add(m_Target.Serial);
                        m_From.SendMessage("Ty Podales Swoje imie");
                        m_Target.SendMessage("Podal Ci Imie: {0}", m_From.Name);
                    }
                    else
                    {
                        m_From.SendMessage("Podales mu juz Twoje imie");
                    }
                }
                else
                {
                    m_From.SendMessage("Tak nie idzie!");
                }

            }
        }
    }
}