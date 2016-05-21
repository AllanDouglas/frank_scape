using UnityEngine;
using System.Collections;

public class BtCompartilharVideoBehaviourScript : MonoBehaviour {

#if UNITY_ANDROID
	public void Compartilhar(){

		EveryplayBehaviourScript.GetInstance ().Compartilhar ();

	}
#endif

}
