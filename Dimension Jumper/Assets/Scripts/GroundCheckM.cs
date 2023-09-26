using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckM : MonoBehaviour {

    public bool isGrounded;
    public bool inJump;
    public Transform phantom;
    public Rigidbody2D rigid;
    public MovementM movement;
    void Start()
    {
        isGrounded = true;
        InvokeRepeating("InstanceReferenceCheck", 0.1f, 0.5f);
    }

    void InstanceReferenceCheck()
    {
        rigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementM>();
    }

    void Update()
    {
        if (rigid != null)
        {
            phantom = GameObject.FindGameObjectWithTag("Player").transform;
            if (phantom == null)
            {
                phantom = GameObject.FindGameObjectWithTag("Player").transform;
            }
            this.transform.position = new Vector3(phantom.transform.position.x, phantom.transform.position.y - 0.65f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "PlatformWall")
        {
            isGrounded = true;
            inJump = false;
        }
        else
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "PlatformWall")
        {
            isGrounded = false;
            inJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "PlatformWall")
        {
            isGrounded = true;
            inJump = false;
        }
    }

}
