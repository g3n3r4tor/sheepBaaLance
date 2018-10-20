using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyControl : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public float maxXSpeed = 20;
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveHorizontal = Input.acceleration.x;

        float xspeed = moveHorizontal * speed * Time.deltaTime;

        if(xspeed > maxXSpeed)
        {
            xspeed = maxXSpeed;
        }

        if(xspeed < -maxXSpeed)
        {
            xspeed = -maxXSpeed;
        }

        transform.Translate(xspeed, 0, 0);
    }
}
