﻿using UnityEngine;
using System.Collections;

public class FadeOutScript : MonoBehaviour {

	void Start() {
		Invoke ("FadeOut", 37.0f);
	}

	void FadeOut () {
		AutoFade.LoadLevel ("Phase1", 3, 3, Color.white);
	}
}