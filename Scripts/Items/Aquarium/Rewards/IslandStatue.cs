using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class IslandStatue : Item
	{		
		public override int LabelNumber{ get{ return 1074600; } } // An island statue
		
		[Constructable]
		public IslandStatue() : base( 0x3B0F )
		{
			Weight = 1;
		}

		public IslandStatue( Serial serial ) : base( serial )
		{		
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			
			list.Add( 1073634 ); // An aquarium decoration
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
	}
}
