using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour {

	private float lifeTime = 0f;		// Total seconds elapsed since Sheep has been in the game

	public float MadnessTimer;			// The threshold in seconds when the sheep starts going crazy

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime += Time.deltaTime;
	}
}
