using UnityEngine;
using System.Collections;

public class GameBehaviourScript : MonoBehaviour {


	public enum GameStatus{
		JOGANDO, PAUSADO, MENU
	};

	public int nivelAtual = 1;

	private static GameBehaviourScript game = null;

	public GameObject gameOverUI, preVideoUI;

	public float relogio = 30;
	
	public TextMesh lbRelogio;

	public GameStatus gameStatus = GameStatus.JOGANDO;

	public bool InicarPausado = false;

	public bool eHPaisagem = false;



	public void Awake(){
// 	    PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("nivel", 1);
		//PlayerPrefs.SetInt ("estrelas_" + Application.loadedLevelName, 0);
		if (game == null) {
			game = this;
		} else {
			Debug.LogError("Existe mais de uma instancia de GameBehaviourScript");
		}

		//verifica o nivel atual
		if (PlayerPrefs.GetInt ("nivel") == 0) {
			PlayerPrefs.SetInt ("nivel", nivelAtual);
		} else {
			nivelAtual = PlayerPrefs.GetInt ("nivel");
		}

	}

    public void AvancaNivel() {
        Debug.Log(PlayerPrefs.GetInt("nivel"));
        Debug.Log(Application.loadedLevel);
        if (PlayerPrefs.GetInt("nivel") >= Application.loadedLevel) {

            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

	public static GameBehaviourScript GetInstance(){

		return game;
	}

	// Use this for initialization
	void Start () {

		/*if (PlayerPrefs.GetInt ("vidas") <= 0) {
			preVideoUI.SetActive(true);
			Pausar();
		}
		*/

		if (eHPaisagem) {
			Screen.orientation = ScreenOrientation.Landscape;
		} else {
			Screen.orientation = ScreenOrientation.Portrait;
		}

		AudioListener.volume = ((PlayerPrefs.HasKey("volume")) ? PlayerPrefs.GetInt("volume"):1);

		if (InicarPausado) {
			Pausar ();		
		} else if (gameStatus == GameStatus.MENU) {
			Time.timeScale = 1.0f;
		} 

	}
	// toca o jogo
	public void Play(){
		gameStatus = GameStatus.JOGANDO;
		Time.timeScale = 1.0f;

	}
	//parar o jogo
	public void Pausar(){
		gameStatus = GameStatus.PAUSADO;
		Time.timeScale = 0.0f;
	}

	//sai do jogo
	public void Sair(){
		Debug.Log ("saindo");
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
		if (gameStatus == GameStatus.JOGANDO & relogio > 0) {
			relogio -= Time.deltaTime;
			
			lbRelogio.text = Mathf.Round (relogio).ToString ();
		}
	}


	//levelUp
	public void LevelUP(){
		nivelAtual++;
		PlayerPrefs.SetInt ("nivel", nivelAtual);
		CarregarMenu ();
	}
	//levelUp
	public void LevelUP(int nivel){

	//	Debug.Log (nivel);
//		Debug.Log (PlayerPrefs.GetInt ("nivel"));
		nivel++;
		if (PlayerPrefs.GetInt ("nivel") < nivel) {
			Debug.Log (nivel);
			PlayerPrefs.SetInt ("nivel", nivel);
		}
		
	}

	//carregar menu de escolha de fazes
	public void CarregarMenu(){
		//carrega o menu
		CarregarNivel ("menu");
	}

	//abrir level
	public void CarregarNivel(string nivel){
		//carrega o nivel 
		Application.LoadLevel (nivel);
	}

	//abrir level
	public void CarregarNivel(int nivel){
		//carrega o nivel 
		Application.LoadLevel (nivel);
	}


	//gameover
	public void GameOver(bool vitoria,float tempo){

        gameOverUI.SetActive(true);

        if (vitoria)
        {
            gameOverUI.GetComponent<GameOver2BehaviourScript>().ShowWin(tempo);
        }
        else 
        {
            gameOverUI.GetComponent<GameOver2BehaviourScript>().ShowLost();
        }
        

	}
    //gameover
    public void GameOver(bool vitoria)
    {

        GameOver(vitoria, relogio);

    }

}
