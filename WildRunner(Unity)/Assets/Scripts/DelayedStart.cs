using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour {
    public GameObject countDown;
    public GameObject pauseButton;
    public GameObject highScoreText;
    public GameObject scoreText;
    public GameObject in1;
    public GameObject in2;
    public GameObject in3;

    public GameObject in11;
    public GameObject in22;
    public GameObject in33;

    public AudioSource countAudio;


    // Use this for initialization
    void Start () {
        countDown.SetActive(false);
        //in1.SetActive(true);




    }

    public void StartCo() {
        StartCoroutine("StartDelay");
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator StartDelay()
    {
        in1.SetActive(false);
        in2.SetActive(false);
        in3.SetActive(false);

        in11.SetActive(false);
        in22.SetActive(false);
        in33.SetActive(false);
        countDown.SetActive(true);


        //Time.timeScale = 0;
        //countAudio.Play();

        float pauseTime = Time.realtimeSinceStartup + 4f;
        pauseButton.SetActive(false);
        highScoreText.SetActive(false);
        scoreText.SetActive(false);
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;

        countDown.gameObject.SetActive(false);
        pauseButton.SetActive(true);
        highScoreText.SetActive(true);
        scoreText.SetActive(true);
        Time.timeScale = 1;
    }
}
