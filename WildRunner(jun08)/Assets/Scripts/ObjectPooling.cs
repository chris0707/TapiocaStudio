using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour {

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjectsList;

	// Use this for initialization
	void Start () {
        pooledObjectsList = new List<GameObject>();

        for(int i =0; i<pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjectsList.Add(obj);
        }
		
	}
	
    public GameObject GetPooledObject()
    {
        for(int i = 0; i<pooledObjectsList.Count; i++)
        {
            if (!pooledObjectsList[i].activeInHierarchy)
            {
                return pooledObjectsList[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjectsList.Add(obj);
        return obj;
    }
}
