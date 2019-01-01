using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {

    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject player;

    private float oldXPos;
    private float groundZPos = 0;

	void Start () {
        oldXPos = player.transform.position.x;
    }
	
	void Update () {

        if (player.transform.position.x >= oldXPos + 2)
        {
            Instantiate(ground, new Vector3(oldXPos + 10, ground.transform.position.y, groundZPos), ground.transform.rotation);
            groundZPos += Random.Range(-5, 5);
            oldXPos = player.transform.position.x;
        }
	}
}
