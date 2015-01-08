using UnityEngine;
using System.Collections;

public class TeacherDialogue : MonoBehaviour {

	// INITIALIZE EMPTY VARIABLES
	private GameObject player;
	
	public bool displayText;
	private bool hasAlreadyAssignedXP = false;
	public string text;
	public int dialogCounter = 0;

	private LevelingScripts levelingScripts = new LevelingScripts();

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.E) {
			++dialogCounter;
			
			if (dialogCounter == 1) {
				displayText = true;
				text = "Welcome to Phase 1! I'll be your instructor throughout this phase.";
			} else if (dialogCounter == 2) {
				text = "Before you can start Phase 1, you will need to find and collect some objects to get yourself ready.";
			} else if (dialogCounter == 3) {
				text = "The objects will raise your stats, allowing you to complete the great challenges that await you.";
			} else if (dialogCounter == 4) {
				text = "The objects you need to find are: a LAPTOP with SPAGHETTI CAT, a CUP for your COFFEE, and a BOOK near the PAIRING STATIONS";
			} else if (dialogCounter == 5) {
				text = "Once you're done collecting the items, come back to me. I have a challenge for you. Go forth and code!";
			} else if (dialogCounter == 6) {
				displayText = false;
			}

			if (!hasAlreadyAssignedXP && Phase1Information.cupCollected == true && Phase1Information.bookCollected == true && Phase1Information.laptopCollected == true) {
				displayText = true;
				text = "Congrats! You collected all the objects! You earned 150 XP!";
				levelingScripts.AddExperience(150);
				hasAlreadyAssignedXP = true;
				Invoke ("setTextToFalse", 2.0f);
			}
			
		}
		
		if (displayText) {
			Time.timeScale = 0;
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), text);
		} else {
			Time.timeScale = 1;
		}
		
	}

	void setTextToFalse() {
		displayText = false;
	}
}
