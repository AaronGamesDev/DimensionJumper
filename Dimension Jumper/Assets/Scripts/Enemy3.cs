using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{

    public float speed = 2f;

    private int myPosY;

    bool goingUp = true;
    public Vector3 starting;
    public float moveDistance = 1f;


    void Update()
    {
        myPosY = (int)transform.position.y;

        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if (myPosY > starting.y + moveDistance && goingUp)//make it so the bot walks and down continuously
        {
            speed = -speed;
            goingUp = false;
        }
        else if (myPosY < starting.y - moveDistance && !goingUp)
        {
            speed = -speed;
            goingUp = true;
        }
    }
}