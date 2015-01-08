using UnityEngine;
using System.Collections;

public class RailsGun : BaseAbility {
	public RailsGun() {
		AbilityName = "Rails Gun";
		AbilityDescription = "A high velocity ruby attack";
		AbilityID = 3;
		AbilityPower = 3;
		AbilityCost = 3;
		Stat = GameInformation.Ruby;
	}
}
