using System;
using Server;

namespace Server.Misc
{
	public class RaceDefinitions
	{
		public static void Configure ()
		{
			Console.WriteLine ("konfiguruje rasy");
			/* Here we configure all races. Some notes:
			 * 
			 * 1) The first 32 races are reserved for core use.
			 * 2) Race 0x7F is reserved for core use.
			 * 3) Race 0xFF is reserved for core use.
			 * 4) Changing or removing any predefined races may cause server instability.
			 */

			RegisterRace (new Human (0, 0));
			RegisterRace (new Elf (1, 1));
			RegisterRace (new Bla (2, 2));
			RegisterRace (new Dnl (3, 3));
			RegisterRace (new Eas (4, 4));
			RegisterRace (new Sin (5, 5));
			RegisterRace (new Nol (6, 6));
			RegisterRace (new Gon (7, 7));
			RegisterRace (new Dun (8, 8));
			RegisterRace (new Hob (9, 9));
			RegisterRace (new Kha (10, 10));
			RegisterRace (new Cor (11, 11));
			RegisterRace (new Roh (12, 12));
			RegisterRace (new Bre (13, 13));
			RegisterRace (new Uru (14, 14));
			RegisterRace (new Maj (15, 15));
            RegisterRace(new HumanEndore(16, 16));
		}

		public static void RegisterRace (Race race)
		{
			Race.Races[race.RaceIndex] = race;
			Race.AllRaces.Add (race);
		}

//////////////////////////////////////////////////////////////////////////////////////////////////

        private class HumanEndore : Race
        {
            public HumanEndore(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Human", "Humans", "Hum", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge(0, 0, 0, 0, 0, 0, 0, 0, 0))
            {
            }

            public override bool ValidateHair(bool female, int itemID)
            {
                if (itemID == 0)
                    return true;

                if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
                    return false;
                //Buns & Receeding Hair
                if (itemID >= 0x203b && itemID <= 0x203d)
                    return true;

                if (itemID >= 0x2044 && itemID <= 0x204a)
                    return true;

                return false;
            }

            //Random hair doesn't include baldness
            public override int RandomHair(bool female)
            {
                switch (Utility.Random(9))
                {
                    case 0:
                        return 0x203b;
                    //Short
                    case 1:
                        return 0x203c;
                    //Long
                    case 2:
                        return 0x203d;
                    //Pony Tail
                    case 3:
                        return 0x2044;
                    //Mohawk
                    case 4:
                        return 0x2045;
                    //Pageboy
                    case 5:
                        return 0x2047;
                    //Afro
                    case 6:
                        return 0x2049;
                    //Pig tails
                    case 7:
                        return 0x204a;
                    default:
                        //Krisna
                        return (female ? 0x2046 : 0x2048);
                    //Buns or Receeding Hair
                }
            }

            public override bool ValidateFacialHair(bool female, int itemID)
            {
                if (itemID == 0)
                    return true;

                if (female)
                    return false;

                if (itemID >= 0x203e && itemID <= 0x2041)
                    return true;

                if (itemID >= 0x204b && itemID <= 0x204d)
                    return true;

                return false;
            }

            public override int RandomFacialHair(bool female)
            {
                if (female)
                    return 0;

                int rand = Utility.Random(7);

                return ((rand < 4) ? 0x203e : 0x2047) + rand;
            }

            public override int ClipSkinHue(int hue)
            {
                if (hue < 1002)
                    return 1002;
                else if (hue > 1058)
                    return 1058;
                else
                    return hue;
            }

            public override int RandomSkinHue()
            {
                return Utility.Random(1002, 57) | 0x8000;
            }

            public override int ClipHairHue(int hue)
            {
                if (hue < 1102)
                    return 1102;
                else if (hue > 1149)
                    return 1149;
                else
                    return hue;
            }

            public override double GetWeightModifier() { return 1.0; }
            public override bool HasRacialNightSight() { return false; }
            public override int RandomHairHue()
            {
                return Utility.Random(1102, 48);
            }
        }
private class Maj : Race
		{
			public Maj (int raceID, int raceIndex) : base(raceID, raceIndex, "Majar", "Majars", "Maj", "Maj", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (5, 5, 5, 5, 5, 5, 5, 5, 5))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}
			
			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Uru : Race
		{
			public Uru (int raceID, int raceIndex) : base(raceID, raceIndex, "Uruk Hai", "Uruk Hais", "Uru", "Ork", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 0, 5, 5))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Bre : Race
		{
			public Bre (int raceID, int raceIndex) : base(raceID, raceIndex, "Man of Bree", "Men of Bree", "Bre", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Roh : Race
		{
			public Roh (int raceID, int raceIndex) : base(raceID, raceIndex, "Rohhirim", "Rohirrims", "Roh", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 5, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Cor : Race
		{
			public Cor (int raceID, int raceIndex) : base(raceID, raceIndex, "Corsair", "Corsairs", "Cor", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Kha : Race
		{
			public Kha (int raceID, int raceIndex) : base(raceID, raceIndex, "Dwarf", "Dwarfs", "Dwa", "Dwa", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (5, 0, 0, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}
			public override double GetWeightModifier (){return 1.2;}
			
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Hob : Race
		{
			public Hob (int raceID, int raceIndex) : base(raceID, raceIndex, "Hobbit", "Hobbits", "Hob", "Hob", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 5, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Dun : Race
		{
			public Dun (int raceID, int raceIndex) : base(raceID, raceIndex, "Dunedain", "Dunedains", "Dun", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 5, 1, 0, 0, 4, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Gon : Race
		{
			public Gon (int raceID, int raceIndex) : base(raceID, raceIndex, "Man od Gondor", "Men of Gondor", "Gon", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 3, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Nol : Race
		{
			public Nol (int raceID, int raceIndex) : base(raceID, raceIndex, "Noldor", "Noldors", "Nol", "Elf", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (1, 5, 2, 5, 4, 3, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier ()
			{
				return 1.0;
			}
			
			public override bool HasRacialNightSight(){return true;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Sin : Race
		{
			public Sin (int raceID, int raceIndex) : base(raceID, raceIndex, "Sindar", "Sindars", "Sin", "Elf", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 5, 0, 4, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return true;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Eas : Race
		{
			public Eas (int raceID, int raceIndex) : base(raceID, raceIndex, "Easterling", "Easterlings", "Eas", "Hum", 400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 5, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

private class Dnl : Race
		{
			public Dnl (int raceID, int raceIndex) : base(raceID, raceIndex, "Man of Dunland", "Men of Dunland", "Dnl", "Hum",  400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 5, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
		}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}

		
		
//////////////////////////////////////////////////////////////////////////////////////////////////

		private class Bla : Race
		{
			public Bla (int raceID, int raceIndex) : base(raceID, raceIndex, "Black Numenorean", "Black Numenoreans", "Num", "Hum",  400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 1, 0, 0, 0, 5, 0, 5, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////
		
		private class Human : Race
		{
			public Human (int raceID, int raceIndex) : base(raceID, raceIndex, "N/A", "Humans", "N/A", "Hum",  400, 401, 402, 403, Expansion.None, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
					return false;
				//Buns & Receeding Hair
				if (itemID >= 0x203b && itemID <= 0x203d)
					return true;
				
				if (itemID >= 0x2044 && itemID <= 0x204a)
					return true;
				
				return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (9)) {
				case 0:
					return 0x203b;
				//Short
				case 1:
					return 0x203c;
				//Long
				case 2:
					return 0x203d;
				//Pony Tail
				case 3:
					return 0x2044;
				//Mohawk
				case 4:
					return 0x2045;
				//Pageboy
				case 5:
					return 0x2047;
				//Afro
				case 6:
					return 0x2049;
				//Pig tails
				case 7:
					return 0x204a;
				default:
					//Krisna
					return (female ? 0x2046 : 0x2048);
					//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;

				if (female)
					return false;
				
				if (itemID >= 0x203e && itemID <= 0x2041)
					return true;
				
				if (itemID >= 0x204b && itemID <= 0x204d)
					return true;
				
				return false;
			}

			public override int RandomFacialHair (bool female)
			{
				if (female)
					return 0;
				
				int rand = Utility.Random (7);
				
				return ((rand < 4) ? 0x203e : 0x2047) + rand;
			}

			public override int ClipSkinHue (int hue)
			{
				if (hue < 1002)
					return 1002; else if (hue > 1058)
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue ()
			{
				return Utility.Random (1002, 57) | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				if (hue < 1102)
					return 1102; else if (hue > 1149)
					return 1149;
				else
					return hue;
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return Utility.Random (1102, 48);
			}
		}
		
//////////////////////////////////////////////////////////////////////////////////////////////////

		private class Elf : Race
		{
			private static int[] m_SkinHues = new int[] { 0xbf, 0x24d, 0x24e, 0x24f, 0x353, 0x361, 0x367, 0x374, 0x375, 0x376,
			0x381, 0x382, 0x383, 0x384, 0x385, 0x389, 0x3de, 0x3e5, 0x3e6, 0x3e8,
			0x3e9, 0x430, 0x4a7, 0x4de, 0x51d, 0x53f, 0x579, 0x76b, 0x76c, 0x76d,
			0x835, 0x903 };

			private static int[] m_HairHues = new int[] { 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x58, 0x8e, 0x8f, 0x90,
			0x91, 0x92, 0x101, 0x159, 0x15a, 0x15b, 0x15c, 0x15d, 0x15e, 0x128,
			0x12f, 0x1bd, 0x1e4, 0x1f3, 0x207, 0x211, 0x239, 0x251, 0x26c, 0x2c3,
			0x2c9, 0x31d, 0x31e, 0x31f, 0x320, 0x321, 0x322, 0x323, 0x324, 0x325,
			0x326, 0x369, 0x386, 0x387, 0x388, 0x389, 0x38a, 0x59d, 0x6b8, 0x725,
			0x853 };

			public Elf (int raceID, int raceIndex) : base(raceID, raceIndex, "N/A", "Elves", "N/A", "N/A",  605, 606, 607, 608, Expansion.ML, LanguageDefinitions.CreateLanguageKnowledge (0, 0, 0, 0, 0, 0, 0, 0, 0))
			{
			}

			public override bool ValidateHair (bool female, int itemID)
			{
				if (itemID == 0)
					return true;
				
				if ((female && (itemID == 0x2fcd || itemID == 0x2fbf)) || (!female && (itemID == 0x2fcc || itemID == 0x2fd0)))
					return false;

				if (itemID >= 0x2fbf && itemID <= 0x2fc2)
					return true;
				
				if (itemID >= 0x2fcc && itemID <= 0x2fd1)
					return true;
				
					return false;
			}

			//Random hair doesn't include baldness
			public override int RandomHair (bool female)
			{
				switch (Utility.Random (8)) {
				case 0:
					return 0x2fc0;
				//Long Feather
				case 1:
					return 0x2fc1;
				//Short
				case 2:
					return 0x2fc2;
				//Mullet
				case 3:
					return 0x2fce;
				//Knob
				case 4:
					return 0x2fcf;
				//Braided
				case 5:
					return 0x2fd1;
				//Spiked
				case 6:
					return (female ? 0x2fcc : 0x2fbf);
				default:
					//Flower or Mid-long
					return (female ? 0x2fd0 : 0x2fcd);
					//Bun or Long
				}
			}

			public override bool ValidateFacialHair (bool female, int itemID)
			{
				return (itemID == 0);
			}

			public override int RandomFacialHair (bool female)
			{
				return 0;
			}

			public override int ClipSkinHue (int hue)
			{
				for (int i = 0; i < m_SkinHues.Length; i++)
					if (m_SkinHues[i] == hue)
						return hue;

				return m_SkinHues[0];
			}

			public override int RandomSkinHue ()
			{
				return m_SkinHues[Utility.Random (m_SkinHues.Length)] | 0x8000;
			}

			public override int ClipHairHue (int hue)
			{
				for (int i = 0; i < m_HairHues.Length; i++)
					if (m_HairHues[i] == hue)
						return hue;

				return m_HairHues[0];
			}

			public override double GetWeightModifier (){return 1.0;}
			public override bool HasRacialNightSight(){return false;}
			public override int RandomHairHue ()
			{
				return m_HairHues[Utility.Random (m_HairHues.Length)];
	}
}
	}
}
