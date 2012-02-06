// LOTR - Ring & Ring Wraith Package
// X-SirSly-X


using System; 
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Items; 

namespace Server.Items
{
	public class TheOneRing : BaseRing
	{
			private int i_charges; 
	
			[CommandProperty( AccessLevel.GameMaster )] 
			public int Charges 
			{ 
				get { return i_charges; } 
				set { i_charges = value; InvalidateProperties(); } 
			} 

		[Constructable]
		public TheOneRing() : base( 0x108a )
		{
			Name = "The One Ring";
			Weight = 1;
			Charges = Utility.RandomMinMax(2,4);
			LootType = LootType.Cursed;
		}

		public override bool OnEquip( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				if ( this.Charges >= 1 )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0:  
						from.Hits -= Utility.RandomMinMax(15,30); 
						from.SendMessage( "You feel pain surge throughout your body..." );				
						break; 
					}
					
		      from.Hidden = true; 
    		  from.AllowedStealthSteps = Utility.RandomMinMax(1,3); 

					switch ( Utility.Random( 5 ) )
					{
						case 0:
						{
							RingWraith mob = new RingWraith();
							mob.MoveToWorld(from.Location, from.Map);
							mob.Combatant = from;
						} break; 
					}
					this.Charges = this.Charges - 1;	
					return true;
				}
				
				if ( this.Charges < 1 )
				{
					from.SendMessage( "You do not feel strong enough to equip the ring..." );
					return false;  
				}
			}
			return false;  
		}

		public TheOneRing( Serial serial ) : base( serial )
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
			Charges = Utility.RandomMinMax(1,4);
		}
	}
}
//Sly