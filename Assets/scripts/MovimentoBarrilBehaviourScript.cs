using UnityEngine;
using System.Collections;

public class MovimentoBarrilBehaviourScript : MonoBehaviour {

	//velocidade de movimento 
	public float velocidade;
	//movimento por padrao e horizontal se este for marcado passa a ser vertial
	public bool movimentoVertical = false;
	//limites do movimento
	public float min, max;
	//status do movimento
	public bool mover = true;

	// Update is called once per frame
	void FixedUpdate () {

		//verifica o movimento
		if (mover) {
			//movimenta
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			//verifica o tipo de movimento
			if (!movimentoVertical) {
				//verifica se atingiu o limite
				if (transform.position.x <= min) {
					velocidade *= -1;
					transform.position = new Vector2 (min, transform.position.y);
				}
				if (transform.position.x >= max) {
					velocidade *= -1;
					transform.position = new Vector2 (max, transform.position.y);
				}
			} else {
				//verifica se atingiu o limite
				if (transform.position.y <= min) {
					velocidade *= -1;
					transform.position = new Vector2 (transform.position.x, min);
				}
				if (transform.position.y >= max) {
					velocidade *= -1;
					transform.position = new Vector2 (transform.position.x, max);
				}
			}

		}

	}

}
