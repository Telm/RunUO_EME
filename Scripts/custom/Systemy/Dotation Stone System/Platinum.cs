///AnimalCrackers///
///////////////////
////Game Over/////
////Project//////
////////////////
using System;
using Server;

namespace Server.Factions
{
	public class Platinum : Item
	{
		public override double DefaultWeight
		{
			get { return 0.00; }
		}

		[Constructable]
		public Platinum() : this( 1 )
		{
		}

		[Constructable]
		public Platinum( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public Platinum( int amount ) : base( 0xEF0 )
		{
			Name = "Platinum Coin";
			Hue = 1895;
			Stackable = true;
			Amount = amount;
		}

		public Platinum( Serial serial ) : base( serial )
		{
		}

		public override int GetDropSound()
		{
			if ( Amount <= 1 )
				return 0x2E4;
			else if ( Amount <= 5 )
				return 0x2E5;
			else
				return 0x2E6;
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