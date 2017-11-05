using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

	public int throwCount = 0;
	private int potCount = 0		;
	private int plantCount = 0;
	private GameObject MainCamera;
	private GameObject[] toChange;
	private int maxPots = 16;
	public GameObject pot;
	private Vector3 curVector = new Vector3 (4.0f, 4.5f, -4.0f);
	private float xMod = -1.0f;
	private float zMod = 1.0f;
	private int total = 0;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("Main Camera");
		toChange = new GameObject[16];
	}
	
	// Update is called once per frame
	void Update () {
		if (total == maxPots * 4) { // All plants gathered, game over
			SceneManager.LoadScene ("Game_Over");
		}
		if (plantCount == maxPots) { // If all pots are filled, move to next stage.
			nextStage ();
		}
		if (potCount + 1 <= maxPots) { // Instantiates a 4 x 4 grid of pots
			Instantiate (pot, curVector, Quaternion.identity); 
			curVector.x += xMod;
			if ((potCount + 1) % 4 == 0) {
				curVector.z += zMod;
				curVector.x = 4.0f;
			}
			potCount++;
		}
	}

	// Move to next stage, return plant count to 0, change throwing object, reset pot state, move pots to next stage.
	private void nextStage(){
		plantCount = 0;
		MainCamera.GetComponent<Seed_Launcher> ().incThrowObj();
		toChange = GameObject.FindGameObjectsWithTag ("Pot");
		foreach (GameObject obj in toChange){
			obj.GetComponent<PotScript> ().resetPot ();
		}
	}

	public void incThrowCount(){
		throwCount++;
	}

	public void incPlantCount(){
		plantCount++;
		total++;
	}
}