using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(AudioSource))]
public class DisparoBarrilBehaviourScript : MonoBehaviour {
	//tipo do disparo
	public bool ehDisparoAutomatico = false;
	//status da carga
	public bool estaCarregado = false;
	//se inverte a direcao do movimento da hora da carga
	public bool inverteMovimentoNaCarga = false;
	//carga
	public GameObject carga;
	//força do disparo
	public float forcaDoDisparo;
	//local do disparo e posicionamento da camera
	public Transform localDoDisparo,localCentroDaCamera;
	//instruçoes de movimento e animaçao
	public bool paraNaCarga, paraNoDisparo, 
		centralizaCamera,
		animaNaCarga, giraAoCarregar;
	//angulo de giro apos a carga
	public int angulo;

	//controla o tempo de disparo
	private float contagem;

	//particula do disparo
	public ParticleSystem particlaDoDisparo;
	//clipe de audio disparo
	public AudioClip somDoDisparo,somDaCarga;

	//a cada frame
	public void Update(){
		//se tocar ou apertar no mouse
		if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)|| Input.GetMouseButtonDown (0)) 
		    	& ehDisparoAutomatico == false) {
			if(estaCarregado){
				Disparar();
			}

		}

		//dispara automaticamente depois de 2 segundos
		if (ehDisparoAutomatico & estaCarregado) {
			contagem += Time.deltaTime;
			if(contagem >= 0.5f){
				contagem = 0;
				Disparar();

			}
		}


	}
	//Exibe o efeito do disparo de acordo com a particula
	private void ExibeEfeitoDeDisparo(){
		if (particlaDoDisparo == null)
			throw new MissingReferenceException ("particula nao encontrada");

		ParticleSystem efeito = Instantiate (particlaDoDisparo);
		efeito.transform.position = localDoDisparo.transform.position;
		efeito.Play ();
		Destroy (efeito.gameObject, efeito.startLifetime);

	}
	//Exibe o efeito da carga de acordo com a particula
	private void ExibeEfeitoDeCarga(){
		if (particlaDoDisparo == null)
			throw new MissingReferenceException ("particula nao encontrada");
		
		ParticleSystem efeito = Instantiate (particlaDoDisparo);
		efeito.transform.position = transform.position;
		efeito.Play ();
		Destroy (efeito.gameObject, efeito.startLifetime);
		
	}

	//comportamendo para a colisao
	public void OnTriggerEnter2D(Collider2D other){

		//verifica se a colisao ocorreu com o circle
		if (other.gameObject.CompareTag ("Player")) {
			Carregar(other.gameObject);
		}
		
	}
	//carrega o disparo
	public void Carregar(GameObject objeto){
		try{
			//toca o som da carga
			PlaySomDaCarga();

			//trocar o elemento pai do player
			carga = objeto;
			carga.transform.parent = transform;
			carga.SetActive(false);
			//seta o status
			estaCarregado = true;

			if (paraNaCarga) {
				//para
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().mover = false;
			}else{
				//movimenta
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().mover = true;
			}

			//verifica se inverte o movimento na hora da carga
			if(inverteMovimentoNaCarga){
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().velocidade *= -1;
			}

			/*
			if (moveNaCarga) {
				//para
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().mover = false;
			}
			*/

			//centralizara a camera
			if(centralizaCamera){
				CentralizarCamera();
			}

			if(giraAoCarregar){
				//girar
				transform.parent.Rotate(Vector3.right + new Vector3(0,0,angulo),Space.World);
			}
			/*dispara automaticamente
			if(ehDisparoAutomatico){
				Disparar();
			}
			*/

			//afeito da carga
			ExibeEfeitoDeCarga();
			//ativa a animaçao
			if(animaNaCarga){
				transform.gameObject.GetComponent<Animator>().SetBool("mover",true);
			}


		}catch(MissingComponentException ex){
			Debug.LogError("component nao encontrado :"+ex.Message);
		}

	}
	//cetraliza a camera na posicao do barril
	private void CentralizarCamera(){
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		camera.transform.position = new Vector3 (localCentroDaCamera.position.x,
		                                         localCentroDaCamera.position.y,
		                                         camera.transform.position.z);
	}

	//dispara a carga
	public void Disparar(){

		if (!estaCarregado)
			throw new UnityException ("Nao esta carregado");


		try{

			
			//efeito de som
			PlaySomDoDisparo();

			if (paraNoDisparo) {
				//para o elemento pai
				transform.parent.gameObject.
				GetComponent<MovimentoBarrilBehaviourScript> ().mover = false;
				//para a animacao
				transform.gameObject.GetComponent<Animator>().SetBool("mover",false);
			}else{
				//movimenta
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().mover = true;
			}
			/*
			if (moveNoDisparo) {
				//movimenta
				transform.parent.gameObject.
					GetComponent<MovimentoBarrilBehaviourScript> ().mover = true;
			}
			*/

			//ativa o objeto 
			carga.SetActive (true);
			//posisiona o objeto o local de disparo
			carga.transform.position = localDoDisparo.position;
			//adiciona a força no elemento
			carga.GetComponent<Rigidbody2D> ().AddForce (
				transform.up * forcaDoDisparo,ForceMode2D.Impulse

			);
			//efeito do disparo
			try{
				ExibeEfeitoDeDisparo();
			}catch(MissingReferenceException ex){
				Debug.LogException(ex);
			}


			carga.transform.parent = null;

			estaCarregado = false;
			//valta a posicao inicial de rotaçao se for o caso
			if(giraAoCarregar){
				//girar
				transform.parent.Rotate(Vector3.right - new Vector3(0,0,angulo),Space.World);
			}


		}catch(MissingComponentException ex){
			Debug.LogError("component nao encontrado :"+ex.Message);
		}

	}
	//toca o  som do disparo
	private void PlaySomDoDisparo(){
		AudioSource audioSource = transform.gameObject.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (somDoDisparo);
	}
	//toca o  som do disparo
	private void PlaySomDaCarga(){
		AudioSource audioSource = transform.gameObject.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (somDaCarga);
	}


}
