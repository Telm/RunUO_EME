using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBHairStylist : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBHairStylist() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				/*  Add( new GenericBuyInfo( "special beard dye", typeof( SpecialBeardDye ), 500000, 20, 0xE26, 0 ) );  */
				/* Add( new GenericBuyInfo( "special hair dye", typeof( SpecialHairDye ), 500000, 20, 0xE26, 0 ) );  */
				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 2000, 20, 0xEFF, 0 ) ); 
				Add( new GenericBuyInfo( "Szkice fryzur damskich", typeof( NewWomenHairRestylingDeed ), 1000, 20, 0x14F0, 0 ) );
				Add( new GenericBuyInfo( "Szkice fryzur meskich", typeof( NewMenHairRestylingDeed ), 1000, 20, 0x14F0, 0 ) );
				Add( new GenericBuyInfo( "Szkice zarostow meskich", typeof( BeardRestylingDeed ), 1000, 20, 0x14F0, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( HairDye ), 30 ); 
				Add( typeof( NewWomenHairRestylingDeed ), 500 ); 
				Add( typeof( NewMenHairRestylingDeed ), 500 ); 
				Add( typeof( BeardRestylingDeed ), 500 ); 
			} 
		} 
	} 
}