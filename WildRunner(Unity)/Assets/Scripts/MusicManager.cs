using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource music;
    // public AudioSource[] sound;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;


    float masterVolume;


    void Start()
    {
        //sound = GetComponents<AudioSource>();
        //sound = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        // masterVolume = soundSlider.value;
        //music = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("VolumeMusic")){

            music.volume = PlayerPrefs.GetFloat("VolumeMusic");
        }

    }

    void Update () {

        music.volume = musicSlider.value;
        sound1.volume = soundSlider.value;
        sound2.volume = soundSlider.value;
        sound3.volume = soundSlider.value;
        sound4.volume = soundSlider.value;
        sound5.volume = soundSlider.value;

        PlayerPrefs.SetFloat("VolumeMusic", musicSlider.value);


    }

}
