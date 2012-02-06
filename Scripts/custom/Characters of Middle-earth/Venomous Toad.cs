using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Venomous Toad corpse" )]
	[TypeAlias( "Server.Mobiles.Gianttoad" )]
	public class VenomousToad : BaseCreature
	{
		[Constructable]
		public VenomousToad() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Venomous Toad";
			Body = 80;
			BaseSoundID = 0x26B;

			SetStr( 76, 100 );
			SetDex( 6, 25 );
			SetInt( 11, 20 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 5, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );

			Fame = 750;
			Karma = -750;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 77.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}
		
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public VenomousToad(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			if ( version < 1 )
			{
					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
			}
		}
	}
}