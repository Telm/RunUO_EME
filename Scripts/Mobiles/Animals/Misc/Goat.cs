using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a goat corpse" )]
	public class Goat : BaseCreature
	{
		private DateTime m_MilkedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MilkedOn
		{
			get { return m_MilkedOn; }
			set { m_MilkedOn = value; }
		}

		private int m_Milk;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Milk
		{
			get { return m_Milk; }
			set { m_Milk = value; }
		}

		[Constructable]
		public Goat() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a goat";
			Body = 0xD1;
			BaseSoundID = 0x99;

			SetStr( 19 );
			SetDex( 15 );
			SetInt( 5 );

			SetHits( 12 );
			SetMana( 0 );

			SetDamage( 3, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 15 );

			SetSkill( SkillName.MagicResist, 5.0 );
			SetSkill( SkillName.Tactics, 5.0 );
			SetSkill( SkillName.Wrestling, 5.0 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 10;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 11.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 8; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay | FoodType.FruitsAndVegies; } }
		
		public override void OnDoubleClick( Mobile from )
		{
			base.OnDoubleClick( from );

			int random = Utility.Random( 100 );

			if ( random < 5 )
				Tip();
			else if ( random < 20 )
				PlaySound( 120 );
			else if ( random < 40 )
				PlaySound( 121 );
		}

		public void Tip()
		{
			PlaySound( 121 );
			Animate( 8, 0, 3, true, false, 0 );
		}

		public bool TryMilk( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
				from.SendLocalizedMessage( 1080400 ); // You can not milk the cow from this location.
			if ( Controlled && ControlMaster != from )
				from.SendLocalizedMessage( 1071182 ); // The cow nimbly escapes your attempts to milk it.
			if ( m_Milk == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
				from.SendLocalizedMessage( 1080198 ); // This cow can not be milked now. Please wait for some time.
			else
			{
				if ( m_Milk == 0 )
					m_Milk = 4;

				m_MilkedOn = DateTime.Now;
				m_Milk--;

				return true;
			}

			return false;
		}

		public Goat(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Milk );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

            switch (version)
            {

                case 2:
                    {
                        DateTime m_MilkedOn = reader.ReadDateTime();
                        goto case 1;
                    }
                case 1:
                    {
                        m_Milk = reader.ReadInt();
                        break;
                    }
            }
		}
	}
}