using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	// LIST OF INFORMATIONS ALWAYS AVAILABLE DURING THE GAME

	// GENERAL
	public static string PlayerName 			 { get; set; }
	public static int PlayerLevel 				 { get; set; }
	public static BaseCharacterClass PlayerClass { get; set; }
	public static bool helloWorldDefeated = false;
	public Slider healthSlider;
	public Text characterLevel;
	public Text hpAmounts;
	public static int PointsToAllocate = 5;

	// CURRENT POSITION
	public static Vector3 PlayerPosition { get; set; }

	// STATS
	public static int Ruby   		{ get; set; }
	public static int JavaScript  	{ get; set; }
	public static int SQL 	 		{ get; set; }
	public static int KeyboardShortcuts		 { get; set; }
	public static int Security { get; set; }

	public static BaseAbility PlayerMoveOne { get; set; }
	public static BaseAbility PlayerMoveTwo { get; set; }
	public static BaseAbility PlayerMoveThree { get; set; }

	// GOLD
	public static int Gold		 { get; set; }

	// XP
	public static int CurrentXP  { get; set; }
	public static int RequiredXP { get; set; }

	// HEALTH (TBD, I DON'T KNOW IF IT MAKES SENSE TO HAVE ONE)
	public static int MaxHealth { get; set; }
	public static int CurrentHealth { get; set; }

	// HEALTH BAR

	void Start(){
		healthSlider.maxValue = GameInformation.MaxHealth;
		healthSlider.value = GameInformation.CurrentHealth;
		characterLevel.text = GameInformation.PlayerLevel.ToString();
		hpAmounts.text = GameInformation.CurrentHealth.ToString () + "/" + GameInformation.MaxHealth.ToString ();
	}


}

	
