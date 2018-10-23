using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SheepAI : MonoBehaviour {

	public event EventHandler FloorCollided;

	public float MadnessTimer;			// The threshold in seconds when the sheep starts going crazy
	public Tilemap floor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject == floor.gameObject)
		{
			if (FloorCollided != null)
			{
				FloorCollided(this, EventArgs.Empty);
			}
			// Application.LoadLevel(Application.loadedLevel);
		}
	}
}
