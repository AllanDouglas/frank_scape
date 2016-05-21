using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]
public class ColchoesBehaviourScript : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D other){

		animator.SetBool ("balancando",true);


		Invoke ("ParaAnimacao",0.5f);


	}

	private void ParaAnimacao(){
		animator.SetBool ("balancando",false);

	}


}
