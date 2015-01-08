using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScreen : MonoBehaviour {
	
	// INITIALIZE EMPTY VARIABLES
	public bool isPaused;
	public int pauseCounter = 0;

	private GameObject FPC;
	private GameObject FPCCamera;

	public Canvas pauseCanvas;
	
	// Use this for initialization
	void Start () {
		FPC = GameObject.FindWithTag("Player");
		FPCCamera = GameObject.FindWithTag("MainCamera");

		pauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.P) {
			++pauseCounter;
			
			if (pauseCounter % 2 != 0) {
				isPaused = true;
			} else {
				isPaused = false;
			}
		}
		
		if (isPaused) {	
			FPC.GetComponent<MouseLook>().enabled = false;
			FPCCamera.GetComponent<MouseLook>().enabled = false;

			Time.timeScale = 0;

			pauseCanvas.enabled = true;
		} else {
			FPC.GetComponent<MouseLook>().enabled = true;
			FPCCamera.GetComponent<MouseLook>().enabled = true;
			
			Time.timeScale = 1;

			pauseCanvas.enabled = false;

		}
		
	}
}
