using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(PolygonCollider2D))]
public class GoalBehaviourScript : MonoBehaviour {

	public AudioClip somGoal;

//	public int nivel;
		
	//public float relogio = 30;
	
	//public TextMesh lbRelogio;

    public ParticleSystem goal,brilho;
	
    //private bool ativo = false;



    
	// Use this for initialization
	void Start () {
		//lbRelogio.text = relogio.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		/*verifica se todos os brilhos foram capiturados para liberar o brilho
		if (GameObject.FindGameObjectsWithTag ("Brilho").Length == 0 & brilho.isPlaying == false) {
			//ativa o brilho
			gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			brilho.Play();
		
		};

		if (ativo & relogio > 0) {
			 relogio -= Time.deltaTime;
		
			 lbRelogio.text = Mathf.Round (relogio).ToString ();
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
            //play na particula de goal
            goal.Play();
			//para o cronometro
			GameBehaviourScript.GetInstance().gameStatus = GameBehaviourScript.GameStatus.PAUSADO;
			//executa som de goal
			gameObject.GetComponent<AudioSource>().PlayOneShot(somGoal);

			//mostra a interface de passou
			Invoke(
				"Vitoria",
				1f
				);

			Destroy (other.gameObject);
		}
	}



    /**
     * Quando o objetivo é atingido
     **/
	private void Vitoria(){
//		GameBehaviourScript.GetInstance ().LevelUP (nivel);
		GameBehaviourScript.GetInstance ().LevelUP (Application.loadedLevel);
        GameBehaviourScript.GetInstance().GameOver(true);
	}


}

