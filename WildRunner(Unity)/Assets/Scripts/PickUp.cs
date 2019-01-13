using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public int scoreToGive;

    private Scoring theScoreManager;

    

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<Scoring>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "WildBoy")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
              
        }
    }
}
