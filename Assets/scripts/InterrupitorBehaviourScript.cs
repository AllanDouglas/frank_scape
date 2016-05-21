using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(PolygonCollider2D))]
[RequireComponent (typeof(AudioSource))]

public class InterrupitorBehaviourScript : MonoBehaviour {
	//barril que sera ligado 
	public GameObject barril;
	//som de quando e ativado
	public AudioClip som;
	//marcaçao de desativaçao
	public GameObject marcacao;
    //laser de marcação
    public LineRenderer laser;

    //estado original do do movimento
    private bool movimentoOriginal = false;

	// Use this for initialization
	void Start () {
		//torna o barril imovel e as colisoes
        movimentoOriginal = barril.transform.parent.GetComponent<MovimentoBarrilBehaviourScript>().mover;    
		barril.transform.parent.GetComponent<MovimentoBarrilBehaviourScript>().mover = false;
		barril.GetComponentInChildren<PolygonCollider2D> ().enabled = false;

        //faz a ligação do laser
        //laser.SetPosition(0, transform.position);
        //laser.SetPosition(1, barril.transform.position);
		//posiciona a marcaçao para o local do barril
		marcacao = Instantiate (marcacao);
		Vector3 position = new Vector3 (
			barril.transform.position.x,
			barril.transform.position.y,
			barril.transform.position.z - 1
			);
		marcacao.transform.position = position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			Ativar();

		}

	}
	//ativa o gatilho
	private void Ativar(){
        //apagao laser
        laser.enabled = false;
		//troca a animaçao
		Animator anim = gameObject.GetComponent<Animator>();
		anim.SetBool ("ativar",true);
		//destroi a marcaçao
		Destroy (marcacao);
		//move o barril
		barril.transform.parent.GetComponent<MovimentoBarrilBehaviourScript>().mover = movimentoOriginal;
		barril.GetComponentInChildren<PolygonCollider2D> ().enabled = true;
		//destroi o catilho
		Destroy (transform.parent.gameObject, 3);
	}


}
