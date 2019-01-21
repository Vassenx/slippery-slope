using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    Vector3 inputs;
    float speed = 5f;
    float jumpSpeed = 5f;
    bool onGround = true;

    [SerializeField]
    public LayerMask Ground;

    Vector3 blenderOffset = new Vector3(-90f, 0f, 0f);

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update () {

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        if (inputs != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputs), 0.15F);
        }

        onGround = Physics.CheckSphere(this.transform.position, 0.2f, Ground, QueryTriggerInteraction.Ignore);

        if (Input.GetButtonDown("Jump") && onGround && rb != null)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
        }

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, -(transform.up), out hit, 0.1f, Ground))//yourDistanceToGroundYouWant, yourGroundLayers))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(inputs * speed * Time.deltaTime, Space.World);
    }

    public void FreezePlayer()
    {
        Destroy(rb);
    }
}
