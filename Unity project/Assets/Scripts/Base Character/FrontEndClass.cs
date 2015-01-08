using UnityEngine;
using System.Collections;

public class FrontEndClass : BaseCharacterClass {
	
	public FrontEndClass() {
		// NAME AND DESCRIPTION
		CharacterClassName = "Front End Developer";
		CharacterClassDescription = "The Front End Developer creates beautiful user interfaces with his knowledge and wizardry";
		// STATS
		Ruby = 9;
		JavaScript = 14;
		SQL = 13;
		KeyboardShortcuts = 11;
		Security = 13;

		SpecialAblity = new JavaLava();
	}
	
}