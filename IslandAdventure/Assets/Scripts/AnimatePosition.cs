using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePosition : MonoBehaviour {

	public float xStartPosition = Screen.width / 2;
	float xEndPosition = 0.5f;
	public float speed = 1.0f;
	float startTime;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
		xEndPosition = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(Mathf.Lerp(xStartPosition, xEndPosition, (Time.time - startTime) * speed), transform.position.y, transform.position.z);
		transform.position = pos;
	}
}
