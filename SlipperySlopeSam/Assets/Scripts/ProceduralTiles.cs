using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTiles : MonoBehaviour {

	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mr. Clean")
        {
            Destroy(other.gameObject);
        }
    }

    void Update () {
		
	}
}
