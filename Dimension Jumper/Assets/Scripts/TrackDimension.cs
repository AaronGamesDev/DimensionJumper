using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDimension : MonoBehaviour {
    public bool within;
    public Pickup pickups;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pickups = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dimCheck")
        {
            within = true;
            Debug.Log("within");
            
        }
        else if (pickups.keys == 3 && this.gameObject.name == "endGameTracker")
        {
            within = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "dimCheck")
        {
            within = true;
            Debug.Log("within");
        }
        else if (pickups.keys == 3 && this.gameObject.name == "endGameTracker")
        {
            within = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "dimCheck")
        {
            within = false;
            Debug.Log("not within");
        }
    }
}
