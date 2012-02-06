//   ___|========================|___
//   \  |  Written by Felladrin  |  /	This script was released on RunUO Forums under the GPL licensing terms.
//    > |      February 2010     | < 
//   /__|========================|__\	Current version: 1.0 (February 6, 2010)

using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Gumps;
using Server.Network;

namespace Server.Commands
{ 
	public class lookCommand
	{ 
		public static void Initialize() 
		{ 
			CommandSystem.Register( "Look", AccessLevel.Player, new CommandEventHandler( look_OnCommand ) );
		}

		[Usage( "Look" )]
		[Description( "Uzyj aby przyjrzec sie jak wyglada inna postac stojaca blisko ciebie, lub by uaktualnic wlasny opis postaci" )]
		public static void look_OnCommand( CommandEventArgs e )
		{ 
			if ( e.Mobile is PlayerMobile ) 
			{				
				e.Mobile.SendMessage( "Komu chcesz sie przyjrzec?" );
				e.Mobile.Target = new lookTarget();
			}
		}
	}

	public class lookTarget : Target
	{ 
		public lookTarget() : base( -1, false, TargetFlags.None )
		{
		}

		protected override void OnTarget( Mobile from, object targeted ) 
		{ 
			if ( from is PlayerMobile && targeted is PlayerMobile ) 
			{ 
				if(from.Equals(targeted))
				{
					((Mobile)targeted).DisplayPaperdollTo( from );
					from.Send( new DisplayProfile( !from.ProfileLocked, from, "Opis " + from.Name, from.Profile, "Uzyj tego aby opisac siebie") );
				}
				else 
				{
                    ((Mobile)targeted).SendMessage("Zauwazyles ze {0} spoglada na ciebie.", ((Mobile)targeted).GetNameUseBy(from));
					((Mobile)targeted).DisplayPaperdollTo( from );
					from.CloseGump( typeof( lookGump ) );
					from.SendGump(new lookGump( from, (Mobile)targeted ));
				}
			}
	 		else
				from.SendMessage("Niezuwazasz nic szczegolnego wartego zapamietania...");
		} 
	}
 
	public class lookGump : Gump
	{
		private const int Width = 300;
		private const int Height = 200;

		public lookGump( Mobile m, Mobile target ) : base( 100, 100 )
		{
			AddPage( 0 );

			AddBackground( 0, 0, Width, Height, 0xDAC );

			AddPage( 1 );

            AddHtml(0, 10, Width, 25, "<CENTER>" + "Observing " + target.GetNameUseBy(m), false, false);
			AddHtml( 20, 30, Width-40, Height-50, target.Profile, true, true );
		}
	}
}
