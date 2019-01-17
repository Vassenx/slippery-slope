using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {

    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject player;

    private float oldZPos;
    private float groundXPos = 0;

	void Start () {
        oldZPos = player.transform.position.z;
    }
	
	void Update () {

        if (player.transform.position.z >= oldZPos + 2)
        {
            groundXPos = (float) Random.Range(-5, 5);
            Instantiate(ground, new Vector3(groundXPos, ground.transform.position.y, oldZPos + 10), ground.transform.rotation);
            oldZPos = player.transform.position.z;
        }
	}
}
