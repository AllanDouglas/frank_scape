using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
public class TrilhaBehaviourScript : MonoBehaviour {

	public float intervalo;

	public GameObject prefabDoTrilho;

	private float ultimoSpawn, contagemParaSpawn = 0;

	private GameObject[] trilhos = new GameObject[50];

	// Use this for initialization
	void Start () {

		for (int i = 0; i < trilhos.Length; i++) {
			trilhos[i] = Instantiate(prefabDoTrilho);

			trilhos[i].SetActive(false);

			//trilhos[i].transform.parent = transform;

		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//verifica se esta si movendo e se ja esta na hora
		bool movendo = gameObject.GetComponent<Rigidbody2D> ().IsAwake ();

		contagemParaSpawn += Time.fixedDeltaTime;

		Debug.Log (movendo);

		if (movendo && contagemParaSpawn >= intervalo) {
			//Debug.Log (contagemParaSpawn);
			contagemParaSpawn = 0;
			//Debug.Log ("movendo");
			for (int i = 0; i < trilhos.Length; i++) {	
				if(!trilhos[i].activeSelf){
					Spawn (i);
					break;
				}
			}
		} else if(!movendo){ 
			//Debug.Log ("parado");		
			Apagar();
			
		}

	}

	private void Apagar(){
		for (int i = 0; i < trilhos.Length; i++) {				
			trilhos [i].SetActive (false);
		}
	}

	private void Spawn(int index){
		trilhos [index].transform.position = transform.position;
		trilhos [index].SetActive (true);
	}
}
