using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private static bool created = false;

	private GameObject Guy;
	private GameObject Sheep;

	public float maxXSpeed = 20;
	public float speed = 5;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

	// Use this for initialization
	void Start () {
		Guy =  GameObject.Find("Alpaca");
		Sheep =  GameObject.Find("Sheep");
	}

	// Update is called once per frame
	void Update ()
	{
		//Game Update
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				PauseGame();
			}
			else if(Input.GetKeyUp(KeyCode.Space))
			{
				ResumeGame();
			}
		}

		// Guy update
		{
			float xspeed = Input.acceleration.x * speed * Time.deltaTime;

			if(xspeed > maxXSpeed)
				xspeed = maxXSpeed;

			if(xspeed < -maxXSpeed)
				xspeed = -maxXSpeed;

			Guy.transform.Translate(xspeed, 0, 0);
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	public void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
		ResumeGame();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}