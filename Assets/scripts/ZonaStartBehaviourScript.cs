using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ZonaStartBehaviourScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(other.gameObject);
        GameBehaviourScript.GetInstance().CarregarMenu();

    }

}
