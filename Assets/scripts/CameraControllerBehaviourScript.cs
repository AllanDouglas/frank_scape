using UnityEngine;
using System.Collections;



public class CameraControllerBehaviourScript : MonoBehaviour {


	public Camera mainCamera;
	/**
	 * Objeto que sera observado pela camera depois de uma da posicao y
	 **/
	public Transform observado;

	//posicao inicial da camera quando começou  a fase
	public Vector3 posInicialCamera;

	//controla para saber se estava subindo
	private bool subiu = false;


	// Use this for initialization
	void Start () {
		posInicialCamera = mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		try{
			if( observado != null){
				//se a posicao do objeto observado for maior do que a posicao
				//do controller entao vai subindo a camera a penas na posicao y
				//
				if ( observado.position.y > transform.position.y) {

					Vector3 to = new Vector3(mainCamera.transform.position.x,
					                         observado.position.y + 3,
					                         posInicialCamera.z
					                         );

					mainCamera.transform.position = Vector3.Lerp (
						mainCamera.transform.position, to, Time.deltaTime * 1);

					subiu = true;

				}
				//caso contrario a camera deve voltar para a posicao inicial
				else if(subiu) {

					mainCamera.transform.position = Vector3.Lerp (
						mainCamera.transform.position, posInicialCamera, Time.deltaTime * 1);


					if(mainCamera.transform.position.y == posInicialCamera.y){
						subiu = false;
					}

				}
			}
		}catch(MissingReferenceException ex){
			Debug.Log("player nao encontrado");
		}
	}
}
