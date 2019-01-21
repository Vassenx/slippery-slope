using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {

    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject StartingIceCube;

    private float oldZPos;
    private float groundXPos = 0;

    public float currentSlopeAmount;

    private List<GameObject> iceCubes;

	void Start () {
        oldZPos = player.transform.position.z;
        iceCubes = new List<GameObject>();
        iceCubes.Add(StartingIceCube);
    }
	
    public List<GameObject> GetIceCubes()
    {
        return this.iceCubes;
    }

	void Update () {

        if (player.transform.position.z >= oldZPos + 2)
        {
            groundXPos = (float) Random.Range(-5, 5);
            GameObject newIceCube = Instantiate(ground, new Vector3(groundXPos, ground.transform.position.y, oldZPos + 10), 
                                                Quaternion.Euler(currentSlopeAmount, ground.transform.rotation.eulerAngles.y, ground.transform.rotation.eulerAngles.z))as GameObject;
            iceCubes.Add(newIceCube);
            oldZPos = player.transform.position.z;
        }
	}
}
