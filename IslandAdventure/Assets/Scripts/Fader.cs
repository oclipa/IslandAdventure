using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	public Image loadGUI;

	// Use this for initialization
	void Start () {
		//Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadAnim(){
		Image loadingImage = Instantiate(loadGUI) as Image;
 		loadingImage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
	}
}
