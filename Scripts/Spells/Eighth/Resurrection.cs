using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Eighth
{
	public class ResurrectionSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Resurrection", "An Corp",
				245,
				9062,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Ginseng
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

		public ResurrectionSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

        public void Target( object m )
		{
            if (m is Mobile)
            {
                Mobile mm = (Mobile)m; 
                if (!Caster.CanSee(mm))
                {
                    Caster.SendLocalizedMessage(500237); // Target can not be seen.
                }
                else if (mm == Caster)
                {
                    Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
                }
                else if (!Caster.Alive)
                {
                    Caster.SendLocalizedMessage(501040); // The resurrecter must be alive.
                }
                else if (mm.Alive)
                {
                    Caster.SendLocalizedMessage(501041); // Target is not dead.
                }
                else if (!Caster.InRange(mm, 1))
                {
                    Caster.SendLocalizedMessage(501042); // Target is not close enough.
                }
                else if (mm.Map == null || !mm.Map.CanFit(mm.Location, 16, false, false))
                {
                    Caster.SendLocalizedMessage(501042); // Target can not be resurrected at that location.
                    mm.SendLocalizedMessage(502391); // Thou can not be resurrected there!
                }
                else if (mm.Region != null && mm.Region.IsPartOf("Khaldun"))
                {
                    Caster.SendLocalizedMessage(1010395); // The veil of death in this area is too strong and resists thy efforts to restore life.
                }
                else if (CheckBSequence(mm, true))
                {
                    SpellHelper.Turn(Caster, mm);

                    mm.PlaySound(0x214);
                    mm.FixedEffect(0x376A, 10, 16);

                    mm.CloseGump(typeof(ResurrectGump));
                    mm.SendGump(new ResurrectGump(mm, Caster));
                }

            }
            //else if (!m.Player)
            //{
            else if (m is Corpse)
                {
                    Corpse corpse = m as Corpse;
                    Mobile mm = corpse.Owner;
                    //if (!Caster.CanSee(mm))
                    //{
                    //    Caster.SendLocalizedMessage(500237); // Target can not be seen.
                    //}
                    if (mm == Caster)
                    {
                        Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
                    }
                    else if (!Caster.Alive)
                    {
                        Caster.SendLocalizedMessage(501040); // The resurrecter must be alive.
                    }
                    else if (mm.Alive)
                    {
                        Caster.SendLocalizedMessage(501041); // Target is not dead.
                    }
                    //else if (!Caster.InRange(mm, 1))
                    //{
                    //    Caster.SendLocalizedMessage(501042); // Target is not close enough.
                    //}
                    else if (mm.Map == null || !mm.Map.CanFit(mm.Location, 16, false, false))
                    {
                        Caster.SendLocalizedMessage(501042); // Target can not be resurrected at that location.
                        mm.SendLocalizedMessage(502391); // Thou can not be resurrected there!
                    }
                    else if (mm.Region != null && mm.Region.IsPartOf("Khaldun"))
                    {
                        Caster.SendLocalizedMessage(1010395); // The veil of death in this area is too strong and resists thy efforts to restore life.
                    }
                    else if (CheckBSequence(mm, true))
                    {
                        SpellHelper.Turn(Caster, mm);

                        mm.PlaySound(0x214);
                        mm.FixedEffect(0x376A, 10, 16);

                        mm.CloseGump(typeof(ResurrectGump));
                        mm.SendGump(new ResurrectGump(corpse.Owner, Caster));
                    }

                }
                else
                    Caster.SendLocalizedMessage(501043); // Target is not a being.
            //}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ResurrectionSpell m_Owner;

			public InternalTarget( ResurrectionSpell owner ) : base( 1, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				//if ( o is Mobile )
				//{
					m_Owner.Target(/*(Mobile)*/o );
				//}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}