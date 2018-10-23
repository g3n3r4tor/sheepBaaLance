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

	public Rigidbody2D player;

	public float maxXSpeed = 20;
	public float speed = 5;

	public List<Highscore> Highscores = new List<Highscore>();
	public List<Text> HighscoreTexts = new List<Text>();

	void Awake()
	{
	}


	// Use this for initialization
	void Start () {
		gameCanvas =  GameObject.Find("Game Canvas");
		endCanvas = GameObject.Find("End Canvas");

		Lance =  GameObject.Find("Lance");
		Guy =  GameObject.Find("Alpaca");
		Sheep = GameObject.Find("sheep");

		player = Guy.GetComponent<Rigidbody2D>();

        Timer = GameObject.Find("Timer");
		Timer.GetComponent<Timer>().onDead += onDead;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		for (var i = 0; i < 5; i++)
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

     		HighscoreTexts.Add(text);
		}
		LoadHighScore();
		UpdateHighScore(Highscores);
	}

	void onDead(object sender, TimeScoreArg e)
	{
		AddHighscore(e.Time);
	}

	// Update is called once per frame
	void Update ()
	{
		// Guy update
		{
			float xspeed = Input.acceleration.x;
			//float xspeed = Input.GetAxis("Horizontal");
			//float xspeed = Input.acceleration.x * speed * Time.deltaTime;


			player.AddForce(new Vector2(xspeed,0)*speed);
			//Guy.transform.Translate(xspeed, 0, 0);
		}
	}

	public void RestartGame()
	{
		SaveHighScore();
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
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
		Highscores.Add(h);

		Highscores = Highscores.OrderByDescending(o=>o.score).ToList();

		if(Highscores.Count > 5)
			Highscores.RemoveAt(Highscores.Count - 1);

		UpdateHighScore(Highscores);
	}

	public void SaveHighScore()
	{

		PlayerPrefs.SetInt("hcount", Highscores.Count);
		for (var i = 0; i < Highscores.Count; i++)
		{
			var s = Highscores[i];
			PlayerPrefs.SetInt("hscore"+i, s.score);
			PlayerPrefs.SetString("htext"+i, s.text);
		}
	}

	public void LoadHighScore()
	{
		var count = PlayerPrefs.GetInt("hcount");
		for (var i = 0; i < count; i++)
		{
			Highscore h = new Highscore();
			h.text = PlayerPrefs.GetString("htext"+i);
			h.score = PlayerPrefs.GetInt("hscore"+i);
			Highscores.Add(h);
		}
	}
}