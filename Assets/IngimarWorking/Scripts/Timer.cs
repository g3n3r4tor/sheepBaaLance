using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float lifeTime = 0.0f;		// Total seconds elapsed since Sheep has been in the game
	private Text displayTest;

	// Use this for initialization
	void Start () {
		displayTest = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime += Time.deltaTime;
	}
}
