using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour {

	private Image image;
	private TextMeshProUGUI highscore;

	// Use this for initialization
	void Start () {
		highscore = GetComponentInChildren<TextMeshProUGUI>();
		highscore.SetText("");
	}

	public void Show(string seconds) {
		highscore.SetText("Your Score: " + seconds);
	}
}
