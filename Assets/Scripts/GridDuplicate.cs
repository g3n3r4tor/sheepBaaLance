using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDuplicate : MonoBehaviour {

    // Use this for initialization
    public static int bnr = 1;

    bool cameInFromRight = false;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Alpaca")
        {
            cameInFromRight = transform.position.x < other.attachedRigidbody.position.x;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Alpaca")
        {
            var wentOutRight = transform.position.x < other.attachedRigidbody.position.x;

            //Debug.Log("Out "+name+" oX:"+other.attachedRigidbody.position.x+" x:"+transform.position.x+" From right "+cameInFromRight);
            if(cameInFromRight && !wentOutRight)
            {
                Debug.Log("Going Right");
                bnr--;
                MoveBackground(true);
            }
            else if(!cameInFromRight && wentOutRight)
            {
                Debug.Log("Going Left");
                bnr++;
                MoveBackground(false);
            }
        }
    }


    void MoveBackground(bool leftside)
    {
        GameObject toMove;

        int[] indexListL = {2,3,1};
        int[] indexListR = {3,1,2};
        int number = leftside ? indexListL[(bnr%3 + 3)%3] : indexListR[((bnr+1)%3 + 3)%3];

        toMove = GameObject.Find("Background"+number);

        if (toMove != null)
        {
            int moveX = 69;
            if(leftside)moveX = -moveX;
            toMove.transform.position = new Vector2(toMove.transform.position.x + moveX, 0.5f);
        }
        else { Debug.Log("null"); }
    }
}
