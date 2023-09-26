using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{

    public float speed = 2f;

    private int myPosX;

    bool goingRight = true;
    public Vector3 starting;
    public bool facingRight = true;
    public bool facingUp = true;
    public float moveDistance = 1f;


    void Update()
    {
        myPosX = (int)transform.position.x;

        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (myPosX > starting.x + moveDistance && goingRight)//make it so the bot walks and down continuously
        {
            Flip();
            speed = -speed;
            goingRight = false;
        }
        else if (myPosX < starting.x - moveDistance && !goingRight)
        {
            Flip();
            speed = -speed;
            goingRight = true;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        //ignoreXAxis = false;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    void FlipY()
    {
        facingUp = !facingUp;
        //ignoreXAxis = true;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
}