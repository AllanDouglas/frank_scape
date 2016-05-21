using UnityEngine;
using System.Collections;

public class MovimentacaoGerenciadorBehaviourScript1 : MonoBehaviour {

	public MovimentoBarrilBehaviourScript[] barris;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		int tamanho = barris.Length;
		int i = 0;
		MovimentoBarrilBehaviourScript barril;
		while (i < tamanho) {
			barril = barris[i];

			//i++;

			//verifica o movimento
			if (barril.mover) {
				//movimenta
				transform.Translate (Vector2.right * barril.velocidade * Time.deltaTime);
				//verifica o tipo de movimento
				if (!barril.movimentoVertical) {
					//verifica se atingiu o limite
					if (transform.position.x <= barril.min) {
						barril.velocidade *= -1;
						transform.position = new Vector2 (barril.min, transform.position.y);
					}
					if (transform.position.x >= barril.max) {
						barril.velocidade *= -1;
						transform.position = new Vector2 (barril.max, transform.position.y);
					}
				} else {
					//verifica se atingiu o limite
					if (transform.position.y <= barril.min) {
						barril.velocidade *= -1;
						transform.position = new Vector2 (transform.position.x, barril.min);
					}
					if (transform.position.y >= barril.max) {
						barril.velocidade *= -1;
						transform.position = new Vector2 (transform.position.x, barril.max);
					}
				}
			
			}
		}
	}
}
