using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Gumps;

/*
//////////////////////////////////////////////////////////////
//SYSTEM IMION
//
//ZASADA DZIALANIA:
//Nadajesz KOMUS przydomek ktory zapisuje sie w TWOICH propach
//
//////////////////////////////////////////////////////////////
*/
namespace Server.Commands
{
    public class SetNameCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("SetName", AccessLevel.Player, new CommandEventHandler(SetName_OnCommand));
        }

        [Usage("SetName ")]
        [Description("Komenda ktora pozwala graczowi nadac przydomek. Dziala tylko jesli nie zna danej ososby")]
        public static void SetName_OnCommand(CommandEventArgs arg)
        {
            arg.Mobile.Target = new SetNameTarget();
        }
        private class SetNameTarget : Target
        {
            public SetNameTarget() : base(-1, true, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile m_From, object targeted)
            {
                //string SetName = "tadek";
                if (targeted is Mobile)
                {
                    Mobile m_Target = (Mobile)targeted;
                    if (m_Target is PlayerMobile)
                    {
                        if (((PlayerMobile)m_Target).SetNames.ContainsKey(m_From.Serial) == false)
                        {
                            ((PlayerMobile)m_From).SendGump(new SetNameGump((PlayerMobile)m_From, m_Target));
                            //((PlayerMobile)m_From).SetNames.Add(m_Target.Serial, SetName);
                            //((PlayerMobile)m_From).SendGump(new WrodzoneGump(((PlayerMobile)m_From), m_Target));
                            //m_From.SendMessage("Nadales przydomek");
                            // m_Target.SendMessage("Podal Ci Imie: {0}", m_From.Name);
                        }
                        else
                        {
                            m_From.SendMessage("Już ma przydomek");
                        }
                    }
                    else
                    {
                        m_From.SendMessage("To nie jest gracz!");
                    }
                }
                else
                {
                    m_From.SendMessage("Nie mozesz tego nazwac!");
                }

            }
        }
    }
}