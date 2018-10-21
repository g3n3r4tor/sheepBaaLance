using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float lifeTime = 0.0f;		// Total seconds elapsed since Sheep has been in the game
	private Text displayText;
	private bool isAlive = true;
	
	public GameObject sheep;

	// Use this for initialization
	void Start () {
		displayText = GetComponent<Text>();

		sheep.GetComponent<SheepAI>().FloorCollided += OnFloorCollided;
	}

	void OnFloorCollided(object sender, EventArgs e) {
		isAlive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			lifeTime += Time.deltaTime;
			displayText.text = FormatTime();
		}
	}

	string FormatTime() {
		return lifeTime.ToString("F2") + "s";
	}
}
