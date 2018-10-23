/*
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Generic.List;
*/
using UnityEngine;
using UnityEngine.UI;


/*
public class Scores {
    public int Id { get; set; }
    public float TimerCount { get; set; }
    public string Time { get; set; }
    public string PlayerName { get; set; }
}
*/

// for current method you can see how it works and how to connect with = https://www.youtube.com/watch?v=vZU51tbgMXk
public class HighScoresControl
{

    public Text score;
    public Text highScore;

    void Start () {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();

    }

    // Put it score from last game played
    public void GameScore (float number) {
        score.text = number.ToString();
        if (number > PlayerPrefs.GetFloat("HighScore", 0)) {
            PlayerPrefs.SetFloat("HighScore", number);
            highScore.text = number.ToString();
        }


    }

    // if you want to reset the score. 
    public void Reset () {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }


    /* If text is float and not time look at this

      float totalSeconds = 228.10803f;
      TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

      Console.WriteLine(string.Format("{0:%h}:{0:%m}:{0:%s}", time)); // 00:03:48
// work in progress for multiple score. 
*/
    /*


   public List<Scores> scoreList = new List<Scores>();
   public List<Scores> tempScoreList = new List<Scores>();



  // Initialise the game score
  void Start() {
      float totalSeconds = 228.10803f;
      TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

      Console.WriteLine(string.Format("{0:%h}:{0:%m}:{0:%s}", time)); // 00:03:48
      scoreList.Add(new Scores { Id = 1,  TimerCount = totalSeconds, Time = string.Format("{0:%h}:{0:%m}:{0:%s}", time), PlayerName = "" });
      scoreList.Add(new Scores { Id = 2,  TimerCount = totalSeconds, Time = string.Format("{0:%h}:{0:%m}:{0:%s}", time), PlayerName = "" });
      scoreList.Add(new Scores { Id = 3,  TimerCount = totalSeconds, Time = string.Format("{0:%h}:{0:%m}:{0:%s}", time), PlayerName = "" });
      scoreList.Add(new Scores { Id = 4,  TimerCount = totalSeconds, Time = string.Format("{0:%h}:{0:%m}:{0:%s}", time), PlayerName = "" });
      scoreList.Add(new Scores { Id = 5,  TimerCount = totalSeconds, Time = string.Format("{0:%h}:{0:%m}:{0:%s}", time), PlayerName = "" });


}
// Compare scores with current scours. 
public int CheckScore (float currentTimeCount) {
       for (int i = 0; i < scoreList.Capacity; i++) {
           if (currentTimeCount < scoreList[i].TimerCount) {
               return i;
           }
       }
       return -1;
   }
   // Update scorelist 
   public void UpdateList (int posistion, Scores toUpdate) {
       for (int i = 0; i < scoreList.Count; i++)
       {
           if (posistion == i) {
               tempScoreList[i] = toUpdate;
               tempScoreList[i + 1] = scoreList[i];

           }
           else if (posistion < i) {
               tempScoreList[i] = scoreList[i];
           }
           else if (posistion > i) {
               tempScoreList[i] = scoreList[i + 1];
           }
       }
       scoreList = tempScoreList;
   }
   // Check if update is required, then act on it.
   public void Update (float floatScore, Scores toUpdate) {
       int check = CheckScore(floatScore);
       if (check >= 0) {
           UpdateList(check, toUpdate);
       } else {
           Console.WriteLine("Sorry you did not beat anything");
       }
   }




   // protected List<Scores> top10 = new List<Scores>();

   int CheckHighScore (Scores input) {
       foreach (var score in top10) {
           if (input.timer < score.timer) {
               return score.GetHashCode();
           }

       }
   }*/

}
// First find the id, 
// shift all the ids, meaning, if 1st then 1st makes 2nd and so forth. 
// 