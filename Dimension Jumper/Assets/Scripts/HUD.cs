using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public GameObject player, dim1, dim2, dim3, leftPos, centerPos, rightPos, heart1, heart2, heart3, heart4, heart5, star1, star2, star3, star4, star5, key1, key2, key3;
    DimensionHop dimension;
    Pickup pickup;
    Health health;
    Vector3 bigScale, smallScale;
    // Use this for initialization
    void Start () {
        bigScale = new Vector3(40f, 40f, 40f);
        smallScale = new Vector3(30f, 30f, 30f);

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (GameObject.Find("Dim1"))
        {
            dim1 = GameObject.Find("Dim1");
        }
        if (GameObject.Find("Dim1"))
        {
            dim2 = GameObject.Find("Dim2");
        }
        if (GameObject.Find("Dim3"))
        {
            dim3 = GameObject.Find("Dim3");
        }

        if (GameObject.Find("Left Pos"))
        {
            leftPos = GameObject.Find("Left Pos");
        }
        if (GameObject.Find("Center Pos"))
        {
            centerPos = GameObject.Find("Center Pos");
        }
        if (GameObject.Find("Right Pos"))
        {
            rightPos = GameObject.Find("Right Pos");
        }

        if (GameObject.Find("star1"))
        {
            star1 = GameObject.Find("star1");
        }
        if (GameObject.Find("star2"))
        {
            star2 = GameObject.Find("star2");
        }
        if (GameObject.Find("star3"))
        {
            star3 = GameObject.Find("star3");
        }
        if (GameObject.Find("star4"))
        {
            star4 = GameObject.Find("star4");
        }
        if (GameObject.Find("star5"))
        {
            star5 = GameObject.Find("star5");
        }
        if (GameObject.Find("key1"))
        {
            key1 = GameObject.Find("key1");
        }
        if (GameObject.Find("key2"))
        {
            key2 = GameObject.Find("key2");
        }
        if (GameObject.Find("key3"))
        {
            key3 = GameObject.Find("key3");
        }

        if (GameObject.Find("heart1"))
        {
            heart1 = GameObject.Find("heart1");
        }
        if (GameObject.Find("heart2"))
        {
            heart2 = GameObject.Find("heart2");
        }
        if (GameObject.Find("heart3"))
        {
            heart3 = GameObject.Find("heart3");
        }
        if (GameObject.Find("heart4"))
        {
            heart4 = GameObject.Find("heart4");
        }
        if (GameObject.Find("heart5"))
        {
            heart5 = GameObject.Find("heart5");
        }

    }
	
	// Update is called once per frame
	void Update () {
        health = player.GetComponent<Health>();
        pickup = player.GetComponent<Pickup>();
        dimension = player.GetComponent<DimensionHop>();
        if (dimension.currentDim == 1)
        {
            dim1.transform.position = Vector3.Lerp(dim1.transform.position, centerPos.transform.position, 0.1f);
            dim2.transform.position = Vector3.Lerp(dim2.transform.position, rightPos.transform.position, 0.1f);
            dim3.transform.position = Vector3.Lerp(dim3.transform.position, leftPos.transform.position, 0.1f);
            dim1.transform.localScale = Vector3.Lerp(dim1.transform.localScale, bigScale, 0.1f);
        }
        else
        {
            dim1.transform.localScale = Vector3.Lerp(dim1.transform.localScale, smallScale, 0.1f);
        }
        if (dimension.currentDim == 2)
        {
            dim1.transform.position = Vector3.Lerp(dim1.transform.position, leftPos.transform.position, 0.1f);
            dim2.transform.position = Vector3.Lerp(dim2.transform.position, centerPos.transform.position, 0.1f);
            dim3.transform.position = Vector3.Lerp(dim3.transform.position, rightPos.transform.position, 0.1f);
            dim2.transform.localScale = Vector3.Lerp(dim2.transform.localScale, bigScale, 0.1f);
        }
        else
        {
            dim2.transform.localScale = Vector3.Lerp(dim2.transform.localScale, smallScale, 0.1f);
        }
        if (dimension.currentDim == 3)
        {
            dim1.transform.position = Vector3.Lerp(dim1.transform.position, rightPos.transform.position, 0.1f);
            dim2.transform.position = Vector3.Lerp(dim2.transform.position, leftPos.transform.position, 0.1f);
            dim3.transform.position = Vector3.Lerp(dim3.transform.position, centerPos.transform.position, 0.1f);
            dim3.transform.localScale = Vector3.Lerp(dim3.transform.localScale, bigScale, 0.1f);
        }
        else
        {
            dim3.transform.localScale = Vector3.Lerp(dim3.transform.localScale, smallScale, 0.1f);
        }


        if (pickup.pickups == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
        }
        else if (pickup.pickups == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
        }
        else if (pickup.pickups == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
        }
        else if (pickup.pickups == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(false);
            star5.SetActive(false);
        }
        else if (pickup.pickups == 4)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(true);
            star5.SetActive(false);
        }
        else if (pickup.pickups == 5)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(true);
            star5.SetActive(true);
        }

        if (pickup.keys == 0)
        {
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        else if (pickup.keys == 1)
        {
            key1.SetActive(true);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        else if (pickup.keys == 2)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(false);
        }
        else if (pickup.keys == 3)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
        }

        if (health.hearts == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (health.hearts == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (health.hearts == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (health.hearts == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (health.hearts == 4)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if (health.hearts == 5)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }

    }
}
