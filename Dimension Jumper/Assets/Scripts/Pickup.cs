using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int pickups;
    public int keys;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (keys == 6)
        {
            Destroy(GameObject.FindGameObjectWithTag("crate"));
            Destroy(GameObject.FindGameObjectWithTag("crate"));
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pickup")
        {
            pickups += 1;
            Destroy(collision.gameObject);
            //if player.pickups == 3
            //player.unlocked1 = true
            //"player can travel to the next level and switch to the second dimension"
        }
        if (collision.tag == "key")
        {
            keys += 1;
            Destroy(collision.gameObject);
        }
    }
}
