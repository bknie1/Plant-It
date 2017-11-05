using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	//-------------------------------------------------------------------------
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) New_Game (); // Space
	}
	//-------------------------------------------------------------------------
	void New_Game() {
		/* Retrieves Menu Scene index.
		 * Loads the Garden (second Scene).
		 */
		Debug.Log ("Starting new game.");
		SceneManager.LoadScene ("Garden");
	}
	//-------------------------------------------------------------------------
	public void OnCollisionEnter(Collision collisionInfo) {
		New_Game ();
	}
}