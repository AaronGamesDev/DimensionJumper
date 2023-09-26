using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteract : MonoBehaviour {
    public GameObject interactImage, messageImage;

    // Use this for initialization
    void Start ()
    {
        interactImage = GameObject.Find("InteractImage");
        interactImage.SetActive(false);

        messageImage = GameObject.Find("MessageImage");
        messageImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "npc1" || collision.tag == "npc2" || collision.tag == "npc3" || collision.tag == "npc4" || collision.tag == "npc5" || collision.tag == "sign1" || collision.tag == "sign2")
        {
            interactImage.SetActive(true);
        }
        else if (collision.tag == "blocker")
        {
            messageImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "npc1" || collision.tag == "npc2" || collision.tag == "npc3" || collision.tag == "npc4" || collision.tag == "npc5" || collision.tag == "sign1" || collision.tag == "sign2")
        {
            interactImage.SetActive(false);
        }
        else if (collision.tag == "blocker")
        {
            messageImage.SetActive(false);
        }
    }
}
