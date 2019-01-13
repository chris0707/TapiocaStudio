using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

	public static GroundManager instance;
	public Transform levelStartPoint;
	public List<GroundSpawn> levelPrefabs = new List<GroundSpawn>(); 
	public List<GroundSpawn> pieces = new List<GroundSpawn>(); 


	void Awake (){
		instance = this;
	}

	void Start (){
		GenerateInitialPieces ();
	}

	public void GenerateInitialPieces (){
		for (int i = 0; i < 10; i++) {
			AddPiece ();
		}
	}

	public void AddPiece (){

		int randomIndex = Random.Range (0, levelPrefabs.Count-1);

		GroundSpawn piece = (GroundSpawn)Instantiate (levelPrefabs [randomIndex]);
		piece.transform.SetParent (this.transform, false); 

		Vector3 spawnPosition = Vector3.zero;

		if (pieces.Count == 0) {
			spawnPosition = levelStartPoint.position;
		} else {
			spawnPosition = pieces [pieces.Count-1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add (piece);
	}
}
