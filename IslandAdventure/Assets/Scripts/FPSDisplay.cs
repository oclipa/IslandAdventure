using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSDisplay : MonoBehaviour {

	int frames = 0;
	float fps = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		frames++;
		fps = Mathf.Round(frames / Time.realtimeSinceStartup);
		GetComponent<Text>().text = "Frames per Second: " + fps.ToString();
	}
}
