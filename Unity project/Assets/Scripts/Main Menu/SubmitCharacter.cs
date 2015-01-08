using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmitCharacter : MonoBehaviour {

	public InputField name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private int calcHealth() {
		return GameInformation.Security * 100;
		}

	public void sumbit() {
		GameInformation.MaxHealth = calcHealth();
		GameInformation.CurrentHealth = GameInformation.MaxHealth;
		GameInformation.PlayerName = name.text;
		Application.LoadLevel ("Phase0");
		GameInformation.PlayerLevel = 1;
		GameInformation.PlayerMoveOne = new Puts ();
		GameInformation.PlayerMoveTwo = new ConsoleLog ();
		if (GameInformation.PlayerClass.CharacterClassName == "Front End Developer"){
			GameInformation.PlayerMoveThree = new JavaLava();
		} 

		if (GameInformation.PlayerClass.CharacterClassName == "Back End Developer"){
			GameInformation.PlayerMoveThree = new RailsGun();
		}

		if (GameInformation.PlayerClass.CharacterClassName == "Full Stack Developer"){
			GameInformation.PlayerMoveThree = new RefactoBlaster();
		}
	}
}
