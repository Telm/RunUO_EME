using System;
using System.Text;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server
{

	//1	Khuzdul
	//2	Sindarin
	//3	Logatig
	//4	Quenya
	//5	Eothrik
	//6	Adunaic
	//7	Kuduk
	//8	Westron
	//9	Czarna Mowa
	//10	Mowa Orków
	public class Language
	{

		private string m_Name;
		private string m_ShortName;
		private int m_Index;
		private int m_DefaultSpeechColour;

		private static int m_CommonLanguageIndex;
		private static Dictionary<int,Language> m_Languages = new Dictionary<int,Language> ();

		public static void RegisterLanguage (Language value, bool isCommon)
		{
			RegisterLanguage (value);
			m_CommonLanguageIndex = value.Index;
		}
		public static void RegisterLanguage (Language value)
		{
			m_Languages.Add(value.Index, value);
		}
		public static bool ContainsLanguage (int index)
		{
			return m_Languages.ContainsKey(index);
		}
		//************************ GETTERS & SETTERS **********************

		public int DefaultSpeechColour{
			get{return m_DefaultSpeechColour;}
			
		}
		public static int CommonLanguageIndex {
			get { return m_CommonLanguageIndex; }
		}
		public static Dictionary<int,Language> Languages {
			get { return m_Languages; }
		}
		public string Name {
			get { return m_Name; }
			set { m_Name = value; }
		}
		public int Index {
			get { return m_Index; }
			set { m_Index = value; }
		}
		public string ShortName {
			get { return m_ShortName; }
			set { m_ShortName = value; }
		}
		//******************************************************************
		public Language (string name, string shortName, int index, int defaultSpeechColour)
		{
			m_Index = index;
			m_Name = name;
			m_ShortName = shortName;
			m_DefaultSpeechColour = defaultSpeechColour;
		}
		public static string EncodeSpeech (Mobile @from, string text, int languageIndex)
		{
			//IF common then do not encode
			if (languageIndex == CommonLanguageIndex)
				return text;
			string[] words = text.Split (' ');
			int languageValue = @from.Race.LanguageKnowledgeValue (languageIndex) * 10;
			Console.WriteLine ("koduje \t" + @from.Str + "\n\t\t\t" + text + "\n\t\t\t[" + languageIndex + "-" + CommonLanguageIndex + "] " + languageValue);
			string newText = "";
				Random random = new Random ();
			
			for (int i = 0; i < words.Length; ++i) {
				int nextSeed = i* 50;
				string word = words[i];
				int rand = random.Next (0+ nextSeed,50+ nextSeed);
				if (rand > (languageValue+ nextSeed))
					newText += RandomString (word.Length, true);
				else
					newText += word;
				newText += " ";
				//Console.WriteLine (word+ "\t\t\t" + rand+ "\t" + (languageValue+ nextSeed)); // + newText + "\t"
			}
			return newText;
		}
		private static string RandomString (int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder ();
			Random random = new Random ();
			char ch;
			for (int i = 0; i < size; i++) {
				ch = Convert.ToChar (Convert.ToInt32 (Math.Floor (26 * random.NextDouble () + 65)));
				builder.Append (ch);
			}
			if (lowerCase)
				return builder.ToString ().ToLower ();
			return builder.ToString ();
		}
		public static Dictionary<int,int> GetDefaultLanguageHues(){
			//Console.WriteLine("uno");
			Dictionary<int,int> defaultLanguageHues = new Dictionary<int,int>();
			Console.WriteLine("uno " + Languages.Count + " " + defaultLanguageHues.Keys.Count);
			
			foreach(Language l in Languages.Values){
				Console.WriteLine("uno" + l.Index + " " + l.DefaultSpeechColour);
				defaultLanguageHues.Add(l.Index, l.DefaultSpeechColour);
			}
			return defaultLanguageHues;
		}
		
	}

	public class LanguageKnowledge
	{
		private Dictionary<int,int> m_LanguageKnowledge;

		public int LanguageKnowledgeValue (int languageIndex)
		{
			if ( ! m_LanguageKnowledge.ContainsKey(languageIndex))
				return 0;
			return m_LanguageKnowledge[languageIndex];
		}
		public static int MinimumLanguageKnowledge {
			get { return 0; }
		}
		public static int MaximumLanguageKnowledge {
			get { return 5; }
		}

		public LanguageKnowledge (Dictionary<int,int> languageKnowledge)
		{
			m_LanguageKnowledge = languageKnowledge;
		}
		public void InitDefault ()
		{
			m_LanguageKnowledge = new Dictionary<int,int>();
			foreach ( KeyValuePair<int,Language> entry in Language.Languages)
				m_LanguageKnowledge[entry.Key] = (entry.Key == Language.CommonLanguageIndex) ? 
						LanguageKnowledge.MaximumLanguageKnowledge : LanguageKnowledge.MinimumLanguageKnowledge;
			
		}
	}
	
	
}
