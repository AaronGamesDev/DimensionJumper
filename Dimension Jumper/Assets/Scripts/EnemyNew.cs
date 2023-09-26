using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyNew : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 playerPos;
    private int playerPosX, playerPosY, myPosY, myPosX;

    void start()
    {
        
    }

    void Update()
    {
        playerPosX = (int)playerPos.x;
        playerPosY = (int)playerPos.y;
        myPosX = (int)transform.position.x;
        myPosY = (int)transform.position.y;

        //Debug.Log(playerPos.x);

        if (playerPosX > myPosX)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (playerPosX < myPosX)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (playerPosY > myPosY)
        {
            this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (playerPosY < myPosY)
        {
            this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }


    void FixedUpdate()
    {
        playerPos = GameObject.Find("player").transform.position;
    }
}

    
   