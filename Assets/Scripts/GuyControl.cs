using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyControl : MonoBehaviour {
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            //DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }


    void Update()
    {
		float xspeed = Input.GetAxis("Horizontal");

		if(xspeed > 20)
			xspeed = 20;

		if(xspeed < -20)
			xspeed = -20;


		transform.Translate(xspeed, 0, 0);
	}
}
