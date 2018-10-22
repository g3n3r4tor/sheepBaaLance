using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct Highscore {
	public string text;
	public int score;
}


public class TimeScoreArg : EventArgs
{
  public TimeScoreArg(float fTime)
  { Time = fTime; }
  public float Time { get; set; }
}


public struct PosRot {
	private Vector3 pos;
	private Quaternion rot;

	public static PosRot Create(GameObject o)
	{
		var result = new PosRot();
		result.pos = o.transform.position;
		result.rot = o.transform.rotation;
		return result;
	}

	public void Apply(GameObject o)
	{
		o.transform.position = pos;
		o.transform.rotation = rot;
		var rb = o.GetComponent<Rigidbody>();
		if(rb){
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}
}

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	private static bool created = false;

	private static int test;
	public GameObject Lance;
	private static Vector3 originalLancePos;
	private static Quaternion originalLanceRot;
	public GameObject Guy;
	private static Vector3 originalGuyPos;
	public GameObject Sheep;
	private static Vector3 originalSheepPos;
	private static Quaternion originalSheepRot;
	public GameObject gameCanvas;
	public GameObject endCanvas;
	public GameObject Timer;

	public float maxXSpeed = 20;
	public float speed = 5;

	public List<Highscore> Highscores;
	public List<Text> HighscoreTexts;

    void Awake()
    {
    	if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		Highscores = new List<Highscore>();
		HighscoreTexts = new List<Text>();

		gameCanvas =  GameObject.Find("Game Canvas");
		endCanvas = GameObject.Find("End Canvas");
		endCanvas.gameObject.SetActive(false);

		//Lance =  GameObject.Find("Lance");
		//originalLancePos = Lance.transform.position;
		//originalLanceRot = Lance.transform.rotation;

		Guy =  GameObject.Find("Alpaca");
		originalGuyPos = Guy.transform.position;
		//Sheep = GameObject.Find("sheep");
		//originalSheepPos = Sheep.transform.position;
		//originalSheepRot = Sheep.transform.rotation;
        Timer = GameObject.Find("Timer");
		Timer.GetComponent<Timer>().onDead += onDead;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		for (var i = 0; i < 4; i++)
		{

			GameObject obj = new GameObject("Highscore"+i);
			obj.transform.SetParent(gameCanvas.transform);

			RectTransform trans = obj.AddComponent<RectTransform>();
			trans.anchoredPosition = new Vector2(-300,240 + -(20*i));
			trans.sizeDelta = new Vector2 (70, 20);
			Text text = obj.AddComponent<Text>();
     		text.text = (i+1)+". ";
     		text.font = ArialFont;
     		text.material = ArialFont.material;
     		text.color = Color.black;

     		Instance.HighscoreTexts.Add(text);
		}

		var buttons = endCanvas.GetComponentsInChildren<Button>();
		foreach(var button in buttons)
		{
			if(button.name == "Restart Button"){
				Button b = button.GetComponent<Button>();
				b.onClick.AddListener(RestartGame);
			}
			if(button.name == "Menu Button"){
				Button b = button.GetComponent<Button>();
				b.onClick.AddListener(MainMenu);
			}
		}
	}

	void onDead(object sender, TimeScoreArg e)
	{
		AddHighscore(e.Time);
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

			if(Input.GetKeyDown(KeyCode.R))
			{
				RestartGame();
			}
		}

		// Guy update
		{
			float xspeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			//float xspeed = Input.acceleration.x * speed * Time.deltaTime;

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
		endCanvas.gameObject.SetActive(false);

		Guy.transform.position = originalGuyPos;
		var rb = Guy.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		Sheep.transform.SetPositionAndRotation(originalSheepPos, originalSheepRot);
		rb = Sheep.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		rb = Lance.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		Lance.transform.SetPositionAndRotation(originalLancePos, originalLanceRot);
		//Scene scene = SceneManager.GetActiveScene();
		//SceneManager.LoadScene(scene.buildIndex);
		ResumeGame();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void UpdateHighScore(List<Highscore> scores)
	{
		for(var i = 0; i < HighscoreTexts.Count; i++)
		{
			var h = HighscoreTexts[i];

			if(scores.Count > i)
			{
				Debug.Log("Adding Highscore");
				var s = scores[i];

				h.text = (i+1)+". " + s.text;
			}
		}
	}

	public void AddHighscore(float time)
	{
		Highscore h = new Highscore();
		h.text = time.ToString("F2") + "s";
		h.score = Mathf.RoundToInt(time*100);
		Instance.Highscores.Add(h);

		//Highscores = Highscores.OrderBy(o=>o.score).ToList();

		//if(Highscores.Count > 5)
		//	Highscores.RemoveAt(Highscores.Count - 1);

		UpdateHighScore(Instance.Highscores);
	}
}