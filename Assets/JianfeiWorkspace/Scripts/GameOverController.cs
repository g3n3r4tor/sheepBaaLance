using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour {

	private Image image;

	// public RectTransform panel;
	private TextMeshProUGUI highscore;

	// Use this for initialization
	void Start () {
		image = GetComponentInChildren<Image>();
		// highscore = GetComponentInChildren<Text>();
		highscore = GetComponentInChildren<TextMeshProUGUI>();
	}

	public void Show(string seconds) {
		image.fillAmount = 1;
		// highscore.text = "Your Score: " + seconds;
		highscore.SetText("Your Score: " + seconds);
	}

	public void Hide() {
		image.fillAmount = 0;
		// highscore.text = "";
		highscore.SetText("");
	}
}
