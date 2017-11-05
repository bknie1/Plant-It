using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	//-------------------------------------------------------------------------
	// Update is called once per frame
	void Update () {

	}
	//-------------------------------------------------------------------------
	void Quit_Game() {
		/* 
		 * Terminates the game.
		 */
		Debug.Log ("Quitting game.");
		UnityEngine.Application.Quit ();
	}
	//-------------------------------------------------------------------------
	public void OnCollisionEnter(Collision collisionInfo) {
		Quit_Game ();
	}
}