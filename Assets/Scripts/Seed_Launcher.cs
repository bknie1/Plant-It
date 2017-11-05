using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_Launcher : MonoBehaviour {

	private GameObject GameManager;
	private GameObject objToThrow;
	public GameObject seed;
	public GameObject water;
	public GameObject lightobj;
	public GameObject grab;
	private float velocity = 10.0f;
	private float timer = 10.0f;
	private Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
	private GameObject[] throwObjs;
	private int throwObj;

	// Start is called on creation
	void Start(){
		GameManager = GameObject.Find ("GameManager");
		throwObjs = new GameObject[4];
		throwObjs [0] = seed;
		throwObjs [1] = water;
		throwObjs [2] = lightobj;
		throwObjs [3] = grab;
		throwObj = 0;
		objToThrow = throwObjs [throwObj];
	}

	// Update is called once per frame
	// Spawns a ball and assigns direction based on user input.
	void Update () {
		if (GvrControllerInput.ClickButtonDown || GvrControllerInput.AppButtonDown || Input.anyKeyDown) {Spawn_Obj ();}
	}

	// Moves to next object.
	public void incThrowObj(){
		throwObj++;
		objToThrow = throwObjs[throwObj];
	}

	// Creates an object, destroys after delay.
	private void Spawn_Obj() {
		GameManager.GetComponent<Game_Manager> ().incThrowCount ();
		GameObject obj = Instantiate (objToThrow);
		obj.transform.position = this.gameObject.transform.position - offset; // Sets ball position on camera.
		Rigidbody rb = obj.GetComponentInChildren<Rigidbody> ();
		rb.velocity = this.gameObject.transform.rotation * Vector3.forward * velocity; 	// Launches ball in camera direction.
		Destroy(obj, timer);
	}
}