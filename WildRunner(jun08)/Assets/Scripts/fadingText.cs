using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class fadingText : MonoBehaviour {

    Text flashingText;
   // public GameObject titleScreen;

    void Awake() {


        Time.timeScale = 1;
        flashingText = GetComponent<Text>();
        flashingText.enabled=false;
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {

        yield return new WaitForSeconds(0.5f);
        
        while (true) {
            //flashingText.text = "";
            flashingText.CrossFadeAlpha(0.3f, -1.05f, false);
            flashingText.enabled = true;
            yield return new WaitForSeconds(0.5f);

            //flashingText.text = "Tap to Start";
            flashingText.CrossFadeAlpha(2.0f, 1.05f, false);
            yield return new WaitForSeconds(0.8f);

            flashingText.CrossFadeAlpha(0.3f, 1.05f, false);
            //flashingText.enabled = true;
            //titleScreen.SetActive(true);
            yield return new WaitForSeconds(1.5f);


        }
       // throw new NotImplementedException();
    }
}
