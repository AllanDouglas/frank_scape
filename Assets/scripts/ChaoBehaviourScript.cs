using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]
public class ChaoBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<FrankBehaviourScript>().grounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D other){
		
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<FrankBehaviourScript>().grounded =false;
		}
		
	}


}
