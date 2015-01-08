using UnityEngine;
using System.Collections;

public class LevelingScripts {

	private void CalculateRequiredXP() {
		GameInformation.RequiredXP = GameInformation.PlayerLevel * 100;
	}

	public void AddExperience(int experience) {
		// ADD EXPERIENCE TO OUR CURRENT EXPERIENCE
		GameInformation.CurrentXP += experience;
		CalculateRequiredXP ();
		Debug.Log ("Your new required experience before leveling up is: " + GameInformation.RequiredXP.ToString());

		// IF WE LEVEL UP, ADD POINTS TO ALLOCATE AND DISPLAY SOME TEXT
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) {

			Debug.Log ("Current level is: " + GameInformation.PlayerLevel.ToString());
			// LEVEL UP
			++GameInformation.PlayerLevel;

			Debug.Log ("After leveling up your level is: " + GameInformation.PlayerLevel.ToString());
			// CALCULATE THE NEW REQUIRED XP
			CalculateRequiredXP ();

			Debug.Log ("Your new required experience to level up is: " + GameInformation.RequiredXP.ToString());
			// GIVE THREE NEW POINTS TO ALLOCATE TO STATS
			GameInformation.PointsToAllocate += 3;

			// RESET THE CURRENTXP TO 0
			GameInformation.CurrentXP = 0;
		}
	}

}
