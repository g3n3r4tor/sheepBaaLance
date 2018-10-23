using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SheepControl : MonoBehaviour {

	public event EventHandler FloorCollided;

	public float MadnessTimer;			// The threshold in seconds when the sheep starts going crazy
	public List<Tilemap> floors;

	// Use this for initialization
	void Start () {
		floors.Add(GameObject.Find("Tilemap1").GetComponent<Tilemap>());
		floors.Add(GameObject.Find("Tilemap2").GetComponent<Tilemap>());
		floors.Add(GameObject.Find("Tilemap3").GetComponent<Tilemap>());
        MadnessTimer = 0.1f;
	}
    private void Update()
    {
        StartCoroutine(MoveSheep());
    }

    void OnCollisionEnter2D(Collision2D col)
	{
		foreach(var floor in floors)
		{
			if(col.gameObject == floor.gameObject)
			{
				if (FloorCollided != null)
				{
					FloorCollided(this, EventArgs.Empty);
				}
			}
		}
	}
    private IEnumerator MoveSheep()
    {
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-1f*MadnessTimer,1f*MadnessTimer),0));
        yield return new WaitForSeconds(2);
        MadnessTimer+=0.1f;
    }
}