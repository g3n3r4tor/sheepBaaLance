using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDuplicate : MonoBehaviour {

    // Use this for initialization
    public bool left;
    public int backgroundnr;
    float xPos;
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Alpaca")
        {
            xPos = other.attachedRigidbody.position.x;
           // Debug.Log("Entered through xPos: + " + xPos + ", Left: " + left + ", backgroundNR+ " + backgroundnr);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Alpaca")
        {

            float currPos = other.attachedRigidbody.position.x;
            if (left)
            {
                if (currPos < xPos)
                {
                    //Move Rightmost background to the left
                    MoveBackground(true);
                }
            }
            else
            {
                if (currPos > xPos)
                {
                    //move leftmost background to the right
                    MoveBackground(false);
                }
            }


            //Debug.Log("Exited through xPos: + " + xPos + ", Left: " + left + ", backgroundNR+ " + backgroundnr);
        }
    }
    void MoveBackground(bool leftside)
    {
        GameObject toMove;
        if (leftside)
        {
            //Move rightmost to left
            switch (backgroundnr)
            {
                case 1:
                    //Move nr 2
                    toMove = GameObject.Find("Background2");
                    break;
                case 2:
                    //Move nr 3
                    toMove = GameObject.Find("Background3");
                    break;
                case 3:
                    //Move nr 1
                    toMove = GameObject.Find("Background1");
                    break;
                default:
                    toMove = null;
                    break;
            }
            if (toMove != null)
            {
                toMove.transform.position = new Vector2(toMove.transform.position.x - 69, 0.5f);
            }
            else { Debug.Log("null"); }
        }
        else
        {
            //move leftmost to right
            switch (backgroundnr)
            {
                case 1:
                    //Move nr 3
                    toMove = GameObject.Find("Background3");
                    break;
                case 2:
                    //move nr 1
                    toMove = GameObject.Find("Background1");
                    break;
                case 3:
                    //move nr 2
                    toMove = GameObject.Find("Background2");
                    break;
                default:
                    toMove = null;
                    break;
            }
            if (toMove != null)
            {
                toMove.transform.position = new Vector2(toMove.transform.position.x + 69, 0.5f);
            }
            else { Debug.Log("null"); }
        }
    }
}
