using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour {

	public AudioClip lockedSound;

	public Light doorLight;

	public Text textHints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player"){

			if (Inventory.charge == 4){
				transform.Find("door").SendMessage("DoorCheck");

				if (GameObject.Find("PowerGUI")){
					doorLight.color = Color.green;
					Destroy(GameObject.Find("PowerGUI"));
				}
			}
			else if (Inventory.charge > 0 && Inventory.charge < 4) {
				transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
				textHints.SendMessage("ShowHint", "This door won't budge..guess it needs fully charging - maybe more power cells will help...");
			} else {
				transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
				textHints.SendMessage("ShowHint", "This door seems locked..maybe that generator needs some power..");
				col.gameObject.SendMessage("HUDon");
			}
		}
	}
}
