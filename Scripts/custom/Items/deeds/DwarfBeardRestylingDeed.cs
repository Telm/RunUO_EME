using System;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server.Gumps;

namespace Server.Items
{
	public class DwarfBeardRestylingDeed : Item
	{

		[Constructable]
		public DwarfBeardRestylingDeed() : base( 0x14F0 )
		{
			Name = "Szkice Krasnoludzkich Brod";
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public DwarfBeardRestylingDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Race == Race.Elf )
			{
				from.SendMessage( "Elf nie moze miec brody! Wybacz!" );
				return;
			}

			if (from.Female == true)
			{
				from.SendMessage( "Kobiety nie maja brody!");
				return;
			}

			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else
				from.SendGump( new InternalGump( from, this ) );
		}

		private class InternalGump : Gump
		{
			private Mobile m_From;
			private DwarfBeardRestylingDeed m_Deed;

			public InternalGump( Mobile from, DwarfBeardRestylingDeed deed ) : base( 50, 50 )
			{
				m_From = from;
				m_Deed = deed;

				from.CloseGump( typeof( InternalGump ) );

				AddBackground( 100, 10, 400, 385, 0x1400 );

				AddHtml( 100, 25, 400, 35, "<CENTER>WYBIERZ SZKIC BRODY</CENTER>", false, false ); //localized is not cookie cutter style of hair restyle :P
				
				AddButton( 175, 340, 0xFA5, 0x15A6, 0x0, GumpButtonType.Reply, 0 ); // CANCEL
				AddHtmlLocalized( 210, 342, 90, 35, 3000091, false, false);

				AddBackground( 220, 60, 50, 50, 0x2486 );
				AddBackground( 220, 115, 50, 50, 0x2486 );
				AddBackground( 220, 170, 50, 50, 0x2486 );
				AddBackground( 220, 225, 50, 50, 0x2486 );
				/* AddBackground( 220, 280, 50, 50, 0x2486 ); */
				AddBackground( 425, 60, 50, 50, 0x2486 );
				AddBackground( 425, 115, 50, 50, 0x2486 );
				AddBackground( 425, 170, 50, 50, 0x2486 );
				/* AddBackground( 425, 225, 50, 50, 0x2486 );
				AddBackground( 425, 280, 50, 50, 0x2486 );*/
				AddHtmlLocalized( 150, 75, 80, 35, 1011061, false, false );  // Broda 1
				AddHtmlLocalized( 150, 130, 80, 35, 1011061, false, false ); // Broda 2
				AddHtmlLocalized( 150, 185, 80, 35, 1011061, false, false ); // Broda 3
				AddHtmlLocalized( 150, 230, 80, 35, 1011061, false, false ); // Broda 4
				/* AddHtmlLocalized( 150, 285, 80, 35, 1011061, false, false ); // Broda 5, */
				
				AddHtmlLocalized( 355, 75, 80, 35, 1011061, false, false );  // Broda 6l
				AddHtmlLocalized( 355, 130, 80, 35, 1011061, false, false ); // Broda 7
				AddHtmlLocalized( 355, 185, 80, 35, 1011061, false, false ); // Broda 8
				/* AddHtmlLocalized( 355, 230, 80, 35, 1011061, false, false ); // Broda 9,
				AddHtmlLocalized( 355, 285, 80, 35, 1011061, false, false ); // Broda 10, */

				AddImage( 153, 2,  0xC514 ); // Broda 1
				AddImage( 153, 60,  0xC515 );// Broda 2
				AddImage( 153, 110, 0xC516 );// Broda 3
				AddImage( 153, 170, 0xC51B );// Broda 4
				/* AddImage( 153, 230, 0xC527 );// Broda 5 */
				
				AddImage( 358, 5,  0xC51F );// Broda 6
				AddImage( 358, 60,  0xC51D ); // Broda 7
				AddImage( 358, 115, 0xC51C ); // Broda 8
				/* AddImage( 358, 165, 0xC529 ); // Broda 9
				AddImage( 358, 225, 0xC528 ); // Broda 10 */

				AddButton( 118,  73, 0x15A4, 0x15A6, 2, GumpButtonType.Reply, 0 ); 
				AddButton( 118, 128, 0x15A4, 0x15A6, 3, GumpButtonType.Reply, 0 );
				AddButton( 118, 183, 0x15A4, 0x15A6, 4, GumpButtonType.Reply, 0 );
				AddButton( 118, 238, 0x15A4, 0x15A6, 5, GumpButtonType.Reply, 0 ); 
				/* AddButton( 118, 293, 0x15A4, 0x15A6, 5, GumpButtonType.Reply, 0 );  */
				
				AddButton( 323,  73, 0x15A4, 0x15A6, 6, GumpButtonType.Reply, 0 );
				AddButton( 323, 128, 0x15A4, 0x15A6, 7, GumpButtonType.Reply, 0 ); 
				AddButton( 323, 183, 0x15A4, 0x15A6, 8, GumpButtonType.Reply, 0 ); 
				/* AddButton( 323, 238, 0x15A4, 0x15A6, 8, GumpButtonType.Reply, 0 ); 
				AddButton( 323, 293, 0x15A4, 0x15A6, 8, GumpButtonType.Reply, 0 );  */
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Deed.Deleted )
					return;

				if ( info.ButtonID > 0 )
				{
					int itemID = 0;

				switch ( info.ButtonID )
				{
						case 2: itemID = 0x3840;	break;
						case 3: itemID = 0x3841;	break;
						case 4: itemID = 0x3842;	break;
						case 5: itemID = 0x277D;	break;
						case 6: itemID = 0x2789;	break;
						case 7: itemID = 0x3844;	break;
						case 8: itemID = 0x3843;	break;
				}

				if ( m_From is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)m_From;

					pm.SetHairMods( -1, -1 ); // clear any hair mods (disguise kit, incognito)
				}

					m_From.FacialHairItemID = itemID;
					m_Deed.Delete();
				}
			}
		}
	}
}