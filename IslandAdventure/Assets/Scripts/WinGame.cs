using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class WinGame : MonoBehaviour {

	public GameObject winSequence;
	public Image fader;
	public AudioClip winClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GameOver(){
		GetComponent<AudioSource>().PlayOneShot(winClip);
//		AudioSource.PlayClipAtPoint(winClip, transform.position);

		GameObject winObj = Instantiate(winSequence) as GameObject;
 		winObj.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

		yield return new WaitForSeconds(8.0f);

		Image fadeImage = Instantiate(fader) as Image;
 		fadeImage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
	}
}
