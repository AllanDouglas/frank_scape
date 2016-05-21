using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using GoogleMobileAds.Api;
public class GameOver2BehaviourScript : MonoBehaviour {

    public TextMesh lbTitulo, lbLoading, lbTryAgain,lbRelogio,lbMelhorTempo,lbResultado;
    public GameObject btGo, mais500;
	public GameObject[] brilhos= new GameObject[3];
	public bool showADS = true;

	private int qtdBrilhos;

	// Use this for initialization
	void Start () {
		Debug.Log (lbLoading.text);
		qtdBrilhos = GameObject.FindGameObjectsWithTag ("Brilho").Length;

		#if UNITY_ANDROID
		/*
		if(showADS){
			RequestBanner ();
		}
		*/

		//EveryplayBehaviourScript.GetInstance ().Parar ();

		#endif

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	private void RequestBanner(){
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-4743120669763384/6220544349";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
		//exibe
		bannerView.Show();
	}
	*/
	/**
	 * Exibe a interface de derrota 
	 */
	public void ShowLost(){

		lbTitulo.text = "Ops!";
		lbTryAgain.gameObject.SetActive (true);
        lbRelogio.text = "0";        
        lbMelhorTempo.text = PlayerPrefs.GetFloat(Application.loadedLevelName).ToString();
        btGo.GetComponent<Image>().enabled = false;
		btGo.GetComponent<Button>().enabled = false;

	}
    /**
     * Vai para o menu de seleção de fase
     */
    public void GoToMenu() {
        lbLoading.gameObject.SetActive(true);
        GameBehaviourScript.GetInstance().CarregarMenu();
    }


    public void ProximoNivel() {
        GameBehaviourScript.GetInstance().AvancaNivel();
    }

	/**
	 * Interface de vitoria
	 */
	public void ShowWin(float tempo){

        tempo = Mathf.Round(tempo);
        lbTitulo.text = "Muito Bem!";
        lbRelogio.text = (tempo).ToString();


        lbMelhorTempo.text = PlayerPrefs.GetFloat(Application.loadedLevelName).ToString();

		CalculaPremio (tempo);

	}

	private void CalculaPremio(float tempo){
		Debug.Log ("Iniciando o calculo do premio");
		int estrelas = 1;

		//Debug.Log (GameObject.FindGameObjectsWithTag ("Brilho").Length);
		//sempre ativa a primeira estrela
		brilhos[0].SetActive (true);



		//se pegou pelomenos um brilho entao ativa a segunda estrela
		if (GameBehaviourScript.GetInstance().relogio > 0) {
			brilhos[1].SetActive (true);
			estrelas++;
			
		}
		//se pegou todos os brilhos entao ganha as 3 estrelas
		if (GameObject.FindGameObjectsWithTag ("Brilho").Length == 0) {
			estrelas++;
			brilhos[2].SetActive (true);
			
		}

		GravaEstrelas (estrelas);
		//calcula os pontos
		float pontos = tempo * 100;

		if (estrelas == 3) {
			pontos += 500;
			mais500.SetActive(true);
		}

		lbResultado.text = pontos.ToString ();


		GravaRecord(pontos);
	
	}
	//grava quantas estrelas o jogador ganhou na partida
	private void GravaEstrelas(int estrelas){
		Debug.Log ("Iniciando a gravaçao das estrelas");
		//recupera quantas estrelas esse joga dor ja tem nessa fazer 
		//e verifica se e menor do que estamos tentando colocar agora
		if (PlayerPrefs.GetInt ("estrelas_nivel_" + Application.loadedLevel) < estrelas) {

//			PlayerPrefs.SetInt ("estrelas_" + Application.loadedLevelName,estrelas);
			PlayerPrefs.SetInt ("estrelas_nivel_" + Application.loadedLevel,estrelas);

			Debug.Log ("Gravando "+estrelas+" estrelas em "+Application.loadedLevel);

			//Debug.Log (PlayerPrefs.GetInt ("estrelas_" + Application.loadedLevelName));
		}

	}
	//grava quanto tempo o jogador levou para passar do nivel
    private void GravaRecord(float record) {

		if (record > PlayerPrefs.GetFloat(Application.loadedLevelName) |
            PlayerPrefs.GetFloat(Application.loadedLevelName) == 0)
        {

            PlayerPrefs.SetFloat(Application.loadedLevelName,record);

        }
    
            
    }

    /**
     * Exibe a interface
     */
    public void Show()
    {
        gameObject.SetActive(true);
    }

	public void RestarLevel(){
	
        lbLoading.gameObject.SetActive(true);
		Application.LoadLevel (Application.loadedLevel);
	}

}
