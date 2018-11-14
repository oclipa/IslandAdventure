using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public static int charge = 0;
	public AudioClip collectSound;

	// HUD
	public Sprite[] hudCharge;
	public Image chargeHudGUI;

	// Generator
	public Sprite[] meterCharge;
	public Renderer meter;

	// Matches
	bool haveMatches = false;
	bool isLit = false;
	public Image matchGUI;
	public Sprite matchSprite;
	public Text textHints;

	public GameObject winObj;

	// Use this for initialization
	void Start () {
		charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CellPickup(){
		HUDon();
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		charge++;
		chargeHudGUI.sprite = hudCharge[charge];

		meter.material.mainTexture = meterCharge[charge].texture;
	}

	void HUDon() {
		if (!chargeHudGUI.enabled) {
			chargeHudGUI.enabled = true;
		}
	}

	void MatchPickup(){
		toggleMatchGUI();
		haveMatches = true;
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		matchGUI.sprite = matchSprite;
		// Image matchHUD = Instantiate(matchGUIprefab, new Vector3(0.15f, 0.1f, 0), transform.rotation) as Image;
		// Debug.Log(matchHUD.ToString());

	}

	void toggleMatchGUI() {
		matchGUI.enabled = !matchGUI.enabled;
	}

	void OnControllerColliderHit(ControllerColliderHit col){
		if (col.gameObject.name == "campfire"){
			if (haveMatches){
				LightFire(col.gameObject);
			} else if (!isLit) {
				textHints.SendMessage("ShowHint", "I could use this campfire to signal for help.  If only I could light it...");
			}
		}
	}

	void LightFire(GameObject campfire){
		ParticleSystem[] fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();

		foreach(ParticleSystem emitter in fireEmitters){
			emitter.Play();
			var emission = emitter.emission;
			emission.enabled = true;
		}

		campfire.GetComponent<AudioSource>().Play();

		Destroy(matchGUI);
		isLit = true;
		haveMatches = false;

		winObj.SendMessage("GameOver");
	}
}
