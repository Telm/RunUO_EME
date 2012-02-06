using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an crocodile corpse" )]
	public class Crocodile : BaseCreature
	{
		[Constructable]
		public Crocodile() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a crocodile";
			Body = 0xCE;
			BaseSoundID = 660;

			SetStr( 176, 200 );
			SetDex( 6, 25 );
			SetInt( 101, 200 );

			SetHits( 146, 160 );
			SetStam( 76, 105 );
			SetMana( 0 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );

			Fame = 600;
			Karma = -600;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 77.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Crocodile(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( BaseSoundID == 0x5A )
				BaseSoundID = 660;
		}
	}
}