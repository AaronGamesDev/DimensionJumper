using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public float speed = 2f;
    private Vector3 playerPos;

    private int playerPosX, playerPosY, myPosY, myPosX;
    bool patrol = true;

    bool goingUp = true;
    public Vector3 starting;
    bool returning = false;
    public int iStartPosX;
    public int iStartPosY;

    public float visionRadius;
    private bool chase = false;
    void start()
    {
        //starting = GameObject.Find("start").transform.position;
        //startPos = transform.position; //set starting position
        StartCoroutine(detect());
        
    }

    bool checkDetect() 
    {
        foreach(Collider2D r in Physics2D.OverlapCircleAll(transform.position, visionRadius))
        {
            if (r.gameObject.tag == "Player")
            {
                Debug.Log("detected: " + r.gameObject.name);
                patrol = false;
                return true;
            }
            Debug.Log("Patrolling");
            return false;
        }
        return false;
    }
    void Update()
    {
        int iStartPosX = (int)starting.x;
        int iStartPosY = (int)starting.y;
        playerPosX = (int)playerPos.x;
        playerPosY = (int)playerPos.y;
        myPosX = (int)transform.position.x;
        myPosY = (int)transform.position.y;


        if (patrol && !chase && !returning)
        {
            this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            if (myPosY > starting.y + 2 && goingUp)//make it so the bot walks and down continuously
            {
                speed = -speed;
                goingUp = false;
            }
            else if (myPosY < starting.y - 2 && !goingUp)
            {
                speed = -speed;
                goingUp = true;
            }

            chase = checkDetect();

        }
        else if (chase)
        {
            //Debug.Log("chasing player");    
            
            //because i change the speed in patrolling the speed variable may already be holding a negative value when being used in this statement therefore if the enemy detects the player while using the negative speed value it goes in the opposite direction trying to chase.       


            if (playerPosX > myPosX)
            {
                if(speed > 0)
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
                
            }
            else if (playerPosX < myPosX)
            {
                if (speed > 0)
                {
                    this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
            }

            if (playerPosY > myPosY)
            {
                if (speed > 0)
                {
                    this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }
                else
                {
                    this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                }
            }
            else if (playerPosY < myPosY)
            {
                if (speed > 0)
                {
                    this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                }
                else
                {
                    this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }
            }

            checkPos();
        }
        else if (returning && !chase && !patrol)
        {
            chase = false;
            patrol = false;

            Debug.Log("Returning to startX: " + iStartPosX + "myX " + myPosX + "start Y:" + iStartPosY + "myY: " + myPosY);


            if (iStartPosX > myPosX)
            {
                if(speed > 0)
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
                
            }
            else if (iStartPosX < myPosX)
            {
                if (speed > 0)
                {
                    this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
                
            }
            if (iStartPosY > myPosY)
            {
                if (speed > 0)
                {
                    this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }
                else
                {
                    this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                }
                
            }
            else if (iStartPosY < myPosY)
            {
                if (speed > 0)
                {
                    this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                }
                else
                {
                    this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                }
                
            }
            if(iStartPosX == myPosX && iStartPosY == myPosY)
            {
                returning = false;
                patrol = true;
            }
        }
    }


    void checkPos()
    {
        
        if ((myPosX > starting.x + 5 || myPosX < starting.x - 5 || myPosY > starting.y + 5 || myPosY < starting.y - 5) && !patrol) //if bot gets too far from starting position while not patrolling
        {
            chase = false;
            returning = true;
        }
        
    }

    void FixedUpdate()
    {
        playerPos = GameObject.Find("player").transform.position;
    }

    IEnumerator detect()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(detect());
    }
}
