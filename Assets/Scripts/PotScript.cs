using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : MonoBehaviour {

	private GameObject GameManager;
	public GameObject sprout1;
	public GameObject sprout2;
	public GameObject flower;
	private GameObject[] nextObj;
	private int curObj = 0;
	private bool state = false;
	private Vector3 offset = new Vector3 (0.0f, 0.15f, 0.0f);
	private GameObject oldObj;
	private AudioSource aS;
	public AudioClip col;
	public AudioClip seed;
	public AudioClip water;
	public AudioClip sun;
	public AudioClip hand;
	private AudioClip toPlay;

	void Start(){
		aS = this.gameObject.GetComponent<AudioSource> ();
		GameManager = GameObject.Find ("GameManager");
		nextObj = new GameObject[3];
		nextObj [0] = sprout1;
		nextObj [1] = sprout2;
		nextObj [2] = flower;
	}

	// When collided with, increases number of plants, spawns plant, and destroys collided object
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Thrown" && state == false) {
			if (oldObj) {
				Destroy (oldObj);
			}
			switch (other.gameObject.name) {
			case "SeedParent":{aS.PlayOneShot(seed); break;}
			case "WaterParent":{aS.PlayOneShot(water); break;}
			case "SunParent":{aS.PlayOneShot(sun);	break;}
			case "GrabParent":{aS.PlayOneShot(hand); break;}
			}
			Destroy (other.gameObject);
			GameManager.GetComponent<Game_Manager> ().incPlantCount ();
			oldObj = Instantiate(nextObj[curObj], (this.transform.position + offset), Quaternion.identity);
			state = true;
		}
		else {aS.PlayOneShot(col);}
	}

	// Allows pots to move to the next model
	public void resetPot(){
		state = false;
		curObj++;
	}
}
