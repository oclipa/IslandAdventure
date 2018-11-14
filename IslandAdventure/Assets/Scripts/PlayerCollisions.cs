using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

	// private bool doorIsOpen = false;
	// private float doorTimer = 0.0f;
	private GameObject currentDoor;

	// public float doorOpenTime = 3.0f;
	// public AudioClip doorOpenSound;
	// public AudioClip doorShutSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if (doorIsOpen){
		// 	doorTimer += Time.deltaTime;

		// 	if (doorTimer > doorOpenTime){
		// 		Door(doorShutSound, false, "doorshut", currentDoor);
		// 		doorTimer = 0.0f;
		// 	}
		// }

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 3)){
			if (hit.collider.gameObject.tag == "playerDoor"){
				currentDoor = hit.collider.gameObject;
				currentDoor.SendMessage("DoorCheck");
			}
		}
	}

	// void OnControllerColliderHit(ControllerColliderHit hit) {

	// 	if (hit.gameObject.tag == "playerDoor" && doorIsOpen == false) {
	// 		currentDoor = hit.gameObject;
	// 		Door(doorOpenSound, true, "dooropen", currentDoor);
	// 	}
	// }

	// void OpenDoor(GameObject door) {
	// 	doorIsOpen = true;

	// 	door.GetComponent<AudioSource>().PlayOneShot(doorOpenSound);

	// 	door.transform.parent.GetComponent<Animation>().Play("dooropen");
	// }

	// void ShutDoor() {

	// 	currentDoor.GetComponent<AudioSource>().PlayOneShot(doorShutSound);

	// 	currentDoor.transform.parent.GetComponent<Animation>().Play("doorshut");

	// 	doorIsOpen = false;
	// }

	// void Door(AudioClip aClip, bool openCheck, string animName, GameObject door) {
	// 	doorIsOpen = openCheck;

	// 	door.GetComponent<AudioSource>().PlayOneShot(aClip);

	// 	door.transform.parent.GetComponent<Animation>().Play(animName);
	// }
}
