using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDeletePoint;

	// Use this for initialization
	void Start () {

        platformDeletePoint = GameObject.Find("PlatformDestructionPoint");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x < platformDeletePoint.transform.position.x)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
		
	}
}
