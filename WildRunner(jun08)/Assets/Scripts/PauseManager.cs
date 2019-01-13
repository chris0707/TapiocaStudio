using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public bool canPause;
    public bool canSound;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject hiScoreCopy;
    public GameObject soundPanel;
    public GameObject settingsPanel;

    public GameObject instructionPanel1;
    public GameObject instructionPanel2;
    public GameObject instructionPanel3;

    public GameObject ip1;
    public GameObject ip2;
    public GameObject ip3;

    public GameObject scorePanel;

    private Scoring scoreManager;
    private PlayerController playerController;


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
    


    void Awake () { //it was void Start before
        Time.timeScale = 0;
        music.volume = PlayerPrefs.GetFloat("VolumeMusic");
        sound1.volume = PlayerPrefs.GetFloat("VolumeSound");
        musicSlider.value = music.volume;
        soundSlider.value = sound1.volume;


        canPause = true;
        pausePanel.SetActive(false);
        ip1.SetActive(true);
        pauseButton.SetActive(false);
        hiScoreCopy.SetActive(false);
        scorePanel.SetActive(false);
        scoreManager = FindObjectOfType<Scoring>();
        playerController = FindObjectOfType<PlayerController>();
       
       
        

    }
    
    public void Pause () {
        
        Time.timeScale = 0;
        canPause = false;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        hiScoreCopy.SetActive(false);
        playerController.runSound.mute = true;
        //soundPanel.SetActive(false);


    }

    public void Resume() {

        Time.timeScale = 1;
        canPause = true;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        hiScoreCopy.SetActive(true);
        soundPanel.SetActive(true);
        playerController.runSound.mute = false;

    }

    public void Restart(int sceneIndex) {

        
        SceneManager.LoadScene(sceneIndex);
        scoreManager.scoreIncrease = false;
        Time.timeScale = 1;
        StartCoroutine("RestartDelay");
        //scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
        

    }

    public void Menu(int sceneIndex) //Optional to add start coroutine for delay so it wouldnt show score:0 before transitioning to the main menu
    {
        scoreManager.scoreIncrease = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
       
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }

    public void GoBack()
    {
        settingsPanel.SetActive(false);
    }

    public void Instructions()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
        instructionPanel1.SetActive(true);
        

    }

    public void InstructionsExit()
    {
        pausePanel.SetActive(true);
        settingsPanel.SetActive(true);
        scorePanel.SetActive(true);
        instructionPanel1.SetActive(false);
        instructionPanel2.SetActive(false);
        instructionPanel3.SetActive(false);

    }

    public void InstrucitonsStartExit() {
        instructionPanel1.SetActive(false);
        instructionPanel2.SetActive(false);
        instructionPanel3.SetActive(false);

        ip1.SetActive(false);
        ip2.SetActive(false);
        ip3.SetActive(false);
        scorePanel.SetActive(true);



    }

    public void Instructions1Next() {

        instructionPanel2.SetActive(true);
        instructionPanel1.SetActive(false);
        

    }

    public void Instruction2Next()
    {
        instructionPanel3.SetActive(true);
        instructionPanel2.SetActive(false);
        

    }

    public void Instruction2Prev() {

        instructionPanel1.SetActive(true);
        instructionPanel2.SetActive(false);
        
    }

    public void Instruction3Prev()
    {
        instructionPanel2.SetActive(true);
        instructionPanel3.SetActive(false);
        
    }

    //alksdjlkajdlkasjdlkjsdklaskdjlkajdklasjdlkasjdlkajdlkas

    public void In1Next()
    {

        ip2.SetActive(true);
        ip1.SetActive(false);

    }

    public void In2Next()
    {

        ip3.SetActive(true);
        ip2.SetActive(false);

    }

    public void In2Prev()
    {

        ip1.SetActive(true);
        ip2.SetActive(false);
    }

    public void In3Prev()
    {

        ip2.SetActive(true);
        ip3.SetActive(false);
    }





    public void VolumeControl() {
        music.volume = musicSlider.value;
        


        PlayerPrefs.SetFloat("VolumeMusic", music.volume);

    }

    public void MusicControl() {
        sound1.volume = soundSlider.value;
        sound2.volume = soundSlider.value;
        sound3.volume = soundSlider.value;
        sound4.volume = soundSlider.value;
        sound5.volume = soundSlider.value;


        PlayerPrefs.SetFloat("VolumeSound", sound1.volume);

    }

    IEnumerator RestartDelay()
    {
        
            yield return 0.3;
        scoreManager.scoreCount = 0;
    }


}
