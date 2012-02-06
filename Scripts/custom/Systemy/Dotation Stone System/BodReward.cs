//A Remake Of Darktanion Bod Chest///
/////Thanks For the idea ///////////
//////AnimalCrackers///////////////
/////GameOverProject.com//////////
/////////////////////////////////
using System;
using Server;
using Server.Items;
using Server.Engines.BulkOrders;
using Server.Mobiles;
using System.Collections;
using Server.ContextMenus;
using Server.Factions;
using Server.Misc;
using Server.Network;
using System.Collections.Generic;
using Server.Multis;


namespace Server.Items
{
	public class BodTokenChest : Item
	{
	[Constructable]
	public BodTokenChest() : base( 0x9AB )
	
	{
		Name ="A Bod Reward Chest";
		Movable = false;
		Hue = 1174;
		LootType = LootType.Blessed;
	}
	
				public BodTokenChest( Serial serial ) : base( serial )
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
				private static int[] m_Sounds = new int[]
			{
            0x1E0, 0x31E, 0x320, 0x324, 0x32F, 0x158, 0x42D, 0x542, 
            0x551, 0x554, 0x543, 0x556, 0x562, 0x545, 0x53C, 0x54E,
			0x54F, 0x550, 0x551, 0x558, 0x565, 0x58B, 0x5A7, 0x5A5
			};

				public override bool OnDragDrop( Mobile from, Item dropped )
	{
				Mobile m = from;
				PlayerMobile mobile = m as PlayerMobile;
				if ( mobile != null )
	{
	Item reward;
	int gold, fame;
	if (dropped is SmallSmithBOD && !((SmallSmithBOD)dropped).Complete)
	{
		from.PlaySound( Utility.RandomList( m_Sounds ) );
                    switch ( Utility.Random(7) ) 
                    {
                        case 0: from.SendAsciiMessage( 0x3F, "I guess you think your funny with that unfilled small smithing bod." ); break;
                        case 1: from.SendAsciiMessage( 0x3E, "That is not even close to a filled small smithing bod" ); break;
                        case 2: from.SendAsciiMessage( 0x3D, "Hey! You tried to sneak that small smithing bod in when I wasn't looking!" ); break;
                        case 3: from.SendAsciiMessage( 0x3C, "Don't even think about passing that off as a filled small smithing bod, cause it wont work?" ); break;
                        case 4: from.SendAsciiMessage( 0x3B, "Stop thief, just like a diplomatic voucher, unfilled small smithing bods never work!" ); break;
                        case 5: from.SendAsciiMessage( 0x3A, "Why dont you use Vhaeruns Painting 1.9 rar and paint a picture of me, that way you can stick unfilled small smithing bods into it!" ); break;
                        case 6: from.SendAsciiMessage( 0x39, "This isn't a freebie genie like in Aladdin, come back when you have a filled small smithing bod!" ); break;
                    }
		return false;
	}
	else if ( dropped is SmallSmithBOD )
		{
		((SmallSmithBOD)dropped).GetRewards( out reward, out gold, out fame );
		from.PlaySound( Utility.RandomList( m_Sounds ) );
		switch ( Utility.Random(5) )
					{
                        case 0: from.SendAsciiMessage( 0x53, "You touched me! Ohhh but you have a filled small smithing bod!" ); break;
                        case 1: from.SendAsciiMessage( 0x52, "Well now ain't that a site for sore wait I dont have eyes but nice small smithing bod!" ); break;
                        case 2: from.SendAsciiMessage( 0x51, "Take your reward for this small smithing bod before you end up imprissoned!" ); break;
                        case 3: from.SendAsciiMessage( 0x50, "I was happier when small smithing bods were turned into the vendors." ); break;
                        case 4: from.SendAsciiMessage( 0x4F, "What! Not one thank you!,sheesh just give me that filled small smithing bod before I gobble you up!" ); break;
            
                    }
		from.AddToBackpack( new Platinum( Utility.RandomMinMax( 100, 1000 ) ) );
		from.AddToBackpack( new BankCheck( Utility.RandomMinMax( 500, 1000 ) ) );
		Titles.AwardFame( from, fame, true );
		dropped.Delete();
		return true;
		}
	if ( dropped is LargeSmithBOD && !((LargeSmithBOD)dropped).Complete)
		{
			from.PlaySound( Utility.RandomList( m_Sounds ) );
                    switch ( Utility.Random(7) ) 
                    {
                        case 0: from.SendAsciiMessage( 0x3F, "In case you have not noticed, this is not a filled large smithing bod..DUH!" ); break;
                        case 1: from.SendAsciiMessage( 0x3E, "Wait!, did you hear that, it sounded like tokens falling...oh guess not since that is not a filled large smithing bod!" ); break;
                        case 2: from.SendAsciiMessage( 0x3D, "W.o.W, even World of Warcrack couldnt be this stupid on turn ins, bwahahahaha, come back when you have a filled large smithing bod!" ); break;
                        case 3: from.SendAsciiMessage( 0x3C, "Gee Mister/Miss, use your brain much! That is still not a filled large smithing bod?" ); break;
                        case 4: from.SendAsciiMessage( 0x3B, "Wanna know a secret, yeah you, come closer....THAT IS NOT A FILLED LARGE SMITHING BOD!!" ); break;
                        case 5: from.SendAsciiMessage( 0x3A, "Hey did you hear the one about the large smithing bod that got away,,yeah cause you didnt fill it yet!!!" ); break;
                        case 6: from.SendAsciiMessage( 0x39, "Attention all players! This fool just tried sticking a large smithing bod into me without filling it first...Its Okay To L.O.L!" ); break;
                    }
			return false;
		}
	else if ( dropped is LargeSmithBOD )
		{
		((LargeSmithBOD)dropped).GetRewards( out reward, out gold, out fame );
		from.PlaySound( Utility.RandomList( m_Sounds ) );
		switch ( Utility.Random(5) )
					{
                        case 0: from.SendAsciiMessage( 0x53, "Right On! you finally got it filled, well now dont you feel smarter?" ); break;
                        case 1: from.SendAsciiMessage( 0x52, "Wait! did you hear that, it sounded like tokens oh my gosh you did finish that bod here you go then." ); break;
                        case 2: from.SendAsciiMessage( 0x51, "Thank you for your deposit, unfortunately we are all out of Reward Tokens at this time...Just Kidding!" ); break;
                        case 3: from.SendAsciiMessage( 0x50, "Sometimes we loose and sometimes we win, and today is your lucky day." ); break;
                        case 4: from.SendAsciiMessage( 0x4F, "Ching, Ching, the sound of tokens upchucking from my belly. Well now you can buy some Bling, Bling!" ); break;
		}
           }
	if ( dropped is SmallTailorBOD && !((SmallTailorBOD)dropped).Complete)
		{
		from.PlaySound( Utility.RandomList( m_Sounds ) );
                    switch ( Utility.Random(7) ) 
                    {
                        case 0: from.SendAsciiMessage( 0x3F, "Well I certainly hope your better at wood crafting then you are at this small unfilled tailoring bod." ); break;
                        case 1: from.SendAsciiMessage( 0x3E, "Maybe you might want to concider another profession, because you really are not that great at filling small tailoring bods" ); break;
                        case 2: from.SendAsciiMessage( 0x3D, "So how have you been? Been doing much tailoring lately, oh guess not since this is an empty small tailoring bod!" ); break;
                        case 3: from.SendAsciiMessage( 0x3C, "Would you like me to explain yet again that your not using a filled small tailoring bod hmmmmm.?" ); break;
                        case 4: from.SendAsciiMessage( 0x3B, "Whatsssss Upppppp! Obviously not your stats or your intelligence would be high enough to realize this is an empty small tailoring bod" ); break;
                        case 5: from.SendAsciiMessage( 0x3A, "Wait Come Back, I was only teasing here have some reward tokens on the house...NOT haha go fill that small tailoring bod then come back biotch!" ); break;
                        case 6: from.SendAsciiMessage( 0x39, "Even if that bod was half done I still would'nt give you half the reward tokens for it, please just fill that small tailoring bod thank you!" ); break;
                    }
		return false;
		}
	else if ( dropped is SmallTailorBOD)
		{
		((SmallTailorBOD)dropped).GetRewards( out reward, out gold, out fame );
		from.PlaySound( Utility.RandomList( m_Sounds ) );
		switch ( Utility.Random(5) )
					{
                        case 0: from.SendAsciiMessage( 0x53, "Ouch! Geez you dont have to kick me, I'm not a fricken Vending Machine." ); break;
                        case 1: from.SendAsciiMessage( 0x52, "To be or Not To be that is the question, but I dont have time for that just feed me Seymore feed me!" ); break;
                        case 2: from.SendAsciiMessage( 0x51, "Looks to me like you have truly earned this reward." ); break;
                        case 3: from.SendAsciiMessage( 0x50, "Well of course I want that BOD I am sooooooo hungry baby, if you know what I mean.WINK WINK!!" ); break;
                        case 4: from.SendAsciiMessage( 0x4F, "You know its players like you that make me...Ewww that's goooood and tasty, oh yeah!" ); break;

                    }
		from.AddToBackpack( new Platinum( Utility.RandomMinMax( 500, 1500 ) ) );
		from.AddToBackpack( new BankCheck( Utility.RandomMinMax( 1000, 3000 ) ) );
		Titles.AwardFame( from, fame, true );
		dropped.Delete();
		return true;
		}
	if ( dropped is LargeTailorBOD && !((LargeTailorBOD)dropped).Complete)
		{
		from.PlaySound( Utility.RandomList( m_Sounds ) );
                    switch ( Utility.Random(7) ) 
                    {
                        case 0: from.SendAsciiMessage( 0x3F, "I would really like to help you out but I have five starving small crates at home to feed, fill those large tailoring bods then come back." ); break;
                        case 1: from.SendAsciiMessage( 0x3E, "My mamma always said stupid is as stupid does, now fill that large tailoring bod and then place it on me." ); break;
                        case 2: from.SendAsciiMessage( 0x3D, "Roses are Red, Violets are Blue, I would like to be fed, but you seem to stuck like glue, Unfilled Tailoring Bod!" ); break;
                        case 3: from.SendAsciiMessage( 0x3C, "Here Ye here ye, all available large tailoring bods please come to me. No yours are unfilled?" ); break;
                        case 4: from.SendAsciiMessage( 0x3B, "Do you know the meaning of brain flatulence? Yeah its where you try to stick that unfilled large tailoring bod on me!" ); break;
                        case 5: from.SendAsciiMessage( 0x3A, "If you couldnt stick that small tailoring unfinished bod on me what the hell are you trying to place that large bod on me for!" ); break;
                        case 6: from.SendAsciiMessage( 0x39, "This one time at band camp, this girl stuck a flute in me and....oh you know the story just give me a filled large tailoring bod!" ); break;
                    }
		return false;
		}
	else if ( dropped is LargeTailorBOD )
		{
		((LargeTailorBOD)dropped).GetRewards( out reward, out gold, out fame );
		from.PlaySound( Utility.RandomList( m_Sounds ) );
		switch ( Utility.Random(5) )
					{
                        case 0: from.SendAsciiMessage( 0x53, "Were off to eat some real BODs some wonderful Large Tailoring BODs." ); break;
                        case 1: from.SendAsciiMessage( 0x52, "Don't slip on some Crack, or you'll be feeling really Whack! Just feed me already!" ); break;
                        case 2: from.SendAsciiMessage( 0x51, "Sniff...Sniff...Oh sorry about that just allergies man..you know what I am saying..." ); break;
                        case 3: from.SendAsciiMessage( 0x50, "Calling all BODs, Calling all BODs, be on the lookout for a large filled tailoring bod, its green and square." ); break;
                        case 4: from.SendAsciiMessage( 0x4F, "You make me want to Shout, Kick my heels up and....Oh damn I dont have any feet. Stupid Scriptor......" ); break;
						
                    }
		from.AddToBackpack( new Platinum( Utility.RandomMinMax( 1250, 3000 ) ) );
		from.AddToBackpack( new BankCheck( Utility.RandomMinMax( 3000, 6000 ) ) );
		Titles.AwardFame( from, fame, true );
		dropped.Delete();
		return true;
		}	
	}
	return base.OnDragDrop( from, dropped );
		}
	}
}