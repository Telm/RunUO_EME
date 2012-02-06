//Safety Deposit Box
//RunUO 2.0 Final & RunUO SVN
//By DxMonkey aka Tresdni & Fenris
/*
Simply place these around banks.  They are unmovable and show if they are unclaimed or not.  When a player double clicks
the box, and has enough to purchase it, the box will be assigned to them, and will open for them ONLY.  The purchase type
can be changed easily where marked.  It is set as default for 5,000 gold.
*/
using Server;
using Server.Items;
using Server.Multis;
using Server.Network;
using Server.Mobiles;
using System;


namespace Server.Items
{

[FlipableAttribute( 0xe41, 0xe40 )] 
	public class SafetyDepositBox : BaseContainer 
	{
	private Mobile m_Owner;
	Random random = new Random();
		[Constructable] 
		public SafetyDepositBox() : base( 0xE41 ) 
		{ 
			Name = "An Unclaimed Safety Deposit Box [5,000 Gold]";
			Hue = random.Next(0, 1900);
			Movable = false;

		} 

		public override void OnDoubleClick(Mobile from)
		{
			// set owner if not already set -- this is only done the first time.
			if ( m_Owner == null )
			{
				Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );  //Search their backpack for item type, in this case - gold.
					if ( from.Backpack.ConsumeTotal( typeof( Gold ), 5000 ) )  //Try to take 5,000 gold from their backpack.  If it does, it assigns the box to them.
						{
							m_Owner = from;
							this.Name = m_Owner.Name.ToString() + "'s Safety Deposit Box";
							from.SendMessage( "This safety deposit box has been assigned to you. 20,000 treasure tokens have been taken from your backpack." );
						}
						else
							{
								from.SendMessage( "You do not have enough treasure tokens to purchase the chest." );  //Gives them this message if they do not have that much gold in their pack.
								return;
							}	
			}
			else
			{
				if ( m_Owner != from )
				{
					from.SendMessage( "This is not yours to use.  You should consider buying your own safety deposit box." );
					return;
				}
			}
			base.OnDoubleClick( from );
		}
		
		public SafetyDepositBox( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
			writer.Write(m_Owner);  //Save the owner
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
			m_Owner = reader.ReadMobile();
		} 
	} 
}