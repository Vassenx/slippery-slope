using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTiles : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    GameObject LevelGenerator;

    void Start () {
        this.transform.position = player.transform.position + new Vector3(0f, 2f, -20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mr. Clean")
        {
            Destroy(other.gameObject);

        }
        
        //if it is an ice cube, remove from the list of active ice cubes in scene
        if(other.GetComponent<IceCubeController>() != null)
        {
            LevelGenerator.GetComponent<ProceduralGenerate>().GetIceCubes().Remove(other.gameObject);
        }
    }

    void Update () {
        this.transform.position = player.transform.position + new Vector3(0f,2f,-20f);
	}
}
