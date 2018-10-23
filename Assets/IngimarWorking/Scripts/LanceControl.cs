using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IngimarWorking
{
    public class LanceControl : MonoBehaviour {

        public float speed;             //Floating point variable to store the player's movement speed.

        private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

        void Start()
        {
            //Get and store a reference to the Rigidbody2D component so that we can access it.
            rb2d = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.acceleration.x;

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, 0);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rb2d.AddForce(movement * speed);
        }
    }
}
