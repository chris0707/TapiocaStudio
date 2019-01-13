using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class MovieClip : MonoBehaviour
{
   
    // Use this for initialization
    void Start()
    {

          
            Handheld.PlayFullScreenMovie("title-intro.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        

    }
}
