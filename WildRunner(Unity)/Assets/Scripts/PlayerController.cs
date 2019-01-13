using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 71 


public class PlayerController : MonoBehaviour {

	public float jumpForce = 3f;
	public float runningSpeed = 20f;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMileStoneCount;

	private Rigidbody2D rigidBody;
	public static PlayerController instance;
    public float raycastLength = 1f;
    public bool canJump = false;
    
    public GameObject deathPanel;
    public GameObject pauseButton;
    public GameObject hiScoreText;
    public GameObject scoreText;
    public GameObject hiScoreTextCopyGameObject;
    public GameObject soundObject;


    private Animator animator;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource runSound;
    public AudioSource foodSound;
    public AudioSource splatSound;
    public AudioSource poopSound;
    public static int loadCount = 0;
    bool toggleRunsound;
    public bool toggleDeath = false;
    Scoring scoreManager;

    InterstitialAd interstitial;

    




    // Use this for initialization
    void Start () {
        //Time.timeScale = 1;
        
        RequestInterstitial();
        scoreManager = FindObjectOfType<Scoring>();
        scoreManager.scoreCount = 0;
        hiScoreTextCopyGameObject.SetActive(false);
       // hiScoreText.SetActive(true);
        deathPanel.SetActive(false);
        soundObject.SetActive(true);

        rigidBody = GetComponent<Rigidbody2D> ();
		instance = this;
        animator = GetComponent<Animator>();
        runSound = GetComponent<AudioSource>();

        speedMileStoneCount = speedIncreaseMilestone;
       

    }

	void Update () {
        

           if (toggleRunsound == true && !runSound.isPlaying) {
           
            runSound.Play();

            toggleRunsound = false;

       

            }
            else if(toggleRunsound == false || toggleDeath == true && runSound.isPlaying)
            {
            runSound.Stop();

            }
        
        if (transform.position.x > speedMileStoneCount)
        {
            speedMileStoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            runningSpeed = runningSpeed * speedMultiplier;
        }

        if (rigidBody.velocity.x < runningSpeed )
        {
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
        animator.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetMouseButtonDown(0)) {
            
			Jump ();
		}

		if (isGrounded ()) {
            canJump = true;
            

        }
        else if(!isGrounded()){
            animator.SetBool("onground", false);

        } else if (canDoubleJump)
        {
            //animator.SetBool("ondoublejump", true);
        }

       /* Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0) {
            Die();
        }

        Vector2 screenPosition2 = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition2.x > Screen.width || screenPosition2.x < 0) {
            Die();
        }*/
	}

	void Jump () {
       
        /*if (canJump == true && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //For mobile touch
        {


            if (isGrounded() || canDoubleJump)
            {

                jumpSound.Play();
                
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("ondoublejump", false);
                if (!isGrounded())
                {
                    jumpSound.Play();
                    canDoubleJump = false;
                    canJump = false;
                    animator.SetBool("ondoublejump", true);
                }
            }
        }*/

        if (canJump == true && !EventSystem.current.IsPointerOverGameObject()) //For Pc click
        {


            if (isGrounded() || canDoubleJump)
            {

                jumpSound.Play();

                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("ondoublejump", false);
                if (!isGrounded())
                {
                    jumpSound.Play();
                    canDoubleJump = false;
                    canJump = false;
                    animator.SetBool("ondoublejump", true);
                }
            }
        }
    }

	public LayerMask groundLayer;
	public bool canDoubleJump = false;

    public bool isGrounded() {

        if (Physics2D.Raycast(this.transform.position, Vector2.down, raycastLength, groundLayer.value)) {
            //if (!runSound.isPlaying)
            //{
                // runSound.Play();
                toggleRunsound = true;
           // }

            animator.SetBool("onground", true);
            canDoubleJump = true;
            animator.SetBool("ondoublejump", false);

            return true;
        } 

        else {
            //runSound.Stop();
            toggleRunsound = false;
            animator.SetBool("ondoublejump", true);
            return false;
            
        } 

        
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            if (!foodSound.isPlaying) {
                foodSound.Play();
            }

        }
       
        if(collision.gameObject.tag == "killBox")
        {
            if (!splatSound.isPlaying)
            {
                loadCount++;
                splatSound.Play();
                Die();

            }
            
        }

        if (collision.gameObject.tag == "poop") {
            if (!poopSound.isPlaying)
            {
                loadCount++;
                poopSound.Play();
                Die();
            }
        }
    }


    void Die() {
        //animator.SetBool("ondoublejump", true);
        

        runSound.mute = true;
        soundObject.SetActive(false);
        deathPanel.SetActive(true);
        pauseButton.SetActive(false);
        hiScoreText.SetActive(false);
        scoreText.SetActive(false);
        
        Time.timeScale = 0;
        if (loadCount % 3 == 0)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
            else {
                return;
            }

        }


    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
         interstitial = new InterstitialAd(adUnitId);


        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);



    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }



}
