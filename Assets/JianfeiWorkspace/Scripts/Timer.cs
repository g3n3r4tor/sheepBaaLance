using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float lifeTime = 0.0f;		// Total seconds elapsed since Sheep has been in the game
	private Text displayText;
	private bool isAlive = true;
	private bool isShown = false;
	private GameOverController gameoverController;
	
	public GameObject sheep;
	public Canvas gameoverUI;

	// Use this for initialization
	void Start () {
		displayText = GetComponent<Text>();
		gameoverController = gameoverUI.GetComponent<GameOverController>();
		gameoverUI.gameObject.SetActive(false);

		sheep.GetComponent<SheepControl>().FloorCollided += OnFloorCollided;
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
		else if (!isShown) {
			gameoverUI.gameObject.SetActive(true);
			isShown = true;
			// The game objects in the gameoeverUI are all null until the next Update call so setting
			// the text in this loop will raise NullException
		}
		else {
			gameoverController.Show(FormatTime());
			gameObject.SetActive(false);
		}
	}

	string FormatTime() {
		return lifeTime.ToString("F2") + "s";
	}
}
