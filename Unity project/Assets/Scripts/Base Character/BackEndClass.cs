using UnityEngine;
using System.Collections;

public class BackEndClass : BaseCharacterClass {
	
	public BackEndClass() {
		// NAME AND DESCRIPTION
		CharacterClassName = "Back End Developer";
		CharacterClassDescription = "Always worried about solidity and performance, the back end developer ensures everything's running smoothly.";
		// STATS
		Ruby = 14;
		JavaScript = 9;
		SQL = 11;
		KeyboardShortcuts = 14;
		Security = 12;

		SpecialAblity = new RailsGun();
	}
	
}
