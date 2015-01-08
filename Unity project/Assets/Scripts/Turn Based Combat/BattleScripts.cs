using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleScripts {

	private BasePlayer enemy = new BasePlayer();

	public int playerMaxHealth = GameInformation.MaxHealth;
	public int playerCurrentHealth = GameInformation.CurrentHealth;
	public int playerMaxEnergy;
	public int playerCurrentEnergy;
	public int enemyMaxHealth;
	public int enemyCurrentHealth;




	public void InitializeEnemy() {
		// Hardcoded enemy name for now. Maybe we can save the name in GameInformation when we interact with the NPC using the script attached to it.
		enemy.PlayerName = "Your enemy";
		enemy.PlayerLevel = Random.Range (GameInformation.PlayerLevel, GameInformation.PlayerLevel + 2);
		// ENEMY STATS
		enemy.Ruby = 10;
		enemy.JavaScript = 10;
		enemy.SQL = 10;
		enemy.KeyboardShortCuts = 10;
		enemy.Security = 10;
		// ENEMY HP
		enemyMaxHealth = enemy.Security * 100;
		enemyCurrentHealth = enemyMaxHealth;
	}
	
	
	public void BattleStart() {
		// DECIDE WHO IS GOING FIRST
		playerMaxEnergy = GameInformation.SQL;
		playerCurrentEnergy = playerMaxEnergy;
		Debug.Log (playerCurrentEnergy);
		InitializeEnemy ();
		if (GameInformation.KeyboardShortcuts >= enemy.KeyboardShortCuts) {
			BattleGUI.currentState = BattleGUI.BattleStates.PLAYERCHOICE;
		} else {
			BattleGUI.currentState = BattleGUI.BattleStates.ENEMYCHOICE;
		}


	}

	public void BattleWin() {
//		battleLog = "You Won!";
		GameInformation.helloWorldDefeated = true;
		Application.LoadLevel("Phase0");
	}

	public void BattleLose() {
//		battleLog = "You Lose!";
		Application.LoadLevel("Phase0");
	}

	//==================//
	// HELPER FUNCTIONS //
	//==================//

	public int CalculateDamage(BaseAbility attack){
		return (attack.AbilityPower + attack.Stat) * Random.Range (8, 12);
	}

	public void RubyAttack() {
			int calcDamage = enemy.Ruby * Random.Range (8,12);
			playerCurrentHealth -= calcDamage;
	}

	public void JavaScriptAttack() {
		int calcDamage = enemy.JavaScript * Random.Range (7,13);
		playerCurrentHealth -= calcDamage;
	}


}
