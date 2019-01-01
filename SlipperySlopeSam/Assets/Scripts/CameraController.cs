using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject player;
    float speed = 0.5f;
    Vector3 offset;

    void Start() {
        offset = this.transform.position - player.transform.position;
    }

    //after the player's position was updated in Update
    void LateUpdate () {
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        //scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        //transform.Translate(0, 0, scroll * speed, Space.Self);

        if (player == null) return;
        this.transform.position = Vector3.Slerp(this.transform.position, player.transform.position + offset, speed);
        transform.LookAt(player.transform);
    }
}
