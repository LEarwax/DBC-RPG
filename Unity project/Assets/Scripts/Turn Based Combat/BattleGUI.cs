using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public static string battleLog = "Prepare for Battle";
	private BattleScripts battleScripts = new BattleScripts();
	public RawImage explosion; 
	public Image red;
	public Text playerAttack;
	public Text enemyAttack;
	public Text playerMove1;
	public Text playerMove2;
	public Text playerMove3;
	public Text battleMoveScreen;
	public Button playerMove1Button;
	public Button playerMove2Button;
	public Button playerMove3Button;
	

	//Battle state machine
	public Slider playerHealthSlider;
	public Slider playerEnergySlider;
	public Slider enemyHealthSlider;
	public Text playerHealthAmounts;
	public Text enemyHealthAmounts;
	public Text playerName;
	public Text enemyName;
	public static int battleCounter;
	// STATE MACHINE
	public enum BattleStates {
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		WAIT,
		LOSE,
		WIN
	}
	
	public static BattleStates currentState;

	public void turnButtonsOn(){
		playerMove1Button.interactable = true;
		playerMove2Button.interactable = true;
		playerMove3Button.interactable = true;

	}

	public void turnButtonsOff(){
		playerMove1Button.interactable = false;
		playerMove2Button.interactable = false;
		playerMove3Button.interactable = false;
	
		
	}



	public void AttackMove1(){

		battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
		DisplayPlayerAttackInfo(GameInformation.PlayerMoveOne);
		battleScripts.playerCurrentEnergy -= GameInformation.PlayerMoveOne.AbilityCost;
		battleCounter = 0;
		turnButtonsOff();
		PlayerSwitchState();
	}


	public void AttackMove2(){
		battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage (GameInformation.PlayerMoveTwo);
		DisplayPlayerAttackInfo(GameInformation.PlayerMoveTwo);
		battleScripts.playerCurrentEnergy -= GameInformation.PlayerMoveTwo.AbilityCost;
		battleCounter = 0;
		turnButtonsOff();
		PlayerSwitchState();
		
	}

	public void AttackMove3(){
		battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage (GameInformation.PlayerMoveThree);
		DisplayPlayerAttackInfo(GameInformation.PlayerMoveThree);
		battleScripts.playerCurrentEnergy -= GameInformation.PlayerMoveThree.AbilityCost;
		battleCounter = 0;
		turnButtonsOff();
		PlayerSwitchState();

		
	}

	public void ShowExplosions() {
		StartCoroutine (DisplayExplosion ());
	}

	public void DisplayPlayerAttackInfo(BaseAbility attack){
		battleMoveScreen.text = "You attack with " + attack + "!" ;
	}

	public void DisplayEnemyAttackInfo(){
		battleMoveScreen.text = "Hello World attacks!!!";
	}



	private void TogglePlayerHit(){
		red.enabled = !red.enabled;
	}

	public void ToggleExplosion(){
		explosion.enabled = !explosion.enabled;
	}




	void Start(){
		playerEnergySlider.maxValue = battleScripts.playerMaxEnergy;
		ToggleExplosion ();
		TogglePlayerHit ();
		battleMoveScreen.text = "Attempt to print 'Hello World' to your console.";
		
		playerMove1.text = GameInformation.PlayerMoveOne.AbilityName;
		playerMove2.text = GameInformation.PlayerMoveTwo.AbilityName;
		playerMove3.text = GameInformation.PlayerMoveThree.AbilityName;

		// INITIALIZE THE ENEMY WITH THE STATS
		//		battleScripts.InitializeEnemy();
		
		currentState = BattleStates.START;
		playerName.text = GameInformation.PlayerName + " Health";
		enemyName.text = "Hello World Health";
	}

	void Update () {
		switch(currentState){
		case(BattleStates.START):
			turnButtonsOff();
			battleScripts.BattleStart();
			playerHealthSlider.maxValue = battleScripts.playerMaxHealth;
			enemyHealthSlider.maxValue = battleScripts.enemyMaxHealth;
			playerEnergySlider.maxValue = battleScripts.playerMaxEnergy;

			break;
		case(BattleStates.PLAYERCHOICE):
			turnButtonsOn();
			break;
		case(BattleStates.ENEMYCHOICE):
			turnButtonsOff();
			BattleEnemyChoice();
			break;
		case(BattleStates.WAIT):
			break;
		case(BattleStates.LOSE):
			battleMoveScreen.text = "You Lost";
			break;
		case(BattleStates.WIN):
			battleMoveScreen.text = "You may proceed!";
			GameInformation.helloWorldDefeated = true;
			Application.LoadLevel("Phase0");
			break;
		}
		playerHealthSlider.value = battleScripts.playerCurrentHealth;
		enemyHealthSlider.value = battleScripts.enemyCurrentHealth;
		playerHealthAmounts.text = battleScripts.playerCurrentHealth.ToString () + "/" + battleScripts.playerMaxHealth.ToString ();
		enemyHealthAmounts.text = battleScripts.enemyCurrentHealth.ToString () + "/" + battleScripts.enemyMaxHealth.ToString ();
		playerEnergySlider.value = battleScripts.playerCurrentEnergy;
		if(battleScripts.playerCurrentEnergy < GameInformation.PlayerMoveThree.AbilityCost) {
			playerMove3Button.interactable = false;
		}
		
	}

	public void PlayerSwitchState(){
		if (battleScripts.enemyCurrentHealth > 0){
			StartCoroutine(SwitchStates());
		} else {
			currentState = BattleStates.WIN;
		}
	}



//	void OnGUI(){
//		BattleMainItems ();
//		if (currentState == BattleStates.PLAYERCHOICE) {
//			BattlePlayerChoice ();
//		} else if (currentState == BattleStates.ENEMYCHOICE) {
//			BattleEnemyChoice ();
//		} else if (currentState == BattleStates.WIN) {
//			battleLog = "You won!";	
//			GameInformation.helloWorldDefeated = true;
//			Application.LoadLevel("Phase0");
//		} else if (currentState == BattleStates.LOSE) {
//			battleLog = "You lost!";					
//		}
//
//	}

	private IEnumerator playerHitWait(){
		TogglePlayerHit ();
		yield return new WaitForSeconds (0.5f);
		TogglePlayerHit ();
	}

	private IEnumerator DisplayExplosion(){
		ToggleExplosion();
		yield return new WaitForSeconds(0.5f);
		ToggleExplosion();

	}

	private IEnumerator SwitchStates(){
		currentState = BattleStates.WAIT;
		yield return new WaitForSeconds (1.0f);
		currentState = BattleStates.ENEMYCHOICE;
	}

	private IEnumerator SwitchStatesToPlayer(){
		yield return new WaitForSeconds (1.0f);
		currentState = BattleStates.PLAYERCHOICE;
	}


	public void BattleMainItems() {
		// LOG BOX
//		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), battleLog);

	}

//	public void BattlePlayerChoice() {
//
//		if (GUI.Button(new Rect(50,200,150,50), GameInformation.PlayerMoveOne.AbilityName)) {
//			battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
//			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveOne.AbilityName;
//			StartCoroutine(DisplayExplosion());
//
//			if (battleScripts.enemyCurrentHealth > 0){
//				StartCoroutine(SwitchStates());
//			} else {
//				currentState = BattleStates.WIN;
//			}
//		}
//		if (GUI.Button(new Rect(50,260,150,50), GameInformation.PlayerMoveTwo.AbilityName)) {
//			battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveTwo);
//			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveTwo.AbilityName;
//			StartCoroutine(DisplayExplosion ());
//
//			if (battleScripts.enemyCurrentHealth > 0){
//				StartCoroutine(SwitchStates());
//			} else {
//				currentState = BattleStates.WIN;
//			}
//		}
//
//		battleCounter = 0;
//	}

	public void BattleEnemyChoice() {

		if (battleCounter == 0) {
			StartCoroutine(playerHitWait());
			battleScripts.RubyAttack();
			DisplayEnemyAttackInfo();


//			if (Random.Range (0,2) == 1) {
//				StartCoroutine(playerHitWait());
//				BattleStateMachine.battleScripts.RubyAttack ();
//				BattleGUI.battleLog = "Hello World Attacks you with Ruby Attack";
//			} else {
//				StartCoroutine(playerHitWait());
//				BattleStateMachine.battleScripts.JavaScriptAttack ();
//				BattleGUI.battleLog = "Hello World Attacks you with Javascript Attack";	
//			}
//
			if (battleScripts.playerCurrentHealth > 0){
				StartCoroutine(SwitchStatesToPlayer());
			} else {
				currentState = BattleStates.LOSE;
			}

			battleCounter = 1;
		}
	}



}
