using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeController : MonoBehaviour {

    float i = 0;
    Vector3 initialPos;
    float distance = 5f;

   // [Range 0 to 1]
    float speed = 0.2f;

	void Start () {
        initialPos = this.transform.position;
	}
	
	void Update () {

        float inc = Mathf.Sin(i * speed);
        this.transform.position = initialPos + new Vector3(inc * distance, 0f, 0f);
        i += 0.1f;
	}
}
