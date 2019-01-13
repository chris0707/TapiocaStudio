using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;

    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;


    //public GameObject[] platforms;
    private int platformSelector;
    private float[] platformWidths;

    

    public ObjectPooling[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator coinGenerator;
    public float randomCoinThreshold;

    public float randomSpikeThreshold;
    public ObjectPooling spikePool;

    //public float distanceBetweenY;


    // Use this for initialization
    void Start () {

        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i< theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x < generationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            
            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            

            //Instantiate(/*platform*/platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                float coinPoisition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f); // new Addition for spawing 1 random coin on platform.
                coinGenerator.SpawnCoins(new Vector3(transform.position.x + coinPoisition, transform.position.y + 5f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 3f, platformWidths[platformSelector] / 2f - 3f);

                Vector3 spikesPosition = new Vector3(spikeXPosition, 4.7f, 0f);

                newSpike.transform.position = transform.position + spikesPosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }


                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }

    }
}
