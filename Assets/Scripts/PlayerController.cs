using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D player;

	public Camera camera;
	public float speed;
	public float muliplier = 1;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        // Store the current horizontal input in the float moveHorizontal.
        // float moveHorizontal = Input.acceleration.x;
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        player.AddForce(movement * speed * muliplier);

		// Doesn't work since it does not recompute the Relative Joint
        // transform.Translate(moveHorizontal * speed * muliplier * Time.deltaTime, 0, 0);

		// Update the Camera view rect
	}
}
