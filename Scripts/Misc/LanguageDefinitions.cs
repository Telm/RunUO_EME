using System;
using System.Collections.Generic;
using Server;

namespace Server.Misc
{

	public class LanguageDefinitions
	{
		public static void Configure ()
		{
			
			Language.RegisterLanguage (new Language ("Khuzdul", "Khu", 1,100));
			Language.RegisterLanguage (new Language ("Sindarin", "Sin", 2,200));
			Language.RegisterLanguage (new Language ("Logatig", "Log", 3,300));
			Language.RegisterLanguage (new Language ("Quenya", "Que", 4,400));
			Language.RegisterLanguage (new Language ("Eorthic", "Eor", 5,500));
			Language.RegisterLanguage (new Language ("Adunaic", "Adu", 6,600));
			Language.RegisterLanguage (new Language ("Kuduk", "Kud", 7,700));
			Language.RegisterLanguage (new Language ("Westron", "Wes", 8,800),true);//common speech
			Language.RegisterLanguage (new Language ("Czarna Mowa", "Cza", 9,900));
			Language.RegisterLanguage (new Language ("Mowa Orków", "Orc", 10,1000));
		}
		
		
		
		public static LanguageKnowledge CreateLanguageKnowledge(int khuzdul, int sindarin, int logatig, int quenya, int eorthic, int adunaic, int kuduk,  int black, int orcish){
			Dictionary<int,int> languageKnowledge = new Dictionary<int, int>();
			languageKnowledge.Add(1,khuzdul);
			languageKnowledge.Add(2,sindarin);
			languageKnowledge.Add(3,logatig);
			languageKnowledge.Add(4,quenya);
			languageKnowledge.Add(5,eorthic);
			languageKnowledge.Add(6,adunaic);
			languageKnowledge.Add(7,kuduk);
			languageKnowledge.Add(8,LanguageKnowledge.MaximumLanguageKnowledge);
			languageKnowledge.Add(9,black);
			languageKnowledge.Add(10,orcish);
			return new LanguageKnowledge(languageKnowledge);
		}
		
		
		
	}
}
