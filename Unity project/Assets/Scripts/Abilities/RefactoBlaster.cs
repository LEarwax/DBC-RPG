using UnityEngine;
using System.Collections;

public class RefactoBlaster : BaseAbility {
	public RefactoBlaster() {
		AbilityName = "Refact-o-Blaster";
		AbilityDescription = "A weapon from assembled from materials far and wide.";
		AbilityID = 3;
		AbilityPower = 5;
		AbilityCost = 4;
		Stat = GameInformation.SQL;
	}
}
