using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Button))] 
[RequireComponent (typeof(Image))] 

public class BtMuteBehaviourScript1 : MonoBehaviour {

	//public AudioListener audioListener;

	public Sprite somLigado, somDesligad;

	private bool estaMudo = false;

	void Start(){

		if (PlayerPrefs.HasKey ("volume")) {
			Debug.Log (PlayerPrefs.GetInt("volume"));
			switch(PlayerPrefs.GetInt("volume")){
				case 1: LigaDesliga(true); break;
				case 0: LigaDesliga(false);break;
			}

		}

	}

	public void Mute(){

		estaMudo = !estaMudo;
		Debug.Log (estaMudo);
		LigaDesliga (estaMudo);



	}

	private void LigaDesliga(bool liga){

		if (!liga) {
			Debug.Log ("como e");
			AudioListener.volume = 0;
			
			gameObject.GetComponent<Image>().sprite = somDesligad;
			
			PlayerPrefs.SetInt("volume",0);
			
		} else {
			Debug.Log ("oi");
			AudioListener.volume = 1;
			
			PlayerPrefs.SetInt("volume",1);
			
			gameObject.GetComponent<Image>().sprite = somLigado;
		}
		
		estaMudo = liga;
	}


}
