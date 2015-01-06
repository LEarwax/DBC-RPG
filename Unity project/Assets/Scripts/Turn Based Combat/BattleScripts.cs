﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleScripts {

	private BasePlayer enemy = new BasePlayer();

	public int playerMaxHealth = GameInformation.MaxHealth;
	public int playerCurrentHealth = GameInformation.CurrentHealth;
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
		InitializeEnemy ();
		if (GameInformation.KeyboardShortcuts >= enemy.KeyboardShortCuts) {
			BattleStateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
		} else {
			BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
		}
	}



//	public void BattlePlayerChoice() {
//		// DISPLAY BUTTONS OF THE ATTACKS
//		if (GUI.Button(new Rect(50,200,150,50), GameInformation.PlayerMoveOne.AbilityName)) {
//			enemyCurrentHealth -= CalculateDamage(GameInformation.PlayerMoveOne);
//			if(enemyCurrentHealth > 0){
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
//			}else {
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
//			}
//		}
//		if (GUI.Button(new Rect(50,260,150,50), GameInformation.PlayerMoveTwo.AbilityName)) {
//			enemyCurrentHealth -= CalculateDamage(GameInformation.PlayerMoveTwo);
//			if(enemyCurrentHealth > 0){
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
//			}else {
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
//			}
//		}
//		// IF THE PLAYER CLICKS ON ONE BUTTON, FIRE THE CORRESPONDING ATTACK FUNCTION
//		// IF THE ENEMY HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO WIN
//	}

	public void BattleEnemyChoice() {
		// DISPLAY NON-CLICKABLE BUTTONS OF THE ATTACKS
		GUI.Button(new Rect(Screen.width-250,200,150,50), "Strength Attack");
		GUI.Button(new Rect(Screen.width-250,260,150,50), "Intellect Attack");

		if (Random.Range (0,2) == 1) {
			RubyAttack();
			BattleGUI.battleLog = "Hello World Attacks you with Hello World";
		} else {
			JavaScriptAttack();
			BattleGUI.battleLog = "Hello World Attacks you with World World";
		}
		// DECIDE (RANDOMLY FOR NOW) WHICH ATTACK TO PERFORM AND FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE PLAYER HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO LOSE
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
//		if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOICE) {
//			// CALCULATE DAMAGE AND SUBTRACT HP
//			int calcDamage = GameInformation.Ruby * Random.Range (8,12);
//			enemyCurrentHealth -= calcDamage;
//			// IF THE ENEMY HEALTH IS 0, WIN, OTHERWISE, ENEMYCHOICE
//			if (enemyCurrentHealth > 0) {
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
//			} else {
//				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
//			}
//		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOICE) {
//			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = enemy.Ruby * Random.Range (8,12);
			playerCurrentHealth -= calcDamage;
			// IF THE PLAYER HEALTH IS 0, LOSE, OTHERWISE, PLAYERCHOICE
			if (playerCurrentHealth > 0) {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
			}
//		} 
	}

	public void JavaScriptAttack() {
		if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = GameInformation.JavaScript * Random.Range (7,13);
			enemyCurrentHealth -= calcDamage;
			// IF THE ENEMY HEALTH IS 0, WIN, OTHERWISE, ENEMYCHOICE
			if (enemyCurrentHealth > 0) {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = enemy.JavaScript * Random.Range (7,13);
			playerCurrentHealth -= calcDamage;
			// IF THE PLAYER HEALTH IS 0, LOSE, OTHERWISE, PLAYERCHOICE
			if (playerCurrentHealth > 0) {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
			}
		} 
	}


}
