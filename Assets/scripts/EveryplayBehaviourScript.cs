using UnityEngine;
using System.Collections;

public class EveryplayBehaviourScript : MonoBehaviour {

#if UNITY_ANDROID

	//public TextMesh debugText;

	private static EveryplayBehaviourScript instance;

	void Awake(){
	
		if (instance == null) {
			instance = this;
		}
	
	}

	public static EveryplayBehaviourScript GetInstance(){
		return instance;
	}

	
	// Use this for initialization
	void Start () {
		if (Everyplay.IsSupported () &
			Everyplay.IsRecordingSupported ()) {
			Parar();
			Iniciar ();

		} else {
			//debugText.gameObject.SetActive(true);
			//debugText.text = "Nao e possivel iniciar a gravacao";
		}

	}

	//para a gravaçao
	public void Parar(){
		if (Everyplay.IsRecording ()) {
			Everyplay.StopRecording ();
		}
	}

	//compartilhar
	public void Compartilhar(){

		Parar ();

		if (!Everyplay.IsRecording()) {
			//setando meta dados
			Everyplay.SetMetadata("level",Application.loadedLevel);
			Everyplay.SetMetadata("score",PlayerPrefs.GetFloat(Application.loadedLevelName));
			Everyplay.ShowSharingModal();
		} else {
		//	debugText.gameObject.SetActive(true);
		//	debugText.text = "Nao e possivel iniciar a gravacao";
			throw new UnityException("Nao e possivel compatilhar o video");
		}

	}

	//inicia a gravaçao
	private void Iniciar(){
		Debug.Log ("Gravacao iniciada");
		Everyplay.StartRecording ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
#endif
}
