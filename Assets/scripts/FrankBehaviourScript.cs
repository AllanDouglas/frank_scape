using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(AudioSource))]
public class FrankBehaviourScript : MonoBehaviour {

	public bool grounded = false;

	public float forcaPulo = 0;

	public AudioClip somDoPulo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if( (Input.touchCount > 0 | Input.GetMouseButton(0)) & grounded){

			Pular();

		}

	}
	//faz o objeto saltar
	private void Pular(){
		grounded = false;
		gameObject.GetComponent<Rigidbody2D>().
			AddForce (Vector2.up * forcaPulo,ForceMode2D.Impulse);

		gameObject.GetComponent<AudioSource> ().PlayOneShot(somDoPulo);

	}

	public void OnColliderEnter2D(Collision2D other){
		gameObject.GetComponent<AudioSource> ().PlayOneShot(somDoPulo);
	}

}
