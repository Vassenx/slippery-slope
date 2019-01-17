using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTiles : MonoBehaviour {

    [SerializeField]
    private GameObject player;

	void Start () {
        this.transform.position = player.transform.position + new Vector3(0f, 2f, -20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if(other.tag == "Mr. Clean")
        {
            Destroy(other.gameObject);
        }
    }

    void Update () {
        this.transform.position = player.transform.position + new Vector3(0f,2f,-20f);
	}
}
