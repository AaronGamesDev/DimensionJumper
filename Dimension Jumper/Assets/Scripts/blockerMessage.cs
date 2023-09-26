using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerMessage : MonoBehaviour
{
    public SpeechText SpeechText;
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
            SpeechText.text = "You can't go back this way!";
        }
    }
}

