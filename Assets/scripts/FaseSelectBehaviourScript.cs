using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaseSelectBehaviourScript : MonoBehaviour {
	//nivel para qual deve ser redirecionado
	public int nivel;
	//label da fase
	public TextMesh label, lbLoading;
	//estrelas da classificaçao da fase
	public GameObject[] estrelas = new GameObject[3];


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("nivel") < nivel) {
			gameObject.GetComponent<Button> ().interactable = false;
		} else {

			int estrelas = PlayerPrefs.GetInt("estrelas_nivel_"+nivel);
			Debug.Log("Nivel -> "+nivel +" || Estrelas -> "+ estrelas);
			ExibeEstrelas(estrelas);
		
		}

		label.text = nivel.ToString();

	}
	//exibe as estrelas da fase
	public void ExibeEstrelas(int estrelas){
		for (int i = 0; i < estrelas; i++) {
			this.estrelas[i].SetActive(true);
		}
	}


	public void escolheNivel(){
        lbLoading.gameObject.SetActive(true);
		//carrega o prooximo nivel
		//GameBehaviourScript.GetInstance().CarregarNivel("nivel_"+nivel);
		GameBehaviourScript.GetInstance().CarregarNivel(nivel);
	}


}
;