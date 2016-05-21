using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {
	//pontos central da camera
	public Transform center;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((transform.position - center.position) 
			!= Vector3.zero) {
			transform.position = Vector3.Lerp(
				transform.position, center.position, Time.deltaTime * 1);
		
		}
	
	}
}
