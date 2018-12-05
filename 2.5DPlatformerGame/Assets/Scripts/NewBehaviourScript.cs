using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private float moveInputX;
    private float moveInputNegatX;
    public Transform tran;
    public Rigidbody rb;
    public float fallMultiplier = 2;
    public float jumpSpeed;
    public bool isGrounded;
    // Use this for initialization
	void Start () {
        
        tran = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;

        }
    }
    void Update () {
        if (isGrounded == false && Input.GetKeyDown("w")) {
            

        }
        if (Input.GetKeyDown("w") && isGrounded == true) {
            isGrounded = false;
            rb.velocity = Vector3.up * jumpSpeed;
            

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;


        }
        moveInputX = Input.GetAxis("Horizontal");
        tran.Translate(moveInputX * 10 * Time.deltaTime, 0, 0);
        
	}
}
