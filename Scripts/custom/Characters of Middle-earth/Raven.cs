using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a Raven corpse" )]
	public class Raven : BaseCreature
	{
		[Constructable]
		public Raven() : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Name = "a raven";

			Body = 0x11B;
			BaseSoundID = 0xD1;

			SetStr( 10 );
			SetDex( 25, 35 );
			SetInt( 10 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Wrestling, 4.2, 6.4 );
			SetSkill( SkillName.Tactics, 4.0, 6.0 );
			SetSkill( SkillName.MagicResist, 4.0, 5.0 );

			/* CantWalk = false;
			Blessed = true; */
		}


		public Raven( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		} 
	}
}