using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IngimarWorking
{
	public class PlayerController : MonoBehaviour {

		private Rigidbody2D player;

		public float speed;
		public float muliplier = 1;

		void Start () {
			player = GetComponent<Rigidbody2D>();
		}

		void Update () {
	        float moveHorizontal = Input.GetAxis("Horizontal");

	        //Use the two store floats to create a new Vector2 variable movement.
	        Vector2 movement = new Vector2(moveHorizontal, 0);

	        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
	        player.AddForce(movement * speed * muliplier);
		}
	}
}
