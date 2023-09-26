using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateBlocker : MonoBehaviour
{
    GameObject crate1, crate2, crate3, crate4;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crate1 = GameObject.Find("big-crate");
            crate2 = GameObject.Find("big-crate (2)");
            crate3 = GameObject.Find("big-crate (4)");
            crate4 = GameObject.Find("big-crate (6)");

            crate1.GetComponent<Collider2D>().enabled = true;
            crate2.GetComponent<Collider2D>().enabled = true;
            crate3.GetComponent<Collider2D>().enabled = true;
            crate4.GetComponent<Collider2D>().enabled = true;


        }
    }
}
