using UnityEngine;
using System.Collections;

public class DoorToPhase1 : MonoBehaviour {

	private GameObject player;
	private bool displayText;

	private int textCounter;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	void OnGUI () {
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Input.GetKeyUp(KeyCode.E)) {
			++textCounter;
			if (textCounter == 2) {
				if (GameInformation.helloWorldDefeated) {
					AutoFade.LoadLevel("IntroScene",3,3,Color.black);
				} else {
					Time.timeScale = 0;
					displayText = true;
				}
			} else if (textCounter == 4) {
				Time.timeScale = 1;
				displayText = false;
				textCounter = 0;
			}

		}

		if (displayText) {
			Time.timeScale = 0;
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), "You can't go out right now.");
		}
	}
}
