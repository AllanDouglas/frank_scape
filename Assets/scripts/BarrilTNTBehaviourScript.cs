using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]
public class BarrilTNTBehaviourScript : MonoBehaviour {

	public AudioClip somDaExplosao;
	public ParticleSystem efeitoDaExplosaoPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		//ativa a animaçao de explosao
		ExibeEfeitoDeExplosao ();
		Destroy (other.gameObject);
	}
	//toca o efeito de explosao audio visual
	private void ExibeEfeitoDeExplosao(){
		//toca o som
		transform.gameObject.
			GetComponent<AudioSource> ().PlayOneShot (somDaExplosao);
		//toca o efeito
		ParticleSystem efeito = Instantiate (efeitoDaExplosaoPrefab);
		efeito.transform.position = transform.position;
		efeito.Play ();
		//remove sprite
		transform.gameObject.GetComponent<Renderer> ().enabled = false;
		//destroi particula
		Destroy (efeito, efeito.duration);
		//auto destroi
		Destroy (transform.gameObject, efeito.duration);        
        //GameOver();
        Invoke("GameOver",0.4f);

	}

    private void GameOver() {
        GameBehaviourScript.GetInstance().GameOver(false);
    }



}
