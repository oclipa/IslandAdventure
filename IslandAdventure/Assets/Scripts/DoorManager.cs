using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;
	// private GameObject currentDoor;

	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;

	// Use this for initialization
	void Start () {
		doorTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (doorIsOpen){
			doorTimer += Time.deltaTime;

			if (doorTimer > doorOpenTime){
				Door(doorShutSound, false, "doorshut");
				doorTimer = 0.0f;
			}
		}		
	}

	void DoorCheck(){
		if (!doorIsOpen){
			Door(doorOpenSound, true, "dooropen");
		}
	}

	void Door(AudioClip aClip, bool openCheck, string animName) {
		doorIsOpen = openCheck;

		transform.gameObject.GetComponent<AudioSource>().PlayOneShot(aClip);

		transform.parent.gameObject.GetComponent<Animation>().Play(animName);
	}
}
