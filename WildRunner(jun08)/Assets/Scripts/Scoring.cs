using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text scoreText;
    public Text scoreTextCopy;
    public Text hiScoreText;
    public Text hiScoreTextCopy;


    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncrease;

    public GameObject hiScoreTextCopyGameObject;

    

    void Start () {


        //if (PlayerPrefs.GetFloat("hiscore") != null) {
            hiScoreCount = PlayerPrefs.GetFloat("hiscor");
            //PlayerPrefs.DeleteAll();
            
        //}

        
        

    }
	
	void Update () {

        if (scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("hiscor", hiScoreCount);
            hiScoreTextCopyGameObject.SetActive(true);
        }


        scoreText.text = "" + Mathf.Round(scoreCount);
        scoreTextCopy.text = "" + Mathf.Round(scoreCount);
        hiScoreText.text = "HighScore: " + Mathf.Round(hiScoreCount);
        hiScoreTextCopy.text = "New HighScore!: " + Mathf.Round(hiScoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
