using Server.Commands;
using System;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;

namespace Server.Commands
{
	public class PDCmdHandlers
	{
		public static void Initialize()
		{
			CommandSystem.Register( "givepd", AccessLevel.GameMaster, new CommandEventHandler( givepd_OnCommand ) );
		}

		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
			CommandSystem.Register( command, access, handler );
		}
		

		[Usage( "givepd" )]
		[Description( "Wybierz gracza ktoremu chcesz dac pdki." )]
		public static void givepd_OnCommand( CommandEventArgs e )
		{
				e.Mobile.Target = new PDTarget();
		}

		private class PDTarget : Target
		{
			private int m_amount;
			private string m_reason;

			public PDTarget() : base( -1, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					Mobile targ = (Mobile)targeted;

					if ( from != targ)
					{
						from.SendGump(new GivePDGump(targ, from));
					}
				}
				else 
					from.SendMessage( "Wybrales zly cel!" );
			}
		}
	}
}