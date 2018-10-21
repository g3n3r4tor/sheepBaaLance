using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IngimarWorking
{
	public class SheepControl : MonoBehaviour {
		void OnCollisionEnter2D(Collision2D col)
		{
			if(col.gameObject.name == "Tilemap")
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
