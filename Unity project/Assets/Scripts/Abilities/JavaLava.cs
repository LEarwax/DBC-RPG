using UnityEngine;
using System.Collections;

public class JavaLava : BaseAbility {
	public JavaLava() {
		AbilityName = "Java Lava";
		AbilityDescription = "A searing pillar of THIS!!!";
		AbilityID = 3;
		AbilityPower = 3;
		AbilityCost = 3;
		Stat = GameInformation.JavaScript;
	}
}
