using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class ZonaDaMorteBehaviourScript : MonoBehaviour {

	public bool apenasOPlayer = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//verifica se apenas o play esta sendo esperado na zona de morte
		if (apenasOPlayer) {
			if (other.CompareTag ("Player")) {
				Destroy (other.gameObject);				
				GameBehaviourScript.GetInstance ().GameOver (false);
			}
		} else {
			//se atingido por qualquer objeto entao ativa o game over
			Destroy (other.gameObject);
			
			GameBehaviourScript.GetInstance ().GameOver (false);
		}



	}

}
