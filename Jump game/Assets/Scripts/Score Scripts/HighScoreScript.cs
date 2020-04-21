using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public int highScoreValue = 0;

    Text highScore;


    // Start is called before the first frame update
    void Start() {
        highScore = GetComponent<Text>();
        //setting highscore when the game starts, with a default value of 0 if there is no highscore
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }//start

    // Update is called once per frame
    void Update() {

        //checks if current score is higher then highscore then changes highscore
        if (ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", ScoreScript.scoreValue);
            highScore.text = "Highscore: " + ScoreScript.scoreValue.ToString();
        }
        

    }//update
}//class

