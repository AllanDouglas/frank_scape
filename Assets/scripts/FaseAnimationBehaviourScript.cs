using UnityEngine;
using System.Collections;
[RequireComponent (typeof(TextMesh))]
public class FaseAnimationBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<TextMesh> ().text += " " + Application.loadedLevel;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Destroi(){
		Destroy (gameObject);
	}
}
