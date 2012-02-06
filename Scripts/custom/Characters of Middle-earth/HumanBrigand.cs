using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "a human corpse" )] 
	public class HumanBrigand : BaseCreature 
	{ 
		public override bool AlwaysMurderer{ get{ return true; } }
		
		[Constructable] 
		public HumanBrigand() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 			
			Hue = Race.Human.RandomSkinHue();

			if ( Female = Utility.RandomBool() )
			{
				Body = 401;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 400;
				Name = NameList.RandomName( "male" );
			}
				
			Title = "the brigand";
			
			SetStr( 86, 100 );
			SetDex( 81, 95 );
			SetInt( 61, 75 );

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 25.0, 47.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 15.0, 37.5 );	

			Fame = 1000;
			Karma = -1000;
			
			// outfit
			AddItem( new Shirt( Utility.RandomNeutralHue() ) );
			
			switch( Utility.Random( 4 ) )
			{
				case 0: AddItem( new Shoes() ); break;
				case 1: AddItem( new ChainChest() ); break;
				case 2: AddItem( new Boots() ); break;
				case 3: AddItem( new ThighBoots() ); break;
			}
			
			if ( Female )
			{
				if ( Utility.RandomBool() )
					AddItem( new LeatherSkirt( Utility.RandomNeutralHue() ) );
			}
			else
				AddItem( new ChainLegs( Utility.RandomNeutralHue() ) );				
			
			// hair, facial hair			
			HairItemID = Race.Human.RandomHair( Female );
			HairHue = Race.Human.RandomHairHue();
			FacialHairItemID = Race.Human.RandomFacialHair( Female );
			
			// weapon, shield
			AddItem( Loot.RandomWeapon() );
			
			if ( Utility.RandomBool() )
				AddItem( Loot.RandomShield() );
								
			PackGold( 50, 150 );
		}

		public HumanBrigand( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );	
/*
			if ( Utility.RandomDouble() < 0.75 )
				c.DropItem( new SeveredHumanEars() );
*/
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