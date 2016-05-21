using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class spawnObject : MonoBehaviour {

	public float rateSapwn;

	public float maxX, minX;
	
	private float currentRateSapwn;
	
	public int maxBloco;

	public GameObject prefab;
	
	private GameObject[] bloco;
	
		
	// Use this for initialization
	void Start () {
		bloco = new GameObject[maxBloco];
		//bloco = new List<GameObject> ();

		for (int i=0; i < maxBloco; i++) {
			
			bloco[i] = Instantiate(prefab) as GameObject;
			//bloco[i](tempBloco);
			bloco[i].SetActive(false);
			
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {

		currentRateSapwn += Time.deltaTime;
		
		if (currentRateSapwn > rateSapwn) {
			currentRateSapwn = 0;
			Spawn();
		}
		
		
	}
	
	private void Spawn(){
		

		float novoX = Random.Range (minX,maxX);

		for (int i=0; i < maxBloco; i++) {

			if(bloco[i].activeSelf == false){
				
				bloco[i].transform.position = new Vector3(novoX,
				                                          transform.position.y,
				                                          0);
				bloco[i].SetActive(true);
				break;
			}
		}



		
	}
	
	
}
