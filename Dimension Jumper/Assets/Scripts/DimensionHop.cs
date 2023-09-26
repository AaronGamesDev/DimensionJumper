using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DimensionHop : MonoBehaviour
{
    public GameObject dimension1, dimension2, dimension3, player, dim1Tracking, dim2Tracking, dim3Tracking, endGameTracking;
    public MovementM movementM;
    TrackDimension track1, track2, track3, endGame;
    public int currentDim = 0;
    public float cooldownTime = 1f;
    private bool cooldownActive = false;
    public bool[] unlockedDims = new bool[3];
    public bool[] withinTrigger = new bool[3];

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.Find("Dimension 1") != null)//check is dimension 1 exists
        {
            dimension1 = GameObject.Find("Dimension 1");//set dimension1 variable to dimension 1 gameobject
        }
        if (GameObject.Find("Dimension 2") != null)//check is dimension 2 exists
        {
            dimension2 = GameObject.Find("Dimension 2");//set dimension2 variable to dimension 2 gameobject
        }
        if (GameObject.Find("Dimension 3") != null)//check is dimension 3 exists
        {
            dimension3 = GameObject.Find("Dimension 3");//set dimension3 variable to dimension 3 gameobject
        }
        if (GameObject.Find("dim1Tracking") != null)//check is dimension 1 exists
        {
            dim1Tracking = GameObject.Find("dim1Tracking");//set dimension1 variable to dimension 1 gameobject
        }
        if (GameObject.Find("dim2Tracking") != null)//check is dimension 1 exists
        {
            dim2Tracking = GameObject.Find("dim2Tracking");//set dimension1 variable to dimension 1 gameobject
        }
        if (GameObject.Find("dim3Tracking") != null)//check is dimension 1 exists
        {
            dim3Tracking = GameObject.Find("dim3Tracking");//set dimension1 variable to dimension 1 gameobject
        }
        if (GameObject.Find("endGameTracker") != null)//check is dimension 1 exists
        {
            endGameTracking = GameObject.Find("endGameTracker");//set dimension1 variable to dimension 1 gameobject
        }
        dimension2.SetActive(false);
        dimension3.SetActive(false);
        currentDim = 1;
        if (SceneManager.GetActiveScene().name == "Level1D1")
        {
            unlockedDims[0] = true;
            unlockedDims[1] = false;
            unlockedDims[2] = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level2D2")
        {
            unlockedDims[0] = true;
            unlockedDims[1] = false;
            unlockedDims[2] = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level3D3")
        {
            unlockedDims[0] = true;
            unlockedDims[1] = true;
            unlockedDims[2] = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level1D3" || SceneManager.GetActiveScene().name == "Level2D3")
        {
            unlockedDims[0] = true;
            unlockedDims[1] = true;
            unlockedDims[2] = true;
        }
        //intitailise dimensions available
        for (int i = 0; i < 3; i++)
        {
            withinTrigger[i] = false;
        }


        //StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        movementM = player.GetComponent<MovementM>();
        track1 = dim1Tracking.GetComponent<TrackDimension>();
        track2 = dim2Tracking.GetComponent<TrackDimension>();
        track3 = dim3Tracking.GetComponent<TrackDimension>();
        endGame = endGameTracking.GetComponent<TrackDimension>();
        ChangeDimension();

        /*if (cooldownActive)
        {
            StartCoroutine(Cooldown());
        }*/
    }

    IEnumerator Cooldown()
    {
        //print(Time.time);
        yield return new WaitForSeconds(cooldownTime);
        cooldownActive = false;
        //print(Time.time);
    }

    void ChangeDimension()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("pressed q");
            //set change to dimension 3 from 1
            if (dimension1.activeInHierarchy == true && cooldownActive == false && unlockedDims[2] && track3.within == true && endGame.within == false)//add condition for when the player is colliding with the dimension trigger
            {
                dimension1.SetActive(false);//deactivate dimension 1 in heirarchy
                dimension3.SetActive(true);//activate dimension 3 in heirarchy
                currentDim = 3;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = false;
            }
            //set change to dimension 1 from 2
            else if (dimension2.activeInHierarchy == true && cooldownActive == false && unlockedDims[0] && track1.within == true)
            {
                dimension2.SetActive(false);//deactivate dimension 2 in heirarchy
                dimension1.SetActive(true);//activate dimension 1 in heirarchy
                currentDim = 1;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = false;
            }
            //set change to dimension 2 from 3
            else if (dimension3.activeInHierarchy == true && cooldownActive == false && unlockedDims[1] && track2.within == true)
            {
                dimension3.SetActive(false);//deactivate dimension 3 in heirarchy
                dimension2.SetActive(true);//activate dimension 2 in heirarchy
                currentDim = 2;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = true;
            }
        }
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("pressed e");
            //set change to dimension 2 from 1
            if (dimension1.activeInHierarchy == true && cooldownActive == false && unlockedDims[1] && track2.within == true)//add in another variable to see whether the player has unlocked the ability to change to that dimension yet.
            {
                dimension1.SetActive(false);//deactivate dimension 1 in heirarchy
                dimension2.SetActive(true);//activate dimension 2 in heirarchy
                currentDim = 2;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = true;
            }
            //set change to dimension 3 from 2
            else if (dimension2.activeInHierarchy == true && cooldownActive == false && unlockedDims[2] && track3.within == true && endGame.within == false)
            {
                dimension2.SetActive(false);//deactivate dimension 2 in heirarchy
                dimension3.SetActive(true);//activate dimension 3 in heirarchy
                currentDim = 3;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = false;
            }
            //set change to dimension 1 from 3
            else if (dimension3.activeInHierarchy == true && cooldownActive == false && unlockedDims[0] && track1.within == true)
            {
                dimension3.SetActive(false);//deactivate dimension 3 in heirarchy
                dimension1.SetActive(true);//activate dimension 1 in heirarchy
                currentDim = 1;
                cooldownActive = true;
                StartCoroutine(Cooldown());
                movementM.isUnderWater = false;
            }
        }
    }
}
