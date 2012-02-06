using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.Quests.Haven;
using Server.Engines.Quests.Necro;


namespace Server.Commands
{
	public class SetSay
	{
		public static void Initialize()
		{
			CommandSystem.Register( "SetSay", AccessLevel.Player, new CommandEventHandler( SetSay_OnCommand ) );
		}

		[Usage( "SetSay [nr_jezyka]" )]
		[Description( "Ustawia język ktorym chcemy mówic." )]
		private static void SetSay_OnCommand( CommandEventArgs e )
		{
			Mobile m_Mobile = e.Mobile;
			int languageIndex = Language.CommonLanguageIndex;
			if ( e.Length >= 1 )
				languageIndex = e.GetInt32( 0 );
            if (languageIndex >= 11)
            {
                m_Mobile.SendMessage("Podales nieprawidlowa wartosc jezyka");
                return;
            }
            //LanguageKnowledge Lkl = new LanguageKnowledge();
            if (m_Mobile.AccessLevel <= AccessLevel.GameMaster)
            {
                if (m_Mobile.Race.LanguageKnowledgeValue(languageIndex) == 0)
                {
                    m_Mobile.SendMessage("Nie znasz tego jezyka");
                    return;
                }
            }

            if (languageIndex == 0 || Server.Language.Languages[languageIndex] == null)
            {
                m_Mobile.SendMessage("Podales nieprawidlowa wartosc jezyka");
				return;
			}
				
				m_Mobile.ActualLanguage = languageIndex;
			
			m_Mobile.SendMessage( "Teraz mowisz w {0}.", Server.Language.Languages[languageIndex].Name );
		}

	}
}