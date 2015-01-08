using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseAbility {


	private string abilityName;
	private string abilityDescription;
	private int abilityID;
	private int abilityPower;
	private int abiltiyCost;
	private int stat;

	public string AbilityName { get; set; }
	public string AbilityDescription { get; set; }
	public int AbilityID { get; set; }
	public int AbilityPower { get; set; }
	public int AbilityCost { get; set; }
	public int Damage { get; set; }
	public int Stat { get; set; }


}
