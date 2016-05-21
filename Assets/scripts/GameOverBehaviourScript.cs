using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverBehaviourScript : MonoBehaviour {

    public TextMesh lbTitulo, lbRelogio, lbMelhorTempo, lbLoading;
    public GameObject btGo;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/**
	 * Exibe a interface de derrota 
	 */
	public void ShowLost(){

		lbTitulo.text = "You Lost";
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
        lbTitulo.text = "Win!";
        lbRelogio.text = (tempo).ToString();

        GravaRecord(tempo);

        lbMelhorTempo.text = PlayerPrefs.GetFloat(Application.loadedLevelName).ToString();


	}

    private void GravaRecord(float tempo) {

        if (tempo < PlayerPrefs.GetFloat(Application.loadedLevelName) |
            PlayerPrefs.GetFloat(Application.loadedLevelName) == 0)
        {

            PlayerPrefs.SetFloat(Application.loadedLevelName,tempo);

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
