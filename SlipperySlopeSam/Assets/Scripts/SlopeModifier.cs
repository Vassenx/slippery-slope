using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeModifier : MonoBehaviour {

    public float slopeAmount = 0;
    public GameObject player;

    [SerializeField]
    GameObject LevelGenerator;

    private Renderer rend;

    private float currentPosition = 0;
    private float startTime = 0;

    private bool startSlerp = false;
    private GameObject mainCamera;

    void Start () {
        startSlerp = false;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rend = this.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && startSlerp == false)
        {
            startSlerp = true;
            startTime = Time.time;

            mainCamera.GetComponent<CameraShaker>().StartEarthquake();

            //for the next tiles created are the same slope
            LevelGenerator.GetComponent<ProceduralGenerate>().currentSlopeAmount = this.slopeAmount;

            rend.enabled = false;
        }
    }

    void Update () {

        if (startSlerp)
        {
            foreach (GameObject iceCube in LevelGenerator.GetComponent<ProceduralGenerate>().GetIceCubes())
            {
                currentPosition = (Time.time - startTime) / 2f;
                iceCube.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(slopeAmount, 0f, 0f), currentPosition);
            }
            Debug.Log(currentPosition);
            if (currentPosition >= 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
