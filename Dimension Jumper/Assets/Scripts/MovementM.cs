using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementM : MonoBehaviour {

    public GroundCheckM ground;
    public Rigidbody2D Martha;
    public float speed;
    public float jumpHeight;
    public bool moveStart;
    public Animator anim;
    public RigidbodyConstraints2D originalConstraints;
    public GameObject cam;
    public bool isUnderWater;

    void Start()
    {
        isUnderWater = false;
        ground = GameObject.FindGameObjectWithTag("GroundCheck").GetComponent<GroundCheckM>();
        Martha = this.GetComponent<Rigidbody2D>();
        moveStart = false;
        StartCoroutine(CanMove());
        anim = GetComponent<Animator>();
        originalConstraints = Martha.constraints;
        speed = 2.0f;
        jumpHeight = 12;
    }

    IEnumerator CanMove()
    {
        Debug.Log("CanMove");
        yield return new WaitForSeconds(0.5f);
        moveStart = true;
    }


    //Camera stuff here
    void LateUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (Martha != null)
        {
            Vector3 pos = cam.transform.position;
            pos.z = -10;
            pos.x = Martha.position.x;
            pos.y = Martha.position.y + 2;
            cam.transform.position = pos;
        }
    }

    void Update()
    {
        if (isUnderWater == true)
        {
            speed = 1.2f;
            jumpHeight = 8f;
            Martha.mass = 1;
            Martha.drag = 2;
            Martha.gravityScale = 0.9f;
        }
        else if (isUnderWater == false)
        {
            speed = 2.0f;
            jumpHeight = 12;
            Martha.mass = 1;
            Martha.drag = 2;
            Martha.gravityScale = 3;
        }
        if (moveStart == true)
        {
            float x = Input.GetAxis("Horizontal");
            //Jump
            if (ground.isGrounded && Input.GetButtonDown("Jump"))
            {
                Martha.velocity = new Vector2(Martha.velocity.x, jumpHeight);
            }
            //Idle
            if (Input.GetAxisRaw("Horizontal") == 0)
            {   
                anim.Play("Martha_Idle_2");
            }
            //Sprint
            if (Input.GetButton("Sprint"))
            {
                if(isUnderWater == true)
                {
                    speed = 1.9f;
                }
                else if(isUnderWater == false)
                {
                    speed = 3.5f;
                }
                //Left
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    if (isUnderWater == true)
                    {
                        anim.Play("Martha_Sprinting_Underwater");
                    }
                    else if (isUnderWater == false)
                    {
                        anim.Play("Martha_Sprinting");
                    }
                    Martha.velocity = new Vector2(x * speed, Martha.velocity.y);
                    Vector3 SpriteScale = transform.localScale;
                    SpriteScale.x = -3f;
                    transform.localScale = SpriteScale;
                }
                //Right
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    if (isUnderWater == true)
                    {
                        anim.Play("Martha_Sprinting_Underwater");
                    }
                    else if (isUnderWater == false)
                    {
                        anim.Play("Martha_Sprinting");
                    }
                    Martha.velocity = new Vector2(x * speed, Martha.velocity.y);
                    Vector3 SpriteScale = transform.localScale;
                    SpriteScale.x = 3f;
                    transform.localScale = SpriteScale;
                }
            }
            else
            {
                if (isUnderWater == true)
                {
                    speed = 1.2f;
                }
                else if (isUnderWater == false)
                {
                    speed = 2.0f;
                }
                //Left
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    if (isUnderWater == true)
                    {
                        anim.Play("Martha_Walking_Underwater");
                    }
                    else if (isUnderWater == false)
                    {
                        anim.Play("Martha_Walking");
                    }
                    Martha.velocity = new Vector2(x * speed, Martha.velocity.y);
                    Vector3 SpriteScale = transform.localScale;
                    SpriteScale.x = -3f;
                    transform.localScale = SpriteScale;
                }
                //Right
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    if (isUnderWater == true)
                    {
                        anim.Play("Martha_Walking_Underwater");
                    }
                    else if (isUnderWater == false)
                    {
                        anim.Play("Martha_Walking");
                    }
                    Martha.velocity = new Vector2(x * speed, Martha.velocity.y);
                    Vector3 SpriteScale = transform.localScale;
                    SpriteScale.x = 3f;
                    transform.localScale = SpriteScale;
                }
            }
        }
    }

}
