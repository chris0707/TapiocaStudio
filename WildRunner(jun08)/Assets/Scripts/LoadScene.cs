using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour {

    PlayerController playerController;
    public GameObject startButton;
    public GameObject slider;
    public GameObject wallpaper;
    public GameObject splashVideo;
    public GameObject loadingPanel;

    public Slider loadingSlider;
    public Text textPercentage;

    private void Start()
    {
        StartCoroutine(ScreenEnd(0));
    }



    public void LoadByIndex(int sceneIndex)
    {
        
        StartCoroutine(Waiting(sceneIndex));
        

    }

    IEnumerator Waiting(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanel.SetActive(true);
        wallpaper.SetActive(false);
        startButton.SetActive(false);
        splashVideo.SetActive(false);
        
        while (!operation.isDone)
        {
            
           // float progress = Mathf.Clamp01(operation.progress / .9f);
            float progress = Mathf.Clamp01(operation.progress / .030716272f);
           // float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            textPercentage.text = progress * 100f + "%";

            Debug.Log(progress);
            yield return null;
        }

          }

    IEnumerator ScreenEnd(int sceneIndex)
    {

        yield return new WaitForSeconds(5f);
        wallpaper.SetActive(true);
        splashVideo.SetActive(false);

    }

    public void Quit() {
        Application.Quit();
    }


}
