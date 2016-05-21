using UnityEngine;
using System.Collections;

public class SairBehaviourScript : MonoBehaviour {

	public void Sair(){
		/*
	#if UNITY_ANDROID
		AdsBehaviourScript.GetInstance ().Show (Saindo);
	#else
		Application.Quit ();
	#endif
*/
		Saindo ();
	}


	private void Saindo(){
		Application.Quit ();
	}

}
