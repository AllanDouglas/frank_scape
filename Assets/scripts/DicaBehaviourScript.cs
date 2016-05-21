using UnityEngine;
using System.Collections;

public class DicaBehaviourScript : MonoBehaviour {


	public GameObject[] framesDicas;
	//controla o index atual do array
	private int index = 1;
	private int tamanho = 0;
	private GameObject dicaAtiva;
	// Use this for initialization
	void Start () {
		GameBehaviourScript.GetInstance ().Pausar ();

		tamanho = framesDicas.Length;
		dicaAtiva = framesDicas [0];


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PassarDica(){
		Debug.Log ("INDEX ATUAL " + index);
		dicaAtiva.SetActive (false);

		if (index < tamanho) {
			framesDicas [index].SetActive (true);
			dicaAtiva = framesDicas[index];
		} else {
			Iniciar();		
		}
		index++;

	}

	private void Iniciar(){
		GameBehaviourScript.GetInstance ().Play ();
		gameObject.SetActive (false);
	}

}

