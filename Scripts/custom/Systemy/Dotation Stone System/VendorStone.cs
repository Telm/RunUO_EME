//Raelis's vendor stone Mod For Platinum////
/////AnimalCrackers Game Over Project//////
////////www.GameOVerProject.com///////////
///////////////////////////////////////// 
using System; 
using System.IO;
using System.Collections;
using Server.Items; 
using Server.Network; 
using Server.Gumps; 
using Server.Mobiles; 
using Server.Targeting;
using Server.Targets;

namespace Server.Mobiles
{
	public class VendorType
	{
		public static Type GetType( string name )
		{
			return ScriptCompiler.FindTypeByName( name );
		}
	}
}

namespace Server.Items
{
	public class VendorBall : Item
	{
		private VendorStone m_Stone;

		//[CommandProperty( AccessLevel.GameMaster )]
		public VendorStone Stone{ get{ return m_Stone; } set{ m_Stone = value; } }

		[Constructable]
		public VendorBall() : base( 0x1869 )
		{
			Weight = 0.1;
			Hue = 89; 
			Name = "Kula Upominkow";
		}

		public VendorBall( Serial serial ) : base( serial )
		{
		}

		private void ConnectTarget_Callback( Mobile from, object obj ) 
		{ 
			if ( obj is VendorStone && obj is Item ) 
			{ 
				Item item = (Item)obj;
				VendorStone ps = (VendorStone)obj;

				Stone = ps;
				from.SendMessage( "You have connected the ball to the stone." );
			} 
			else 
			{ 
				from.SendMessage( "That is an invalid target!" );
			}
		}

		public override void OnDoubleClick( Mobile from ) 
		{ 
			if ( Stone != null && !Stone.Deleted )
			{
				from.SendGump( new VendorGump( from, Stone ) );
				Stone.Hued = false;
				Stone.Blessed = false;
				Stone.Bonded = false;
			}
			else
			{
				from.BeginTarget( -1, false, TargetFlags.Beneficial, new TargetCallback( ConnectTarget_Callback ) );
				from.SendMessage( "Please target a stone to connect this ball to." );
			}
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( Stone != null && !Stone.Deleted )
			{
				if ( Stone.Name != null )
					LabelTo( from, "Stone Ball, Connected to: "+ Stone.Name );
				else
					LabelTo( from, "Stone Ball, Connected to: !SET THE STONE'S NAME!" );
			}
			else
			{
				LabelTo( from, "Stone Ball, Connected to: None" );
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( Stone != null && !Stone.Deleted )
			{
				if ( Stone.Name != null )
					list.Add( "Stone Ball, Connected to: "+ Stone.Name );
				else
					list.Add( "Stone Ball, Connected to: !SET THE STONE'S NAME!" );
			}
			else
			{
				list.Add( "Stone Ball, Connected to: None" );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( m_Stone );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_Stone = reader.ReadItem() as VendorStone;
		}
	}
}

namespace Server.Items
{ 
	public class VendorStone : Item 
	{ 
		private bool m_Blessed;
		private bool m_Bonded;
		private bool m_Hued;
		private int m_BlessedPrice;
		private int m_BondedPrice;
		private int m_HuedPrice;

		private Type m_Currency = typeof(Gold);

		private int m_Price1;	private int m_Price2;	private int m_Price3;	private int m_Price4;
		private int m_Price5;	private int m_Price6;	private int m_Price7;	private int m_Price8;
		private int m_Price9;	private int m_Price10;	private int m_Price11;	private int m_Price12;
		private int m_Price13;	private int m_Price14;	private int m_Price15;	private int m_Price16;
		private int m_Price17;	private int m_Price18;	private int m_Price19;	private int m_Price20;
		private int m_Price21;	private int m_Price22;	private int m_Price23;	private int m_Price24;
		private int m_Price25;	private int m_Price26;	private int m_Price27;	private int m_Price28;
		private int m_Price29;	private int m_Price30;	private int m_Price31;	private int m_Price32;
		private int m_Price33;	private int m_Price34;	private int m_Price35;	private int m_Price36;
		private int m_Price37;	private int m_Price38;	private int m_Price39;	private int m_Price40;


		private string m_Item1;   private string m_Item2;   private string m_Item3;   private string m_Item4;
		private string m_Item5;   private string m_Item6;   private string m_Item7;   private string m_Item8;
		private string m_Item9;   private string m_Item10;   private string m_Item11;   private string m_Item12;
		private string m_Item13;   private string m_Item14;   private string m_Item15;   private string m_Item16;
		private string m_Item17;   private string m_Item18;   private string m_Item19;   private string m_Item20;
		private string m_Item21;   private string m_Item22;   private string m_Item23;   private string m_Item24;
		private string m_Item25;   private string m_Item26;   private string m_Item27;   private string m_Item28;
		private string m_Item29;   private string m_Item30;   private string m_Item31;   private string m_Item32;
		private string m_Item33;   private string m_Item34;   private string m_Item35;   private string m_Item36;
		private string m_Item37;   private string m_Item38;   private string m_Item39;   private string m_Item40;


		private string m_GumpName1;   private string m_GumpName2;   private string m_GumpName3;   private string m_GumpName4;
		private string m_GumpName5;   private string m_GumpName6;   private string m_GumpName7;   private string m_GumpName8;
		private string m_GumpName9;   private string m_GumpName10;   private string m_GumpName11;   private string m_GumpName12;
		private string m_GumpName13;   private string m_GumpName14;   private string m_GumpName15;   private string m_GumpName16;
		private string m_GumpName17;   private string m_GumpName18;   private string m_GumpName19;   private string m_GumpName20;
		private string m_GumpName21;   private string m_GumpName22;   private string m_GumpName23;   private string m_GumpName24;
		private string m_GumpName25;   private string m_GumpName26;   private string m_GumpName27;   private string m_GumpName28;
		private string m_GumpName29;   private string m_GumpName30;   private string m_GumpName31;   private string m_GumpName32;
		private string m_GumpName33;   private string m_GumpName34;   private string m_GumpName35;   private string m_GumpName36;
		private string m_GumpName37;   private string m_GumpName38;   private string m_GumpName39;   private string m_GumpName40;

		//[CommandProperty( AccessLevel.Seer )]
		public bool Blessed{get{return m_Blessed;}set{m_Blessed = value;}}

		//[CommandProperty( AccessLevel.Seer )]
		public bool Bonded{get{return m_Bonded;}set{m_Bonded = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public bool Hued{get{return m_Hued;}set{m_Hued = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int BlessedPrice{get{return m_BlessedPrice;}set{m_BlessedPrice = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int BondedPrice{get{return m_BondedPrice;}set{m_BondedPrice = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int HuedPrice{get{return m_HuedPrice;}set{m_HuedPrice = value;}}

		[CommandProperty( AccessLevel.Seer )]
		public Type Currency{get{return m_Currency;}set{m_Currency = value;}}

		//[CommandProperty( AccessLevel.Seer )]
		public int Price1{get{return m_Price1;}set{m_Price1 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price2{get{return m_Price2;}set{m_Price2 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price3{get{return m_Price3;}set{m_Price3 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price4{get{return m_Price4;}set{m_Price4 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price5{get{return m_Price5;}set{m_Price5 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price6{get{return m_Price6;}set{m_Price6 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price7{get{return m_Price7;}set{m_Price7 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price8{get{return m_Price8;}set{m_Price8 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price9{get{return m_Price9;}set{m_Price9 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price10{get{return m_Price10;}set{m_Price10 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price11{get{return m_Price11;}set{m_Price11 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price12{get{return m_Price12;}set{m_Price12 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price13{get{return m_Price13;}set{m_Price13 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price14{get{return m_Price14;}set{m_Price14 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price15{get{return m_Price15;}set{m_Price15 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price16{get{return m_Price16;}set{m_Price16 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price17{get{return m_Price17;}set{m_Price17 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price18{get{return m_Price18;}set{m_Price18 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price19{get{return m_Price19;}set{m_Price19 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price20{get{return m_Price20;}set{m_Price20 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price21{get{return m_Price21;}set{m_Price21 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price22{get{return m_Price22;}set{m_Price22 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price23{get{return m_Price23;}set{m_Price23 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price24{get{return m_Price24;}set{m_Price24 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price25{get{return m_Price25;}set{m_Price25 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price26{get{return m_Price26;}set{m_Price26 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price27{get{return m_Price27;}set{m_Price27 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price28{get{return m_Price28;}set{m_Price28 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price29{get{return m_Price29;}set{m_Price29 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price30{get{return m_Price30;}set{m_Price30 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price31{get{return m_Price31;}set{m_Price31 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price32{get{return m_Price32;}set{m_Price32 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price33{get{return m_Price33;}set{m_Price33 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price34{get{return m_Price34;}set{m_Price34 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price35{get{return m_Price35;}set{m_Price35 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price36{get{return m_Price36;}set{m_Price36 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price37{get{return m_Price37;}set{m_Price37 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price38{get{return m_Price38;}set{m_Price38 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price39{get{return m_Price39;}set{m_Price39 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public int Price40{get{return m_Price40;}set{m_Price40 = value;}}


		//[CommandProperty( AccessLevel.Seer )]
		public string Item1{get{return m_Item1;}set{m_Item1 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item2{get{return m_Item2;}set{m_Item2 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item3{get{return m_Item3;}set{m_Item3 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item4{get{return m_Item4;}set{m_Item4 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item5{get{return m_Item5;}set{m_Item5 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item6{get{return m_Item6;}set{m_Item6 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item7{get{return m_Item7;}set{m_Item7 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item8{get{return m_Item8;}set{m_Item8 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item9{get{return m_Item9;}set{m_Item9 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item10{get{return m_Item10;}set{m_Item10 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item11{get{return m_Item11;}set{m_Item11 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item12{get{return m_Item12;}set{m_Item12 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item13{get{return m_Item13;}set{m_Item13 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item14{get{return m_Item14;}set{m_Item14 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item15{get{return m_Item15;}set{m_Item15 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item16{get{return m_Item16;}set{m_Item16 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item17{get{return m_Item17;}set{m_Item17 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item18{get{return m_Item18;}set{m_Item18 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item19{get{return m_Item19;}set{m_Item19 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item20{get{return m_Item20;}set{m_Item20 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item21{get{return m_Item21;}set{m_Item21 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item22{get{return m_Item22;}set{m_Item22 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item23{get{return m_Item23;}set{m_Item23 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item24{get{return m_Item24;}set{m_Item24 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item25{get{return m_Item25;}set{m_Item25 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item26{get{return m_Item26;}set{m_Item26 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item27{get{return m_Item27;}set{m_Item27 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item28{get{return m_Item28;}set{m_Item28 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item29{get{return m_Item29;}set{m_Item29 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item30{get{return m_Item30;}set{m_Item30 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item31{get{return m_Item31;}set{m_Item31 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item32{get{return m_Item32;}set{m_Item32 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item33{get{return m_Item33;}set{m_Item33 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item34{get{return m_Item34;}set{m_Item34 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item35{get{return m_Item35;}set{m_Item35 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item36{get{return m_Item36;}set{m_Item36 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item37{get{return m_Item37;}set{m_Item37 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item38{get{return m_Item38;}set{m_Item38 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item39{get{return m_Item39;}set{m_Item39 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string Item40{get{return m_Item40;}set{m_Item40 = value;}}


		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName1{get{return m_GumpName1;}set{m_GumpName1 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName2{get{return m_GumpName2;}set{m_GumpName2 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName3{get{return m_GumpName3;}set{m_GumpName3 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName4{get{return m_GumpName4;}set{m_GumpName4 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName5{get{return m_GumpName5;}set{m_GumpName5 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName6{get{return m_GumpName6;}set{m_GumpName6 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName7{get{return m_GumpName7;}set{m_GumpName7 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName8{get{return m_GumpName8;}set{m_GumpName8 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName9{get{return m_GumpName9;}set{m_GumpName9 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName10{get{return m_GumpName10;}set{m_GumpName10 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName11{get{return m_GumpName11;}set{m_GumpName11 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName12{get{return m_GumpName12;}set{m_GumpName12 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName13{get{return m_GumpName13;}set{m_GumpName13 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName14{get{return m_GumpName14;}set{m_GumpName14 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName15{get{return m_GumpName15;}set{m_GumpName15 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName16{get{return m_GumpName16;}set{m_GumpName16 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName17{get{return m_GumpName17;}set{m_GumpName17 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName18{get{return m_GumpName18;}set{m_GumpName18 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName19{get{return m_GumpName19;}set{m_GumpName19 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName20{get{return m_GumpName20;}set{m_GumpName20 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName21{get{return m_GumpName21;}set{m_GumpName21 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName22{get{return m_GumpName22;}set{m_GumpName22 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName23{get{return m_GumpName23;}set{m_GumpName23 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName24{get{return m_GumpName24;}set{m_GumpName24 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName25{get{return m_GumpName25;}set{m_GumpName25 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName26{get{return m_GumpName26;}set{m_GumpName26 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName27{get{return m_GumpName27;}set{m_GumpName27 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName28{get{return m_GumpName28;}set{m_GumpName28 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName29{get{return m_GumpName29;}set{m_GumpName29 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName30{get{return m_GumpName30;}set{m_GumpName30 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName31{get{return m_GumpName31;}set{m_GumpName31 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName32{get{return m_GumpName32;}set{m_GumpName32 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName33{get{return m_GumpName33;}set{m_GumpName33 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName34{get{return m_GumpName34;}set{m_GumpName34 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName35{get{return m_GumpName35;}set{m_GumpName35 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName36{get{return m_GumpName36;}set{m_GumpName36 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName37{get{return m_GumpName37;}set{m_GumpName37 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName38{get{return m_GumpName38;}set{m_GumpName38 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName39{get{return m_GumpName39;}set{m_GumpName39 = value;}}
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName40{get{return m_GumpName40;}set{m_GumpName40 = value;}}

		[Constructable] 
		public VendorStone() : base( 0xEDC ) 
		{ 
			Movable = false; 
			Hue = 806; 
			Name = "Vendor Stone";
		} 

		public override void OnDoubleClick( Mobile from ) 
		{ 
			from.SendGump( new VendorGump( from, this ) );
			this.Hued = false;
			this.Blessed = false;
			this.Bonded = false;
		}

		public VendorStone( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
			writer.Write( (bool)Blessed );
			writer.Write( (bool)Bonded );
			writer.Write( (bool)Hued );
			writer.Write( (int)BlessedPrice );
			writer.Write( (int)BondedPrice );
			writer.Write( (int)HuedPrice );

			writer.Write( m_Currency.ToString() );

			writer.Write( (int)Price1 );
			writer.Write( (int)Price2 );
			writer.Write( (int)Price3 );
			writer.Write( (int)Price4 );
			writer.Write( (int)Price5 );
			writer.Write( (int)Price6 );
			writer.Write( (int)Price7 );
			writer.Write( (int)Price8 );
			writer.Write( (int)Price9 );
			writer.Write( (int)Price10 );
			writer.Write( (int)Price11 );
			writer.Write( (int)Price12 );
			writer.Write( (int)Price13 );
			writer.Write( (int)Price14 );
			writer.Write( (int)Price15 );
			writer.Write( (int)Price16 );
			writer.Write( (int)Price17 );
			writer.Write( (int)Price18 );
			writer.Write( (int)Price19 );
			writer.Write( (int)Price20 );
			writer.Write( (int)Price21 );
			writer.Write( (int)Price22 );
			writer.Write( (int)Price23 );
			writer.Write( (int)Price24 );
			writer.Write( (int)Price25 );
			writer.Write( (int)Price26 );
			writer.Write( (int)Price27 );
			writer.Write( (int)Price28 );
			writer.Write( (int)Price29 );
			writer.Write( (int)Price30 );
			writer.Write( (int)Price31 );
			writer.Write( (int)Price32 );
			writer.Write( (int)Price33 );
			writer.Write( (int)Price34 );
			writer.Write( (int)Price35 );
			writer.Write( (int)Price36 );
			writer.Write( (int)Price37 );
			writer.Write( (int)Price38 );
			writer.Write( (int)Price39 );
			writer.Write( (int)Price40 );

			writer.Write( (string)Item1 );
			writer.Write( (string)Item2 );
			writer.Write( (string)Item3 );
			writer.Write( (string)Item4 );
			writer.Write( (string)Item5 );
			writer.Write( (string)Item6 );
			writer.Write( (string)Item7 );
			writer.Write( (string)Item8 );
			writer.Write( (string)Item9 );
			writer.Write( (string)Item10 );
			writer.Write( (string)Item11 );
			writer.Write( (string)Item12 );
			writer.Write( (string)Item13 );
			writer.Write( (string)Item14 );
			writer.Write( (string)Item15 );
			writer.Write( (string)Item16 );
			writer.Write( (string)Item17 );
			writer.Write( (string)Item18 );
			writer.Write( (string)Item19 );
			writer.Write( (string)Item20 );
			writer.Write( (string)Item21 );
			writer.Write( (string)Item22 );
			writer.Write( (string)Item23 );
			writer.Write( (string)Item24 );
			writer.Write( (string)Item25 );
			writer.Write( (string)Item26 );
			writer.Write( (string)Item27 );
			writer.Write( (string)Item28 );
			writer.Write( (string)Item29 );
			writer.Write( (string)Item30 );
			writer.Write( (string)Item31 );
			writer.Write( (string)Item32 );
			writer.Write( (string)Item33 );
			writer.Write( (string)Item34 );
			writer.Write( (string)Item35 );
			writer.Write( (string)Item36 );
			writer.Write( (string)Item37 );
			writer.Write( (string)Item38 );
			writer.Write( (string)Item39 );
			writer.Write( (string)Item40 );

			writer.Write( (string)GumpName1 );
			writer.Write( (string)GumpName2 );
			writer.Write( (string)GumpName3 );
			writer.Write( (string)GumpName4 );
			writer.Write( (string)GumpName5 );
			writer.Write( (string)GumpName6 );
			writer.Write( (string)GumpName7 );
			writer.Write( (string)GumpName8 );
			writer.Write( (string)GumpName9 );
			writer.Write( (string)GumpName10 );
			writer.Write( (string)GumpName11 );
			writer.Write( (string)GumpName12 );
			writer.Write( (string)GumpName13 );
			writer.Write( (string)GumpName14 );
			writer.Write( (string)GumpName15 );
			writer.Write( (string)GumpName16 );
			writer.Write( (string)GumpName17 );
			writer.Write( (string)GumpName18 );
			writer.Write( (string)GumpName19 );
			writer.Write( (string)GumpName20 );
			writer.Write( (string)GumpName21 );
			writer.Write( (string)GumpName22 );
			writer.Write( (string)GumpName23 );
			writer.Write( (string)GumpName24 );
			writer.Write( (string)GumpName25 );
			writer.Write( (string)GumpName26 );
			writer.Write( (string)GumpName27 );
			writer.Write( (string)GumpName28 );
			writer.Write( (string)GumpName29 );
			writer.Write( (string)GumpName30 );
			writer.Write( (string)GumpName31 );
			writer.Write( (string)GumpName32 );
			writer.Write( (string)GumpName33 );
			writer.Write( (string)GumpName34 );
			writer.Write( (string)GumpName35 );
			writer.Write( (string)GumpName36 );
			writer.Write( (string)GumpName37 );
			writer.Write( (string)GumpName38 );
			writer.Write( (string)GumpName39 );
			writer.Write( (string)GumpName40 );
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 

			m_Blessed = reader.ReadBool(); 
			m_Bonded = reader.ReadBool(); 
			m_Hued = reader.ReadBool(); 
			m_BlessedPrice = reader.ReadInt(); 
			m_BondedPrice = reader.ReadInt(); 
			m_HuedPrice = reader.ReadInt(); 

			m_Currency = ScriptCompiler.FindTypeByFullName( reader.ReadString() );

			m_Price1 = reader.ReadInt(); 
			m_Price2 = reader.ReadInt(); 
			m_Price3 = reader.ReadInt(); 
			m_Price4 = reader.ReadInt(); 
			m_Price5 = reader.ReadInt(); 
			m_Price6 = reader.ReadInt(); 
			m_Price7 = reader.ReadInt(); 
			m_Price8 = reader.ReadInt(); 
			m_Price9 = reader.ReadInt(); 
			m_Price10 = reader.ReadInt(); 
			m_Price11 = reader.ReadInt(); 
			m_Price12 = reader.ReadInt(); 
			m_Price13 = reader.ReadInt(); 
			m_Price14 = reader.ReadInt(); 
			m_Price15 = reader.ReadInt(); 
			m_Price16 = reader.ReadInt(); 
			m_Price17 = reader.ReadInt(); 
			m_Price18 = reader.ReadInt(); 
			m_Price19 = reader.ReadInt(); 
			m_Price20 = reader.ReadInt(); 
			m_Price21 = reader.ReadInt(); 
			m_Price22 = reader.ReadInt(); 
			m_Price23 = reader.ReadInt(); 
			m_Price24 = reader.ReadInt(); 
			m_Price25 = reader.ReadInt(); 
			m_Price26 = reader.ReadInt(); 
			m_Price27 = reader.ReadInt(); 
			m_Price28 = reader.ReadInt(); 
			m_Price29 = reader.ReadInt(); 
			m_Price30 = reader.ReadInt(); 
			m_Price31 = reader.ReadInt(); 
			m_Price32 = reader.ReadInt(); 
			m_Price33 = reader.ReadInt(); 
			m_Price34 = reader.ReadInt(); 
			m_Price35 = reader.ReadInt(); 
			m_Price36 = reader.ReadInt(); 
			m_Price37 = reader.ReadInt(); 
			m_Price38 = reader.ReadInt(); 
			m_Price39 = reader.ReadInt(); 
			m_Price40 = reader.ReadInt(); 

			m_Item1 = reader.ReadString(); 
			m_Item2 = reader.ReadString(); 
			m_Item3 = reader.ReadString(); 
			m_Item4 = reader.ReadString(); 
			m_Item5 = reader.ReadString(); 
			m_Item6 = reader.ReadString(); 
			m_Item7 = reader.ReadString(); 
			m_Item8 = reader.ReadString(); 
			m_Item9 = reader.ReadString(); 
			m_Item10 = reader.ReadString(); 
			m_Item11 = reader.ReadString(); 
			m_Item12 = reader.ReadString(); 
			m_Item13 = reader.ReadString(); 
			m_Item14 = reader.ReadString(); 
			m_Item15 = reader.ReadString(); 
			m_Item16 = reader.ReadString(); 
			m_Item17 = reader.ReadString(); 
			m_Item18 = reader.ReadString(); 
			m_Item19 = reader.ReadString(); 
			m_Item20 = reader.ReadString(); 
			m_Item21 = reader.ReadString(); 
			m_Item22 = reader.ReadString(); 
			m_Item23 = reader.ReadString(); 
			m_Item24 = reader.ReadString(); 
			m_Item25 = reader.ReadString(); 
			m_Item26 = reader.ReadString(); 
			m_Item27 = reader.ReadString(); 
			m_Item28 = reader.ReadString(); 
			m_Item29 = reader.ReadString(); 
			m_Item30 = reader.ReadString(); 
			m_Item31 = reader.ReadString(); 
			m_Item32 = reader.ReadString(); 
			m_Item33 = reader.ReadString(); 
			m_Item34 = reader.ReadString(); 
			m_Item35 = reader.ReadString(); 
			m_Item36 = reader.ReadString(); 
			m_Item37 = reader.ReadString(); 
			m_Item38 = reader.ReadString(); 
			m_Item39 = reader.ReadString(); 
			m_Item40 = reader.ReadString(); 

			m_GumpName1 = reader.ReadString(); 
			m_GumpName2 = reader.ReadString(); 
			m_GumpName3 = reader.ReadString(); 
			m_GumpName4 = reader.ReadString(); 
			m_GumpName5 = reader.ReadString(); 
			m_GumpName6 = reader.ReadString(); 
			m_GumpName7 = reader.ReadString(); 
			m_GumpName8 = reader.ReadString(); 
			m_GumpName9 = reader.ReadString(); 
			m_GumpName10 = reader.ReadString(); 
			m_GumpName11 = reader.ReadString(); 
			m_GumpName12 = reader.ReadString(); 
			m_GumpName13 = reader.ReadString(); 
			m_GumpName14 = reader.ReadString(); 
			m_GumpName15 = reader.ReadString(); 
			m_GumpName16 = reader.ReadString(); 
			m_GumpName17 = reader.ReadString(); 
			m_GumpName18 = reader.ReadString(); 
			m_GumpName19 = reader.ReadString(); 
			m_GumpName20 = reader.ReadString(); 
			m_GumpName21 = reader.ReadString(); 
			m_GumpName22 = reader.ReadString(); 
			m_GumpName23 = reader.ReadString(); 
			m_GumpName24 = reader.ReadString(); 
			m_GumpName25 = reader.ReadString(); 
			m_GumpName26 = reader.ReadString(); 
			m_GumpName27 = reader.ReadString(); 
			m_GumpName28 = reader.ReadString(); 
			m_GumpName29 = reader.ReadString(); 
			m_GumpName30 = reader.ReadString(); 
			m_GumpName31 = reader.ReadString(); 
			m_GumpName32 = reader.ReadString(); 
			m_GumpName33 = reader.ReadString(); 
			m_GumpName34 = reader.ReadString(); 
			m_GumpName35 = reader.ReadString(); 
			m_GumpName36 = reader.ReadString(); 
			m_GumpName37 = reader.ReadString(); 
			m_GumpName38 = reader.ReadString(); 
			m_GumpName39 = reader.ReadString(); 
			m_GumpName40 = reader.ReadString(); 
		} 
	} 
} 

namespace Server.Gumps
{ 
	public class VendorGump : Gump
	{
                private VendorStone m_Stone;
		private ArrayList m_SubmitData;

		protected ArrayList SubmitData { get{ return m_SubmitData; } }

                public VendorGump( Mobile from, VendorStone stone ) : base( 25, 25 )
                {
			m_SubmitData = new ArrayList();

			m_Stone = stone;

			AddPage( 0 ); 

			from.CloseGump( typeof( VendorGump ) );
			from.CloseGump( typeof( EditVendorGump ) );

			if ( m_SubmitData.Count == 0 )
			{
				m_SubmitData.Add( m_Stone.Hued );
				m_SubmitData.Add( m_Stone.Blessed );
				m_SubmitData.Add( m_Stone.Bonded );
			}

			AddBackground( 0, 0, 530, 480, 5054 );
			AddAlphaRegion( 10, 10, 510, 460 );
			AddImageTiled( 10, 40, 510, 5, 2624 );

			if ( m_Stone.Name != null && m_Stone.Name != "" )
			{
				AddLabel( 235, 20, 1152, m_Stone.Name );
			}
			else
			{
				AddLabel( 235, 20, 1152, "!STONE NAME GOES HERE!" );
			}

			AddLabel( 420, 60, 5, "Stone Currency:" );
			if ( m_Stone.Currency != null )
			{
				if ( m_Stone.Currency.Name != null )
				{
					AddLabel( 420, 80, 5, m_Stone.Currency.Name );
				}
				else
				{
					AddLabel( 420, 80, 33, ""+ m_Stone.Currency );
				}
			}
			else
			{
				AddLabel( 420, 80, 33, "None" );
			}

			if ( m_Stone.HuedPrice > 0 )
			{
				AddCheck( 400, 160, 0x2342, 0x2343, (bool)m_SubmitData[0], 1 );
				AddLabel( 430, 160, 1152, "Hue: "+ m_Stone.HuedPrice );
			}
			if ( m_Stone.BlessedPrice > 0 )
			{
				AddCheck( 400, 180, 0x2342, 0x2343, (bool)m_SubmitData[1], 2 );
				AddLabel( 430, 180, 1152, "Bless: "+ m_Stone.BlessedPrice );
			}
			if ( m_Stone.BondedPrice > 0 )
			{
				AddCheck( 400, 200, 0x2342, 0x2343, (bool)m_SubmitData[2], 3 );
				AddLabel( 430, 200, 1152, "Bond: "+ m_Stone.BondedPrice );
			}

			if ( from.AccessLevel >= AccessLevel.Seer )
			{
				AddButton( 400, 240, 4005, 4007, 41, GumpButtonType.Reply, 0 ); 
				AddLabel( 430, 240, 1152, "Edit" );
			}

			//AddLabel( 420, 360, 906, "Created By" );
			//AddLabel( 420, 380, 906, "~Raelis~" );

			AddButton( 420, 440, 4005, 4007, 0, GumpButtonType.Reply, 0 ); 
			AddLabel( 450, 440, 33, "Close" );

			AddPage( 1 ); 

			if ( m_Stone.GumpName1 != null && m_Stone.Item1 != null && m_Stone.GumpName1 != "" && m_Stone.Item1 != "" )
			{
				AddButton( 20, 60, 4005, 4007, 1, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 60, 1152, m_Stone.GumpName1 );
				AddLabel( 300, 60, 1152, ""+ m_Stone.Price1 );
			}

			if ( m_Stone.GumpName2 != null && m_Stone.Item2 != null && m_Stone.GumpName2 != "" && m_Stone.Item2 != "" )
			{
				AddButton( 20, 80, 4005, 4007, 2, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 80, 1152, m_Stone.GumpName2 );
				AddLabel( 300, 80, 1152, ""+ m_Stone.Price2 );
			}

			if ( m_Stone.GumpName3 != null && m_Stone.Item3 != null && m_Stone.GumpName3 != "" && m_Stone.Item3 != "" )
			{
				AddButton( 20, 100, 4005, 4007, 3, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 100, 1152, m_Stone.GumpName3 );
				AddLabel( 300, 100, 1152, ""+ m_Stone.Price3 );
			}

			if ( m_Stone.GumpName4 != null && m_Stone.Item4 != null && m_Stone.GumpName4 != "" && m_Stone.Item4 != "" )
			{
				AddButton( 20, 120, 4005, 4007, 4, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 120, 1152, m_Stone.GumpName4 );
				AddLabel( 300, 120, 1152, ""+ m_Stone.Price4 );
			}

			if ( m_Stone.GumpName5 != null && m_Stone.Item5 != null && m_Stone.GumpName5 != "" && m_Stone.Item5 != "" )
			{
				AddButton( 20, 140, 4005, 4007, 5, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 140, 1152, m_Stone.GumpName5 );
				AddLabel( 300, 140, 1152, ""+ m_Stone.Price5 );
			}

			if ( m_Stone.GumpName6 != null && m_Stone.Item6 != null && m_Stone.GumpName6 != "" && m_Stone.Item6 != "" )
			{
				AddButton( 20, 160, 4005, 4007, 6, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 160, 1152, m_Stone.GumpName6 );
				AddLabel( 300, 160, 1152, ""+ m_Stone.Price6 );
			}

			if ( m_Stone.GumpName7 != null && m_Stone.Item7 != null && m_Stone.GumpName7 != "" && m_Stone.Item7 != "" )
			{
				AddButton( 20, 180, 4005, 4007, 7, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 180, 1152, m_Stone.GumpName7 );
				AddLabel( 300, 180, 1152, ""+ m_Stone.Price7 );
			}

			if ( m_Stone.GumpName8 != null && m_Stone.Item8 != null && m_Stone.GumpName8 != "" && m_Stone.Item8 != "" )
			{
				AddButton( 20, 200, 4005, 4007, 8, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 200, 1152, m_Stone.GumpName8 );
				AddLabel( 300, 200, 1152, ""+ m_Stone.Price8 );
			}

			if ( m_Stone.GumpName9 != null && m_Stone.Item9 != null && m_Stone.GumpName9 != "" && m_Stone.Item9 != "" )
			{
				AddButton( 20, 220, 4005, 4007, 9, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 220, 1152, m_Stone.GumpName9 );
				AddLabel( 300, 220, 1152, ""+ m_Stone.Price9 );
			}

			if ( m_Stone.GumpName10 != null && m_Stone.Item10 != null && m_Stone.GumpName10 != "" && m_Stone.Item10 != "" )
			{
				AddButton( 20, 240, 4005, 4007, 10, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 240, 1152, m_Stone.GumpName10 );
				AddLabel( 300, 240, 1152, ""+ m_Stone.Price10 );
			}

			if ( m_Stone.GumpName11 != null && m_Stone.Item11 != null && m_Stone.GumpName11 != "" && m_Stone.Item11 != "" )
			{
				AddButton( 20, 260, 4005, 4007, 11, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 260, 1152, m_Stone.GumpName11 );
				AddLabel( 300, 260, 1152, ""+ m_Stone.Price11 );
			}

			if ( m_Stone.GumpName12 != null && m_Stone.Item12 != null && m_Stone.GumpName12 != "" && m_Stone.Item12 != "" )
			{
				AddButton( 20, 280, 4005, 4007, 12, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 280, 1152, m_Stone.GumpName12 );
				AddLabel( 300, 280, 1152, ""+ m_Stone.Price12 );
			}

			if ( m_Stone.GumpName13 != null && m_Stone.Item13 != null && m_Stone.GumpName13 != "" && m_Stone.Item13 != "" )
			{
				AddButton( 20, 300, 4005, 4007, 13, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 300, 1152, m_Stone.GumpName13 );
				AddLabel( 300, 300, 1152, ""+ m_Stone.Price13 );
			}

			if ( m_Stone.GumpName14 != null && m_Stone.Item14 != null && m_Stone.GumpName14 != "" && m_Stone.Item14 != "" )
			{
				AddButton( 20, 320, 4005, 4007, 14, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 320, 1152, m_Stone.GumpName14 );
				AddLabel( 300, 320, 1152, ""+ m_Stone.Price14 );
			}

			if ( m_Stone.GumpName15 != null && m_Stone.Item15 != null && m_Stone.GumpName15 != "" && m_Stone.Item15 != "" )
			{
				AddButton( 20, 340, 4005, 4007, 15, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 340, 1152, m_Stone.GumpName15 );
				AddLabel( 300, 340, 1152, ""+ m_Stone.Price15 );
			}

			if ( m_Stone.GumpName16 != null && m_Stone.Item16 != null && m_Stone.GumpName16 != "" && m_Stone.Item16 != "" )
			{
				AddButton( 20, 360, 4005, 4007, 16, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 360, 1152, m_Stone.GumpName16 );
				AddLabel( 300, 360, 1152, ""+ m_Stone.Price16 );
			}

			if ( m_Stone.GumpName17 != null && m_Stone.Item17 != null && m_Stone.GumpName17 != "" && m_Stone.Item17 != "" )
			{
				AddButton( 20, 380, 4005, 4007, 17, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 380, 1152, m_Stone.GumpName17 );
				AddLabel( 300, 380, 1152, ""+ m_Stone.Price17 );
			}

			if ( m_Stone.GumpName18 != null && m_Stone.Item18 != null && m_Stone.GumpName18 != "" && m_Stone.Item18 != "" )
			{
				AddButton( 20, 400, 4005, 4007, 18, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 400, 1152, m_Stone.GumpName18 );
				AddLabel( 300, 400, 1152, ""+ m_Stone.Price18 );
			}

			if ( m_Stone.GumpName19 != null && m_Stone.Item19 != null && m_Stone.GumpName19 != "" && m_Stone.Item19 != "" )
			{
				AddButton( 20, 420, 4005, 4007, 19, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 420, 1152, m_Stone.GumpName19 );
				AddLabel( 300, 420, 1152, ""+ m_Stone.Price19 );
			}

			if ( m_Stone.GumpName20 != null && m_Stone.Item20 != null && m_Stone.GumpName20 != "" && m_Stone.Item20 != "" )
			{
				AddButton( 20, 440, 4005, 4007, 20, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 440, 1152, m_Stone.GumpName20 );
				AddLabel( 300, 440, 1152, ""+ m_Stone.Price20 );
			}

			AddLabel( 420, 260, 1152, "Page 2" ); 
			AddButton( 420, 280, 0x1196, 0x1196, 2, GumpButtonType.Page, 2 );

			AddPage( 2 ); 

			if ( m_Stone.GumpName21 != null && m_Stone.Item21 != null && m_Stone.GumpName21 != "" && m_Stone.Item21 != "" )
			{
				AddButton( 20, 60, 4005, 4007, 21, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 60, 1152, m_Stone.GumpName21 );
				AddLabel( 300, 60, 1152, ""+ m_Stone.Price21 );
			}

			if ( m_Stone.GumpName22 != null && m_Stone.Item22 != null && m_Stone.GumpName22 != "" && m_Stone.Item22 != "" )
			{
				AddButton( 20, 80, 4005, 4007, 22, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 80, 1152, m_Stone.GumpName22 );
				AddLabel( 300, 80, 1152, ""+ m_Stone.Price22 );
			}

			if ( m_Stone.GumpName23 != null && m_Stone.Item23 != null && m_Stone.GumpName23 != "" && m_Stone.Item23 != "" )
			{
				AddButton( 20, 100, 4005, 4007, 23, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 100, 1152, m_Stone.GumpName23 );
				AddLabel( 300, 100, 1152, ""+ m_Stone.Price23 );
			}

			if ( m_Stone.GumpName24 != null && m_Stone.Item24 != null && m_Stone.GumpName24 != "" && m_Stone.Item24 != "" )
			{
				AddButton( 20, 120, 4005, 4007, 24, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 120, 1152, m_Stone.GumpName24 );
				AddLabel( 300, 120, 1152, ""+ m_Stone.Price24 );
			}

			if ( m_Stone.GumpName25 != null && m_Stone.Item25 != null && m_Stone.GumpName25 != "" && m_Stone.Item25 != "" )
			{
				AddButton( 20, 140, 4005, 4007, 25, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 140, 1152, m_Stone.GumpName25 );
				AddLabel( 300, 140, 1152, ""+ m_Stone.Price25 );
			}

			if ( m_Stone.GumpName26 != null && m_Stone.Item26 != null && m_Stone.GumpName26 != "" && m_Stone.Item26 != "" )
			{
				AddButton( 20, 160, 4005, 4007, 26, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 160, 1152, m_Stone.GumpName26 );
				AddLabel( 300, 160, 1152, ""+ m_Stone.Price26 );
			}

			if ( m_Stone.GumpName27 != null && m_Stone.Item27 != null && m_Stone.GumpName27 != "" && m_Stone.Item27 != "" )
			{
				AddButton( 20, 180, 4005, 4007, 27, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 180, 1152, m_Stone.GumpName27 );
				AddLabel( 300, 180, 1152, ""+ m_Stone.Price27 );
			}

			if ( m_Stone.GumpName28 != null && m_Stone.Item28 != null && m_Stone.GumpName28 != "" && m_Stone.Item28 != "" )
			{
				AddButton( 20, 200, 4005, 4007, 28, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 200, 1152, m_Stone.GumpName28 );
				AddLabel( 300, 200, 1152, ""+ m_Stone.Price28 );
			}

			if ( m_Stone.GumpName29 != null && m_Stone.Item29 != null && m_Stone.GumpName29 != "" && m_Stone.Item29 != "" )
			{
				AddButton( 20, 220, 4005, 4007, 29, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 220, 1152, m_Stone.GumpName29 );
				AddLabel( 300, 220, 1152, ""+ m_Stone.Price29 );
			}

			if ( m_Stone.GumpName30 != null && m_Stone.Item30 != null && m_Stone.GumpName30 != "" && m_Stone.Item30 != "" )
			{
				AddButton( 20, 240, 4005, 4007, 30, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 240, 1152, m_Stone.GumpName30 );
				AddLabel( 300, 240, 1152, ""+ m_Stone.Price30 );
			}

			if ( m_Stone.GumpName31 != null && m_Stone.Item31 != null && m_Stone.GumpName31 != "" && m_Stone.Item31 != "" )
			{
				AddButton( 20, 260, 4005, 4007, 31, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 260, 1152, m_Stone.GumpName31 );
				AddLabel( 300, 260, 1152, ""+ m_Stone.Price31 );
			}

			if ( m_Stone.GumpName32 != null && m_Stone.Item32 != null && m_Stone.GumpName32 != "" && m_Stone.Item32 != "" )
			{
				AddButton( 20, 280, 4005, 4007, 32, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 280, 1152, m_Stone.GumpName32 );
				AddLabel( 300, 280, 1152, ""+ m_Stone.Price32 );
			}

			if ( m_Stone.GumpName33 != null && m_Stone.Item33 != null && m_Stone.GumpName33 != "" && m_Stone.Item33 != "" )
			{
				AddButton( 20, 300, 4005, 4007, 33, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 300, 1152, m_Stone.GumpName33 );
				AddLabel( 300, 300, 1152, ""+ m_Stone.Price33 );
			}

			if ( m_Stone.GumpName34 != null && m_Stone.Item34 != null && m_Stone.GumpName34 != "" && m_Stone.Item34 != "" )
			{
				AddButton( 20, 320, 4005, 4007, 34, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 320, 1152, m_Stone.GumpName34 );
				AddLabel( 300, 320, 1152, ""+ m_Stone.Price34 );
			}

			if ( m_Stone.GumpName35 != null && m_Stone.Item35 != null && m_Stone.GumpName35 != "" && m_Stone.Item35 != "" )
			{
				AddButton( 20, 340, 4005, 4007, 35, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 340, 1152, m_Stone.GumpName35 );
				AddLabel( 300, 340, 1152, ""+ m_Stone.Price35 );
			}

			if ( m_Stone.GumpName36 != null && m_Stone.Item36 != null && m_Stone.GumpName36 != "" && m_Stone.Item36 != "" )
			{
				AddButton( 20, 360, 4005, 4007, 36, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 360, 1152, m_Stone.GumpName36 );
				AddLabel( 300, 360, 1152, ""+ m_Stone.Price36 );
			}

			if ( m_Stone.GumpName37 != null && m_Stone.Item37 != null && m_Stone.GumpName37 != "" && m_Stone.Item37 != "" )
			{
				AddButton( 20, 380, 4005, 4007, 37, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 380, 1152, m_Stone.GumpName37 );
				AddLabel( 300, 380, 1152, ""+ m_Stone.Price37 );
			}

			if ( m_Stone.GumpName38 != null && m_Stone.Item38 != null && m_Stone.GumpName38 != "" && m_Stone.Item38 != "" )
			{
				AddButton( 20, 400, 4005, 4007, 38, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 400, 1152, m_Stone.GumpName38 );
				AddLabel( 300, 400, 1152, ""+ m_Stone.Price38 );
			}

			if ( m_Stone.GumpName39 != null && m_Stone.Item39 != null && m_Stone.GumpName39 != "" && m_Stone.Item39 != "" )
			{
				AddButton( 20, 420, 4005, 4007, 39, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 420, 1152, m_Stone.GumpName39 );
				AddLabel( 300, 420, 1152, ""+ m_Stone.Price39 );
			}

			if ( m_Stone.GumpName40 != null && m_Stone.Item40 != null && m_Stone.GumpName40 != "" && m_Stone.Item40 != "" )
			{
				AddButton( 20, 440, 4005, 4007, 40, GumpButtonType.Reply, 0 ); 
				AddLabel( 50, 440, 1152, m_Stone.GumpName40 );
				AddLabel( 300, 440, 1152, ""+ m_Stone.Price40 );
			}

			AddLabel( 420, 260, 1152, "Page 1" ); 
			AddButton( 420, 280, 0x119a, 0x119a, 1, GumpButtonType.Page, 1 );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{ 
			Mobile from = state.Mobile;

			if ( m_Stone.Deleted )
				return;

			m_SubmitData[0] = info.IsSwitched( 1 );
			m_SubmitData[1] = info.IsSwitched( 2 );
			m_SubmitData[2] = info.IsSwitched( 3 );

			m_Stone.Hued = (bool)m_SubmitData[0];
			m_Stone.Blessed = (bool)m_SubmitData[1];
			m_Stone.Bonded = (bool)m_SubmitData[2];
 
			switch ( info.ButtonID ) 
			{ 
				case 0:
				{
					from.SendMessage( "You decide not to buy anything." );
					m_Stone.Hued = false;
					m_Stone.Blessed = false;
					m_Stone.Bonded = false;
					break; 
				}
				case 1:
				{
					if ( m_Stone.Item1 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price1, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item1 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price1, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item1 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 2:
				{
					if ( m_Stone.Item2 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price2, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item2 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price2, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item2 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 3:
				{
					if ( m_Stone.Item3 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price3, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item3 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price3, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item3 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 4:
				{
					if ( m_Stone.Item4 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price4, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item4 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price4, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item4 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 5:
				{
					if ( m_Stone.Item5 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price5, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item5 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price5, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item5 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 6:
				{
					if ( m_Stone.Item6 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price6, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item6 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price6, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item6 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 7:
				{
					if ( m_Stone.Item7 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price7, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item7 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price7, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item7 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 8:
				{
					if ( m_Stone.Item8 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price8, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item8 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price8, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item8 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 9:
				{
					if ( m_Stone.Item9 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price9, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item9 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price9, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item9 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 10:
				{
					if ( m_Stone.Item10 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price10, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item10 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price10, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item10 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 11:
				{
					if ( m_Stone.Item11 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price11, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item11 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price11, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item11 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 12:
				{
					if ( m_Stone.Item12 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price12, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item12 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price12, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item12 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 13:
				{
					if ( m_Stone.Item13 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price13, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item13 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price13, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item13 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 14:
				{
					if ( m_Stone.Item14 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price14, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item14 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price14, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item14 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 15:
				{
					if ( m_Stone.Item15 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price15, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item15 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price15, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item15 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 16:
				{
					if ( m_Stone.Item16 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price16, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item16 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price16, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item16 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 17:
				{
					if ( m_Stone.Item17 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price17, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item17 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price17, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item17 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 18:
				{
					if ( m_Stone.Item18 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price18, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item18 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price18, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item18 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 19:
				{
					if ( m_Stone.Item19 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price19, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item19 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price19, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item19 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 20:
				{
					if ( m_Stone.Item20 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price20, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item20 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price20, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item20 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 21:
				{
					if ( m_Stone.Item21 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price21, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item21 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price21, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item21 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 22:
				{
					if ( m_Stone.Item22 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price22, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item22 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price22, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item22 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 23:
				{
					if ( m_Stone.Item23 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price23, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item23 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price23, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item23 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 24:
				{
					if ( m_Stone.Item24 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price24, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item24 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price24, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item24 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 25:
				{
					if ( m_Stone.Item25 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price25, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item25 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price25, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item25 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 26:
				{
					if ( m_Stone.Item26 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price26, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item26 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price26, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item26 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 27:
				{
					if ( m_Stone.Item27 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price27, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item27 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price27, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item27 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 28:
				{
					if ( m_Stone.Item28 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price28, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item28 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price28, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item28 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 29:
				{
					if ( m_Stone.Item29 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price29, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item29 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price29, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item29 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 30:
				{
					if ( m_Stone.Item30 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price30, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item30 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price30, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item30 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 31:
				{
					if ( m_Stone.Item31 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price31, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item31 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price31, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item31 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 32:
				{
					if ( m_Stone.Item32 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price32, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item32 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price32, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item32 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 33:
				{
					if ( m_Stone.Item33 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price33, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item33 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price33, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item33 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 34:
				{
					if ( m_Stone.Item34 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price34, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item34 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price34, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item34 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 35:
				{
					if ( m_Stone.Item35 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price35, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item35 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price35, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item35 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 36:
				{
					if ( m_Stone.Item36 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price36, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item36 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price36, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item36 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 37:
				{
					if ( m_Stone.Item37 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price37, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item37 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price37, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item37 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 38:
				{
					if ( m_Stone.Item38 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price38, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item38 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price38, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item38 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 39:
				{
					if ( m_Stone.Item39 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price39, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item39 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price39, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item39 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 40:
				{
					if ( m_Stone.Item40 == null )
						return;

					if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.Price40, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item40 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else if ( from.BankBox.ConsumeTotal( m_Stone.Currency, m_Stone.Price40, true ) )
					{
						try
						{
							Type type = VendorType.GetType( m_Stone.Item40 );
							if ( type != null )
							{
								try
								{
									object o = Activator.CreateInstance( type );

									if ( o is Mobile )
									{
										Mobile m = (Mobile)o;

										m.Map = from.Map;
										m.Location = from.Location;
										if ( m is BaseCreature )
										{
											BaseCreature c = (BaseCreature)m;
											c.ControlMaster = from;
											c.Controlled = true;
											c.ControlOrder = OrderType.Follow;
											c.ControlTarget = from;
											if ( m_Stone.Bonded == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BondedPrice, true ) )
												{
													c.IsBonded = true;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bond the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to bond the creature." );
												}
											}
											if ( m_Stone.Hued == true )
											{
												if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
												{
													from.SendHuePicker( new CreatureHuePicker( c, this ) );
													m_Stone.Hued = false;
													m_Stone.Blessed = false;
												}
												else
												{
													if ( m_Stone.Currency.Name != null )
														from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the creature." );
													else
														from.SendMessage( "You do not have enough of this stone's currency to hue the creature." );
												}
											}

											if ( c.Name != null )
												from.SendMessage( "You have bought "+ c.Name +"." );
											else
												from.SendMessage( "You have bought a creature" );
										}
									}
									if ( o is Item )
									{
										Item item = (Item)o;
										if ( m_Stone.Blessed == true )
										{
											if ( item.LootType == LootType.Blessed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item already comes blessed." );
											}
											else if ( item.LootType == LootType.Cursed )
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												from.SendMessage( "This item is of the loot type 'cursed' you may not bless it." );
											}
											else if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.BlessedPrice, true ) )
											{
												item.LootType = LootType.Blessed;
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;
											}
											else
											{
												m_Stone.Blessed = false;
												m_Stone.Bonded = false;

												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to bless the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to bless the item." );
											}
										}
										if ( m_Stone.Hued == true )
										{
											if ( from.Backpack.ConsumeTotal( m_Stone.Currency, m_Stone.HuedPrice, true ) )
											{
												from.SendHuePicker( new ItemHuePicker( item, this ) );
												m_Stone.Hued = false;
												m_Stone.Bonded = false;
											}
											else
											{
												if ( m_Stone.Currency.Name != null )
													from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" to hue the item." );
												else
													from.SendMessage( "You do not have enough of this stone's currency to hue the item." );
											}
										}

										from.Backpack.DropItem( item );

										if ( item.Name != null )
											from.SendMessage( "You have bought "+ item.Name +"." );
										else
											from.SendMessage( "You have bought an item." );
									}
								}
								catch
								{
									from.SendMessage( "This item doesn't seem to be constructable, please call the shard staff to come and fix this problem." );
								}
							}
						}
						catch
						{
							from.SendMessage( "This is not an item, please call the shard staff to come and fix this problem." );
						}
					}
					else
					{
						if ( m_Stone.Currency.Name != null )
							from.SendMessage( "You do not have enough "+ m_Stone.Currency.Name +" for that." );
						else
							from.SendMessage( "You do not have enough of this stone's currency for that." );
					}
					break; 
				}
				case 41:
				{
					from.SendGump( new EditVendorGump( from, m_Stone ) );
					break; 
				}
			}
		}
		private class ItemHuePicker : HuePickers.HuePicker
		{
			private Item m_Item;
			private VendorGump m_Gump;

			public ItemHuePicker( Item item, VendorGump gump ) : base( 0x1018 )
			{
				m_Item = item;
				m_Gump = gump;
			}

			public override void OnResponse( int hue )
			{
				if ( m_Item != null )
					m_Item.Hue = hue;
			}
		}
		private class CreatureHuePicker : HuePickers.HuePicker
		{
			private BaseCreature m_Creature;
			private VendorGump m_Gump;

			public CreatureHuePicker( BaseCreature creature, VendorGump gump ) : base( 0x1018 )
			{
				m_Creature = creature;
				m_Gump = gump;
			}

			public override void OnResponse( int hue )
			{
				if ( m_Creature != null )
					m_Creature.Hue = hue;
			}
		}
	}

	public class EditVendorGump : Gump
	{
                private VendorStone m_Stone;

                public EditVendorGump( Mobile from, VendorStone stone ) : base( 25, 25 )
                {
			m_Stone = stone;

			from.CloseGump( typeof( VendorGump ) );
			from.CloseGump( typeof( EditVendorGump ) );

			AddPage( 0 ); 
			AddBackground( 0, 0, 530, 480, 5054 );
			AddAlphaRegion( 10, 10, 510, 460 );

			AddImageTiled( 10, 40, 510, 5, 2624 );
			AddImageTiled( 400, 40, 5, 430, 2624 );
			AddImageTiled( 90, 40, 5, 430, 2624 );
			AddImageTiled( 310, 40, 5, 430, 2624 );
			AddImageTiled( 10, 58, 390, 5, 2624 );

			AddImageTiled( 10, 80, 390, 3, 2624 );
			AddImageTiled( 10, 100, 390, 3, 2624 );
			AddImageTiled( 10, 120, 390, 3, 2624 );
			AddImageTiled( 10, 140, 390, 3, 2624 );

			AddImageTiled( 10, 160, 510, 3, 2624 );
			AddImageTiled( 10, 180, 510, 3, 2624 );
			AddImageTiled( 10, 200, 510, 3, 2624 );
			AddImageTiled( 10, 220, 510, 3, 2624 );

			AddImageTiled( 10, 240, 390, 3, 2624 );
			AddImageTiled( 10, 260, 390, 3, 2624 );
			AddImageTiled( 10, 280, 390, 3, 2624 );
			AddImageTiled( 10, 300, 390, 3, 2624 );
			AddImageTiled( 10, 320, 390, 3, 2624 );
			AddImageTiled( 10, 340, 390, 3, 2624 );
			AddImageTiled( 10, 360, 390, 3, 2624 );
			AddImageTiled( 10, 380, 390, 3, 2624 );
			AddImageTiled( 10, 400, 390, 3, 2624 );
			AddImageTiled( 10, 420, 390, 3, 2624 );
			AddImageTiled( 10, 440, 390, 3, 2624 );

			AddImageTiled( 230, 10, 3, 30, 2624 );
			AddImageTiled( 340, 10, 3, 30, 2624 );

			AddTextEntry( 235, 20, 100, 15, 1152, 123, m_Stone.Name );

			AddLabel( 420, 60, 5, "Stone Currency:" );
			if ( m_Stone.Currency != null )
			{
				if ( m_Stone.Currency.Name != null )
				{
					AddLabel( 420, 80, 5, m_Stone.Currency.Name );
				}
				else
				{
					AddLabel( 420, 80, 33, ""+ m_Stone.Currency );
				}
			}
			else
			{
				AddLabel( 420, 80, 33, "None" );
			}

			AddLabel( 420, 360, 906, "Created By" );
			AddLabel( 420, 380, 906, "~Raelis~" );

			AddButton( 420, 440, 4005, 4007, 0, GumpButtonType.Reply, 0 ); 
			AddLabel( 450, 440, 33, "Close" );

			AddLabel( 420, 160, 1152, "Hue: " );
			AddTextEntry( 460, 160, 60, 15, 1152, 120, m_Stone.HuedPrice.ToString() );

			AddLabel( 420, 180, 1152, "Bless: " );
			AddTextEntry( 460, 180, 60, 15, 1152, 121, m_Stone.BlessedPrice.ToString() );

			AddLabel( 420, 200, 1152, "Bond: " );
			AddTextEntry( 460, 200, 60, 15, 1152, 122, m_Stone.BondedPrice.ToString() );

			AddButton( 420, 320, 0xFB7, 0xFB9, 1, GumpButtonType.Reply, 0 ); 
			AddButton( 420, 340, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0 );

			AddLabel( 20, 42, 1152, "Item Name" );
			AddLabel( 170, 42, 1152, "Gump Name" );
			AddLabel( 340, 42, 1152, "Price" );

			AddPage( 1 ); 

			AddTextEntry( 10, 60, 70, 15, 5, 0, m_Stone.Item1 );
			AddTextEntry( 100, 60, 200, 15, 65, 1, m_Stone.GumpName1 );
			AddTextEntry( 320, 60, 60, 15, 34, 2, m_Stone.Price1.ToString() );

			AddTextEntry( 10, 80, 70, 15, 5, 3, m_Stone.Item2 );
			AddTextEntry( 100, 80, 200, 15, 65, 4, m_Stone.GumpName2 );
			AddTextEntry( 320, 80, 60, 15, 34, 5, m_Stone.Price2.ToString() );

			AddTextEntry( 10, 100, 70, 15, 5, 6, m_Stone.Item3 );
			AddTextEntry( 100, 100, 200, 15, 65, 7, m_Stone.GumpName3 );
			AddTextEntry( 320, 100, 60, 15, 34, 8, m_Stone.Price3.ToString() );

			AddTextEntry( 10, 120, 70, 15, 5, 9, m_Stone.Item4 );
			AddTextEntry( 100, 120, 200, 15, 65, 10, m_Stone.GumpName4 );
			AddTextEntry( 320, 120, 60, 15, 34, 11, m_Stone.Price4.ToString() );

			AddTextEntry( 10, 140, 70, 15, 5, 12, m_Stone.Item5 );
			AddTextEntry( 100, 140, 200, 15, 65, 13, m_Stone.GumpName5 );
			AddTextEntry( 320, 140, 60, 15, 34, 14, m_Stone.Price5.ToString() );

			AddTextEntry( 10, 160, 70, 15, 5, 15, m_Stone.Item6 );
			AddTextEntry( 100, 160, 200, 15, 65, 16, m_Stone.GumpName6 );
			AddTextEntry( 320, 160, 60, 15, 34, 17, m_Stone.Price6.ToString() );

			AddTextEntry( 10, 180, 70, 15, 5, 18, m_Stone.Item7 );
			AddTextEntry( 100, 180, 200, 15, 65, 19, m_Stone.GumpName7 );
			AddTextEntry( 320, 180, 60, 15, 34, 20, m_Stone.Price7.ToString() );

			AddTextEntry( 10, 200, 70, 15, 5, 21, m_Stone.Item8 );
			AddTextEntry( 100, 200, 200, 15, 65, 22, m_Stone.GumpName8 );
			AddTextEntry( 320, 200, 60, 15, 34, 23, m_Stone.Price8.ToString() );

			AddTextEntry( 10, 220, 70, 15, 5, 24, m_Stone.Item9 );
			AddTextEntry( 100, 220, 200, 15, 65, 25, m_Stone.GumpName9 );
			AddTextEntry( 320, 220, 60, 15, 34, 26, m_Stone.Price9.ToString() );

			AddTextEntry( 10, 240, 70, 15, 5, 27, m_Stone.Item10 );
			AddTextEntry( 100, 240, 200, 15, 65, 28, m_Stone.GumpName10 );
			AddTextEntry( 320, 240, 60, 15, 34, 29, m_Stone.Price10.ToString() );

			AddTextEntry( 10, 260, 70, 15, 5, 30, m_Stone.Item11 );
			AddTextEntry( 100, 260, 200, 15, 65, 31, m_Stone.GumpName11 );
			AddTextEntry( 320, 260, 60, 15, 34, 32, m_Stone.Price11.ToString() );

			AddTextEntry( 10, 280, 70, 15, 5, 33, m_Stone.Item12 );
			AddTextEntry( 100, 280, 200, 15, 65, 34, m_Stone.GumpName12 );
			AddTextEntry( 320, 280, 60, 15, 34, 35, m_Stone.Price12.ToString() );

			AddTextEntry( 10, 300, 70, 15, 5, 36, m_Stone.Item13 );
			AddTextEntry( 100, 300, 200, 15, 65, 37, m_Stone.GumpName13 );
			AddTextEntry( 320, 300, 60, 15, 34, 38, m_Stone.Price13.ToString() );

			AddTextEntry( 10, 320, 70, 15, 5, 39, m_Stone.Item14 );
			AddTextEntry( 100, 320, 200, 15, 65, 40, m_Stone.GumpName14 );
			AddTextEntry( 320, 320, 60, 15, 34, 41, m_Stone.Price14.ToString() );

			AddTextEntry( 10, 340, 70, 15, 5, 42, m_Stone.Item15 );
			AddTextEntry( 100, 340, 200, 15, 65, 43, m_Stone.GumpName15 );
			AddTextEntry( 320, 340, 60, 15, 34, 44, m_Stone.Price15.ToString() );

			AddTextEntry( 10, 360, 70, 15, 5, 45, m_Stone.Item16 );
			AddTextEntry( 100, 360, 200, 15, 65, 46, m_Stone.GumpName16 );
			AddTextEntry( 320, 360, 60, 15, 34, 47, m_Stone.Price16.ToString() );

			AddTextEntry( 10, 380, 70, 15, 5, 48, m_Stone.Item17 );
			AddTextEntry( 100, 380, 200, 15, 65, 49, m_Stone.GumpName17 );
			AddTextEntry( 320, 380, 60, 15, 34, 50, m_Stone.Price17.ToString() );

			AddTextEntry( 10, 400, 70, 15, 5, 51, m_Stone.Item18 );
			AddTextEntry( 100, 400, 200, 15, 65, 52, m_Stone.GumpName18 );
			AddTextEntry( 320, 400, 60, 15, 34, 53, m_Stone.Price18.ToString() );

			AddTextEntry( 10, 420, 70, 15, 5, 54, m_Stone.Item19 );
			AddTextEntry( 100, 420, 200, 15, 65, 55, m_Stone.GumpName19 );
			AddTextEntry( 320, 420, 60, 15, 34, 56, m_Stone.Price19.ToString() );

			AddTextEntry( 10, 440, 70, 15, 5, 57, m_Stone.Item20 );
			AddTextEntry( 100, 440, 200, 15, 65, 58, m_Stone.GumpName20 );
			AddTextEntry( 320, 440, 60, 15, 34, 59, m_Stone.Price20.ToString() );

			AddLabel( 420, 260, 1152, "Page 2" ); 
			AddButton( 420, 280, 0x1196, 0x1196, 2, GumpButtonType.Page, 2 );


			AddPage( 2 ); 

			AddTextEntry( 10, 60, 70, 15, 5, 60, m_Stone.Item21 );
			AddTextEntry( 100, 60, 200, 15, 65, 61, m_Stone.GumpName21 );
			AddTextEntry( 320, 60, 60, 15, 34, 62, m_Stone.Price21.ToString() );

			AddTextEntry( 10, 80, 70, 15, 5, 63, m_Stone.Item22 );
			AddTextEntry( 100, 80, 200, 15, 65, 64, m_Stone.GumpName22 );
			AddTextEntry( 320, 80, 60, 15, 34, 65, m_Stone.Price22.ToString() );

			AddTextEntry( 10, 100, 70, 15, 5, 66, m_Stone.Item23 );
			AddTextEntry( 100, 100, 200, 15, 65, 67, m_Stone.GumpName23 );
			AddTextEntry( 320, 100, 60, 15, 34, 68, m_Stone.Price23.ToString() );

			AddTextEntry( 10, 120, 70, 15, 5, 69, m_Stone.Item24 );
			AddTextEntry( 100, 120, 200, 15, 65, 70, m_Stone.GumpName24 );
			AddTextEntry( 320, 120, 60, 15, 34, 71, m_Stone.Price24.ToString() );

			AddTextEntry( 10, 140, 70, 15, 5, 72, m_Stone.Item25 );
			AddTextEntry( 100, 140, 200, 15, 65, 73, m_Stone.GumpName25 );
			AddTextEntry( 320, 140, 60, 15, 34, 74, m_Stone.Price25.ToString() );

			AddTextEntry( 10, 160, 70, 15, 5, 75, m_Stone.Item26 );
			AddTextEntry( 100, 160, 200, 15, 65, 76, m_Stone.GumpName26 );
			AddTextEntry( 320, 160, 60, 15, 34, 77, m_Stone.Price26.ToString() );

			AddTextEntry( 10, 180, 70, 15, 5, 78, m_Stone.Item27 );
			AddTextEntry( 100, 180, 200, 15, 65, 79, m_Stone.GumpName27 );
			AddTextEntry( 320, 180, 60, 15, 34, 80, m_Stone.Price27.ToString() );

			AddTextEntry( 10, 200, 70, 15, 5, 81, m_Stone.Item28 );
			AddTextEntry( 100, 200, 200, 15, 65, 82, m_Stone.GumpName28 );
			AddTextEntry( 320, 200, 60, 15, 34, 83, m_Stone.Price28.ToString() );

			AddTextEntry( 10, 220, 70, 15, 5, 84, m_Stone.Item29 );
			AddTextEntry( 100, 220, 200, 15, 65, 85, m_Stone.GumpName29 );
			AddTextEntry( 320, 220, 60, 15, 34, 86, m_Stone.Price29.ToString() );

			AddTextEntry( 10, 240, 70, 15, 5, 87, m_Stone.Item30 );
			AddTextEntry( 100, 240, 200, 15, 65, 88, m_Stone.GumpName30 );
			AddTextEntry( 320, 240, 60, 15, 34, 89, m_Stone.Price30.ToString() );

			AddTextEntry( 10, 260, 70, 15, 5, 90, m_Stone.Item31 );
			AddTextEntry( 100, 260, 200, 15, 65, 91, m_Stone.GumpName31 );
			AddTextEntry( 320, 260, 60, 15, 34, 92, m_Stone.Price31.ToString() );

			AddTextEntry( 10, 280, 70, 15, 5, 93, m_Stone.Item32 );
			AddTextEntry( 100, 280, 200, 15, 65, 94, m_Stone.GumpName32 );
			AddTextEntry( 320, 280, 60, 15, 34, 95, m_Stone.Price32.ToString() );

			AddTextEntry( 10, 300, 70, 15, 5, 96, m_Stone.Item33 );
			AddTextEntry( 100, 300, 200, 15, 65, 97, m_Stone.GumpName33 );
			AddTextEntry( 320, 300, 60, 15, 34, 98, m_Stone.Price33.ToString() );

			AddTextEntry( 10, 320, 70, 15, 5, 99, m_Stone.Item34 );
			AddTextEntry( 100, 320, 200, 15, 65, 100, m_Stone.GumpName34 );
			AddTextEntry( 320, 320, 60, 15, 34, 101, m_Stone.Price34.ToString() );

			AddTextEntry( 10, 340, 70, 15, 5, 102, m_Stone.Item35 );
			AddTextEntry( 100, 340, 200, 15, 65, 103, m_Stone.GumpName35 );
			AddTextEntry( 320, 340, 60, 15, 34, 104, m_Stone.Price35.ToString() );

			AddTextEntry( 10, 360, 70, 15, 5, 105, m_Stone.Item36 );
			AddTextEntry( 100, 360, 200, 15, 65, 106, m_Stone.GumpName36 );
			AddTextEntry( 320, 360, 60, 15, 34, 107, m_Stone.Price36.ToString() );

			AddTextEntry( 10, 380, 70, 15, 5, 108, m_Stone.Item37 );
			AddTextEntry( 100, 380, 200, 15, 65, 109, m_Stone.GumpName37 );
			AddTextEntry( 320, 380, 60, 15, 34, 110, m_Stone.Price37.ToString() );

			AddTextEntry( 10, 400, 70, 15, 5, 111, m_Stone.Item38 );
			AddTextEntry( 100, 400, 200, 15, 65, 112, m_Stone.GumpName38 );
			AddTextEntry( 320, 400, 60, 15, 34, 113, m_Stone.Price38.ToString() );

			AddTextEntry( 10, 420, 70, 15, 5, 114, m_Stone.Item39 );
			AddTextEntry( 100, 420, 200, 15, 65, 115, m_Stone.GumpName39 );
			AddTextEntry( 320, 420, 60, 15, 34, 116, m_Stone.Price39.ToString() );

			AddTextEntry( 10, 440, 70, 15, 5, 117, m_Stone.Item40 );
			AddTextEntry( 100, 440, 200, 15, 65, 118, m_Stone.GumpName40 );
			AddTextEntry( 320, 440, 60, 15, 34, 119, m_Stone.Price40.ToString() );

			AddLabel( 420, 260, 1152, "Page 1" ); 
			AddButton( 420, 280, 0x119a, 0x119a, 1, GumpButtonType.Page, 1 );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{ 
			Mobile from = state.Mobile;

			if ( m_Stone.Deleted )
				return;
 
			switch ( info.ButtonID ) 
			{ 
				case 0:
				{
					from.SendMessage( "You decide not to edit the stone." );
					break; 
				}
				case 1:
				{
					string item1 = "";
					string gname1 = ""; 
					int price1 = 0; 
					string item2 = "";
					string gname2 = ""; 
					int price2 = 0; 
					string item3 = "";
					string gname3 = ""; 
					int price3 = 0; 
					string item4 = "";
					string gname4 = ""; 
					int price4 = 0; 
					string item5 = "";
					string gname5 = ""; 
					int price5 = 0; 
					string item6 = "";
					string gname6 = ""; 
					int price6 = 0; 
					string item7 = "";
					string gname7 = ""; 
					int price7 = 0; 
					string item8 = "";
					string gname8 = ""; 
					int price8 = 0; 
					string item9 = "";
					string gname9 = ""; 
					int price9 = 0; 
					string item10 = "";
					string gname10 = ""; 
					int price10 = 0; 
					string item11 = "";
					string gname11 = ""; 
					int price11 = 0; 
					string item12 = "";
					string gname12 = ""; 
					int price12 = 0; 
					string item13 = "";
					string gname13 = ""; 
					int price13 = 0; 
					string item14 = "";
					string gname14 = ""; 
					int price14 = 0; 
					string item15 = "";
					string gname15 = ""; 
					int price15 = 0; 
					string item16 = "";
					string gname16 = ""; 
					int price16 = 0; 
					string item17 = "";
					string gname17 = ""; 
					int price17 = 0; 
					string item18 = "";
					string gname18 = ""; 
					int price18 = 0; 
					string item19 = "";
					string gname19 = ""; 
					int price19 = 0; 
					string item20 = "";
					string gname20 = ""; 
					int price20 = 0; 
					string item21 = "";
					string gname21 = ""; 
					int price21 = 0; 
					string item22 = "";
					string gname22 = ""; 
					int price22 = 0; 
					string item23 = "";
					string gname23 = ""; 
					int price23 = 0; 
					string item24 = "";
					string gname24 = ""; 
					int price24 = 0; 
					string item25 = "";
					string gname25 = ""; 
					int price25 = 0; 
					string item26 = "";
					string gname26 = ""; 
					int price26 = 0; 
					string item27 = "";
					string gname27 = ""; 
					int price27 = 0; 
					string item28 = "";
					string gname28 = ""; 
					int price28 = 0; 
					string item29 = "";
					string gname29 = ""; 
					int price29 = 0; 
					string item30 = "";
					string gname30 = ""; 
					int price30 = 0; 
					string item31 = "";
					string gname31 = ""; 
					int price31 = 0; 
					string item32 = "";
					string gname32 = ""; 
					int price32 = 0; 
					string item33 = "";
					string gname33 = ""; 
					int price33 = 0; 
					string item34 = "";
					string gname34 = ""; 
					int price34 = 0; 
					string item35 = "";
					string gname35 = ""; 
					int price35 = 0; 
					string item36 = "";
					string gname36 = ""; 
					int price36 = 0; 
					string item37 = "";
					string gname37 = ""; 
					int price37 = 0; 
					string item38 = "";
					string gname38 = ""; 
					int price38 = 0; 
					string item39 = "";
					string gname39 = ""; 
					int price39 = 0; 
					string item40 = "";
					string gname40 = ""; 
					int price40 = 0; 

					string stonename = ""; 
					int huedprice = 0; 
					int blessedprice = 0; 
					int bondedprice = 0; 

					string[] tr = new string[ 124 ];

					foreach( TextRelay t in info.TextEntries )
					{
						tr[ t.EntryID ] = t.Text;
					}
					try { price1 = (int) uint.Parse( tr[ 2 ] ); } 
					catch {}
					try { price2 = (int) uint.Parse( tr[ 5 ] ); } 
					catch {}
					try { price3 = (int) uint.Parse( tr[ 8 ] ); } 
					catch {}
					try { price4 = (int) uint.Parse( tr[ 11 ] ); } 
					catch {}
					try { price5 = (int) uint.Parse( tr[ 14 ] ); } 
					catch {}
					try { price6 = (int) uint.Parse( tr[ 17 ] ); } 
					catch {}
					try { price7 = (int) uint.Parse( tr[ 20 ] ); } 
					catch {}
					try { price8 = (int) uint.Parse( tr[ 23 ] ); } 
					catch {}
					try { price9 = (int) uint.Parse( tr[ 26 ] ); } 
					catch {}
					try { price10 = (int) uint.Parse( tr[ 29 ] ); } 
					catch {}
					try { price11 = (int) uint.Parse( tr[ 32 ] ); } 
					catch {}
					try { price12 = (int) uint.Parse( tr[ 35 ] ); } 
					catch {}
					try { price13 = (int) uint.Parse( tr[ 38 ] ); } 
					catch {}
					try { price14 = (int) uint.Parse( tr[ 41 ] ); } 
					catch {}
					try { price15 = (int) uint.Parse( tr[ 44 ] ); } 
					catch {}
					try { price16 = (int) uint.Parse( tr[ 47 ] ); } 
					catch {}
					try { price17 = (int) uint.Parse( tr[ 50 ] ); } 
					catch {}
					try { price18 = (int) uint.Parse( tr[ 53 ] ); } 
					catch {}
					try { price19 = (int) uint.Parse( tr[ 56 ] ); } 
					catch {}
					try { price20 = (int) uint.Parse( tr[ 59 ] ); } 
					catch {}
					try { price21 = (int) uint.Parse( tr[ 62 ] ); } 
					catch {}
					try { price22 = (int) uint.Parse( tr[ 65 ] ); } 
					catch {}
					try { price23 = (int) uint.Parse( tr[ 68 ] ); } 
					catch {}
					try { price24 = (int) uint.Parse( tr[ 71 ] ); } 
					catch {}
					try { price25 = (int) uint.Parse( tr[ 74 ] ); } 
					catch {}
					try { price26 = (int) uint.Parse( tr[ 77 ] ); } 
					catch {}
					try { price27 = (int) uint.Parse( tr[ 80 ] ); } 
					catch {}
					try { price28 = (int) uint.Parse( tr[ 83 ] ); } 
					catch {}
					try { price29 = (int) uint.Parse( tr[ 86 ] ); } 
					catch {}
					try { price30 = (int) uint.Parse( tr[ 89 ] ); } 
					catch {}
					try { price31 = (int) uint.Parse( tr[ 92 ] ); } 
					catch {}
					try { price32 = (int) uint.Parse( tr[ 95 ] ); } 
					catch {}
					try { price33 = (int) uint.Parse( tr[ 98] ); } 
					catch {}
					try { price34 = (int) uint.Parse( tr[ 101 ] ); } 
					catch {}
					try { price35 = (int) uint.Parse( tr[ 104 ] ); } 
					catch {}
					try { price36 = (int) uint.Parse( tr[ 107 ] ); } 
					catch {}
					try { price37 = (int) uint.Parse( tr[ 110 ] ); } 
					catch {}
					try { price38 = (int) uint.Parse( tr[ 113 ] ); } 
					catch {}
					try { price39 = (int) uint.Parse( tr[ 116 ] ); } 
					catch {}
					try { price40 = (int) uint.Parse( tr[ 119 ] ); } 
					catch {}
					try { huedprice = (int) uint.Parse( tr[ 120 ] ); } 
					catch {}
					try { blessedprice = (int) uint.Parse( tr[ 121 ] ); } 
					catch {}
					try { bondedprice = (int) uint.Parse( tr[ 122 ] ); } 
					catch {}

					if ( tr[ 0 ] != null )
					{
						item1 = tr[ 0 ];
					}
					if ( tr[ 1 ] != null )
					{
						gname1 = tr[ 1 ];
					}
					if ( tr[ 3 ] != null )
					{
						item2 = tr[ 3 ];
					}
					if ( tr[ 4 ] != null )
					{
						gname2 = tr[ 4 ];
					}
					if ( tr[ 6 ] != null )
					{
						item3 = tr[ 6 ];
					}
					if ( tr[ 7 ] != null )
					{
						gname3 = tr[ 7 ];
					}
					if ( tr[ 9 ] != null )
					{
						item4 = tr[ 9 ];
					}
					if ( tr[ 10 ] != null )
					{
						gname4 = tr[ 10 ];
					}
					if ( tr[ 12 ] != null )
					{
						item5 = tr[ 12 ];
					}
					if ( tr[ 13 ] != null )
					{
						gname5 = tr[ 13 ];
					}
					if ( tr[ 15 ] != null )
					{
						item6 = tr[ 15 ];
					}
					if ( tr[ 16 ] != null )
					{
						gname6 = tr[ 16 ];
					}
					if ( tr[ 18 ] != null )
					{
						item7 = tr[ 18 ];
					}
					if ( tr[ 19 ] != null )
					{
						gname7 = tr[ 19 ];
					}
					if ( tr[ 21 ] != null )
					{
						item8 = tr[ 21 ];
					}
					if ( tr[ 22 ] != null )
					{
						gname8 = tr[ 22 ];
					}
					if ( tr[ 24 ] != null )
					{
						item9 = tr[ 24 ];
					}
					if ( tr[ 25 ] != null )
					{
						gname9 = tr[ 25 ];
					}
					if ( tr[ 27 ] != null )
					{
						item10 = tr[ 27 ];
					}
					if ( tr[ 28 ] != null )
					{
						gname10 = tr[ 28 ];
					}
					if ( tr[ 30 ] != null )
					{
						item11 = tr[ 30 ];
					}
					if ( tr[ 31 ] != null )
					{
						gname11 = tr[ 31 ];
					}
					if ( tr[ 33 ] != null )
					{
						item12 = tr[ 33 ];
					}
					if ( tr[ 34 ] != null )
					{
						gname12 = tr[ 34 ];
					}
					if ( tr[ 36 ] != null )
					{
						item13 = tr[ 36 ];
					}
					if ( tr[ 37 ] != null )
					{
						gname13 = tr[ 37 ];
					}
					if ( tr[ 39 ] != null )
					{
						item14 = tr[ 39 ];
					}
					if ( tr[ 40 ] != null )
					{
						gname14 = tr[ 40 ];
					}
					if ( tr[ 42 ] != null )
					{
						item15 = tr[ 42 ];
					}
					if ( tr[ 43 ] != null )
					{
						gname15 = tr[ 43 ];
					}
					if ( tr[ 45 ] != null )
					{
						item16 = tr[ 45 ];
					}
					if ( tr[ 46 ] != null )
					{
						gname16 = tr[ 46 ];
					}
					if ( tr[ 48 ] != null )
					{
						item17 = tr[ 48 ];
					}
					if ( tr[ 49 ] != null )
					{
						gname17 = tr[ 49 ];
					}
					if ( tr[ 51 ] != null )
					{
						item18 = tr[ 51 ];
					}
					if ( tr[ 52 ] != null )
					{
						gname18 = tr[ 52 ];
					}
					if ( tr[ 54 ] != null )
					{
						item19 = tr[ 54 ];
					}
					if ( tr[ 55 ] != null )
					{
						gname19 = tr[ 55 ];
					}
					if ( tr[ 57 ] != null )
					{
						item20 = tr[ 57 ];
					}
					if ( tr[ 58 ] != null )
					{
						gname20 = tr[ 58 ];
					}
					if ( tr[ 60 ] != null )
					{
						item21 = tr[ 60 ];
					}
					if ( tr[ 61 ] != null )
					{
						gname21 = tr[ 61 ];
					}
					if ( tr[ 63 ] != null )
					{
						item22 = tr[ 63 ];
					}
					if ( tr[ 64 ] != null )
					{
						gname22 = tr[ 64 ];
					}
					if ( tr[ 66 ] != null )
					{
						item23 = tr[ 66 ];
					}
					if ( tr[ 67 ] != null )
					{
						gname23 = tr[ 67 ];
					}
					if ( tr[ 69 ] != null )
					{
						item24 = tr[ 69 ];
					}
					if ( tr[ 70 ] != null )
					{
						gname24 = tr[ 70 ];
					}
					if ( tr[ 72 ] != null )
					{
						item25 = tr[ 72 ];
					}
					if ( tr[ 73 ] != null )
					{
						gname25 = tr[ 73 ];
					}
					if ( tr[ 75 ] != null )
					{
						item26 = tr[ 75 ];
					}
					if ( tr[ 76 ] != null )
					{
						gname26 = tr[ 76 ];
					}
					if ( tr[ 78 ] != null )
					{
						item27 = tr[ 78 ];
					}
					if ( tr[ 79 ] != null )
					{
						gname27 = tr[ 79 ];
					}
					if ( tr[ 81 ] != null )
					{
						item28 = tr[ 81 ];
					}
					if ( tr[ 82 ] != null )
					{
						gname28 = tr[ 82 ];
					}
					if ( tr[ 84 ] != null )
					{
						item29 = tr[ 84 ];
					}
					if ( tr[ 85 ] != null )
					{
						gname29 = tr[ 85 ];
					}
					if ( tr[ 87 ] != null )
					{
						item30 = tr[ 87 ];
					}
					if ( tr[ 88 ] != null )
					{
						gname30 = tr[ 88 ];
					}
					if ( tr[ 90 ] != null )
					{
						item31 = tr[ 90 ];
					}
					if ( tr[ 91 ] != null )
					{
						gname31 = tr[ 91 ];
					}
					if ( tr[ 93 ] != null )
					{
						item32 = tr[ 93 ];
					}
					if ( tr[ 94 ] != null )
					{
						gname32 = tr[ 94 ];
					}
					if ( tr[ 96 ] != null )
					{
						item33 = tr[ 96 ];
					}
					if ( tr[ 97 ] != null )
					{
						gname33 = tr[ 97 ];
					}
					if ( tr[ 99 ] != null )
					{
						item34 = tr[ 99 ];
					}
					if ( tr[ 100 ] != null )
					{
						gname34 = tr[ 100 ];
					}
					if ( tr[ 102 ] != null )
					{
						item35 = tr[ 102 ];
					}
					if ( tr[ 103 ] != null )
					{
						gname35 = tr[ 103 ];
					}
					if ( tr[ 105 ] != null )
					{
						item36 = tr[ 105 ];
					}
					if ( tr[ 106 ] != null )
					{
						gname36 = tr[ 106 ];
					}
					if ( tr[ 108 ] != null )
					{
						item37 = tr[ 108 ];
					}
					if ( tr[ 109 ] != null )
					{
						gname37 = tr[ 109 ];
					}
					if ( tr[ 111 ] != null )
					{
						item38 = tr[ 111 ];
					}
					if ( tr[ 112 ] != null )
					{
						gname38 = tr[ 112 ];
					}
					if ( tr[ 114 ] != null )
					{
						item39 = tr[ 114 ];
					}
					if ( tr[ 115 ] != null )
					{
						gname39 = tr[ 115 ];
					}
					if ( tr[ 117 ] != null )
					{
						item40 = tr[ 117 ];
					}
					if ( tr[ 118 ] != null )
					{
						gname40 = tr[ 118 ];
					}
					if ( tr[ 123 ] != null )
					{
						stonename = tr[ 123 ];
					}

						m_Stone.Item1 = item1;
						m_Stone.GumpName1 = gname1;
						m_Stone.Price1 = price1;
						m_Stone.Item2 = item2;
						m_Stone.GumpName2 = gname2;
						m_Stone.Price2 = price2;
						m_Stone.Item3 = item3;
						m_Stone.GumpName3 = gname3;
						m_Stone.Price3 = price3;
						m_Stone.Item4 = item4;
						m_Stone.GumpName4 = gname4;
						m_Stone.Price4 = price4;
						m_Stone.Item5 = item5;
						m_Stone.GumpName5 = gname5;
						m_Stone.Price5 = price5;
						m_Stone.Item6 = item6;
						m_Stone.GumpName6 = gname6;
						m_Stone.Price6 = price6;
						m_Stone.Item7 = item7;
						m_Stone.GumpName7 = gname7;
						m_Stone.Price7 = price7;
						m_Stone.Item8 = item8;
						m_Stone.GumpName8 = gname8;
						m_Stone.Price8 = price8;
						m_Stone.Item9 = item9;
						m_Stone.GumpName9 = gname9;
						m_Stone.Price9 = price9;
						m_Stone.Item10 = item10;
						m_Stone.GumpName10 = gname10;
						m_Stone.Price10 = price10;
						m_Stone.Item11 = item11;
						m_Stone.GumpName11 = gname11;
						m_Stone.Price11 = price11;
						m_Stone.Item12 = item12;
						m_Stone.GumpName12 = gname12;
						m_Stone.Price12 = price12;
						m_Stone.Item13 = item13;
						m_Stone.GumpName13 = gname13;
						m_Stone.Price13 = price13;
						m_Stone.Item14 = item14;
						m_Stone.GumpName14 = gname14;
						m_Stone.Price14 = price14;
						m_Stone.Item15 = item15;
						m_Stone.GumpName15 = gname15;
						m_Stone.Price15 = price15;
						m_Stone.Item16 = item16;
						m_Stone.GumpName16 = gname16;
						m_Stone.Price16 = price16;
						m_Stone.Item17 = item17;
						m_Stone.GumpName17 = gname17;
						m_Stone.Price17 = price17;
						m_Stone.Item18 = item18;
						m_Stone.GumpName18 = gname18;
						m_Stone.Price18 = price18;
						m_Stone.Item19 = item19;
						m_Stone.GumpName19 = gname19;
						m_Stone.Price19 = price19;
						m_Stone.Item20 = item20;
						m_Stone.GumpName20 = gname20;
						m_Stone.Price20 = price20;
						m_Stone.Item21 = item21;
						m_Stone.GumpName21 = gname21;
						m_Stone.Price21 = price21;
						m_Stone.Item22 = item22;
						m_Stone.GumpName22 = gname22;
						m_Stone.Price22 = price22;
						m_Stone.Item23 = item23;
						m_Stone.GumpName23 = gname23;
						m_Stone.Price23 = price23;
						m_Stone.Item24 = item24;
						m_Stone.GumpName24 = gname24;
						m_Stone.Price24 = price24;
						m_Stone.Item25 = item25;
						m_Stone.GumpName25 = gname25;
						m_Stone.Price25 = price25;
						m_Stone.Item26 = item26;
						m_Stone.GumpName26 = gname26;
						m_Stone.Price26 = price26;
						m_Stone.Item27 = item27;
						m_Stone.GumpName27 = gname27;
						m_Stone.Price27 = price27;
						m_Stone.Item28 = item28;
						m_Stone.GumpName28 = gname28;
						m_Stone.Price28 = price28;
						m_Stone.Item29 = item29;
						m_Stone.GumpName29 = gname29;
						m_Stone.Price29 = price29;
						m_Stone.Item30 = item30;
						m_Stone.GumpName30 = gname30;
						m_Stone.Price30 = price30;
						m_Stone.Item31 = item31;
						m_Stone.GumpName31 = gname31;
						m_Stone.Price31 = price31;
						m_Stone.Item32 = item32;
						m_Stone.GumpName32 = gname32;
						m_Stone.Price32 = price32;
						m_Stone.Item33 = item33;
						m_Stone.GumpName33 = gname33;
						m_Stone.Price33 = price33;
						m_Stone.Item34 = item34;
						m_Stone.GumpName34 = gname34;
						m_Stone.Price34 = price34;
						m_Stone.Item35 = item35;
						m_Stone.GumpName35 = gname35;
						m_Stone.Price35 = price35;
						m_Stone.Item36 = item36;
						m_Stone.GumpName36 = gname36;
						m_Stone.Price36 = price36;
						m_Stone.Item37 = item37;
						m_Stone.GumpName37 = gname37;
						m_Stone.Price37 = price37;
						m_Stone.Item38 = item38;
						m_Stone.GumpName38 = gname38;
						m_Stone.Price38 = price38;
						m_Stone.Item39 = item39;
						m_Stone.GumpName39 = gname39;
						m_Stone.Price39 = price39;
						m_Stone.Item40 = item40;
						m_Stone.GumpName40 = gname40;
						m_Stone.Price40 = price40;

					m_Stone.Name = stonename;
					m_Stone.HuedPrice = huedprice;
					m_Stone.BlessedPrice = blessedprice;
					m_Stone.BondedPrice = bondedprice;

					from.SendMessage( "Your changes have been submitted." );
					break; 
				}
			}
		}
	}
}