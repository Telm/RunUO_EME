using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Thief : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Thief() : base( "Zlodziej" )
		{
			SetSkill( SkillName.Camping, 55.0, 78.0 );
			SetSkill( SkillName.DetectHidden, 65.0, 88.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBThief() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Shirt( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.LongPants( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.Dagger() );
			AddItem( new Server.Items.ThighBoots( Utility.RandomNeutralHue() ) );
		}

		public Thief( Serial serial ) : base( serial )
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
	}
}