using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


[RequireComponent(typeof(AudioSource))]
public class MainMenuBtns : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

	public string levelToLoad;
	public Sprite normalTexture;
	public Sprite rollOverTexture;
	public AudioClip beep;
	public bool quitButton = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData eventData){
		Image buttonImage = GetComponent<Image>() as Image;
		buttonImage.sprite = rollOverTexture;
	}

	public void OnPointerExit(PointerEventData eventData){
		Image buttonImage = GetComponent<Image>() as Image;
		buttonImage.sprite = normalTexture;
	}


	public void OnPointerDown(PointerEventData eventData){
		// required for OnPointerUp to work?
	}

	public void OnPointerUp(PointerEventData eventData){
		StartCoroutine("playSoundAndLoad");
	}

	IEnumerator playSoundAndLoad(){
		GetComponent<AudioSource>().PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);
		if(quitButton){
			Debug.Log("Quitting");
			Application.Quit();
		} else {
			if (!string.IsNullOrEmpty(levelToLoad))
				SceneManager.LoadScene(levelToLoad);
		}
	}
}
