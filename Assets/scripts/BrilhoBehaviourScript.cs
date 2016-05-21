using UnityEngine;
using System.Collections;

public class BrilhoBehaviourScript : MonoBehaviour {

	public AudioClip som;

	private static AudioSource audioSource;

	// Use this for initialization
	void Start () {
		if (audioSource == null) {
			audioSource = GameBehaviourScript.GetInstance ().gameObject.GetComponent<AudioSource> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	 **Quando colidir
	 */
	public void OnTriggerEnter2D(Collider2D other){

		audioSource.PlayOneShot (som);
		transform.parent.gameObject.SetActive(false);
		//Destroy ();

	}

}
