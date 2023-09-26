using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeechText : MonoBehaviour {
    public Text speech;//, interact;
    public string text;
    public float delay = 0.01f;
    public bool skip;
    public bool isRunning = false;
    public bool textShowing = false;
    public GameObject textBackground;//, interactImage;
    public bool withinArea = false;
    public bool interacted = false;
    public bool lvOneComplete = false;
    Pickup pickup;
    DimensionHop dimensions;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.Find("Image") != null)
        {
            textBackground = GameObject.Find("Image");
            speech = textBackground.GetComponentInChildren<Text>();
            textBackground.SetActive(false);
        }
        /*
        if (GameObject.Find("InteractImage") != null)
        {
            interactImage = GameObject.Find("InteractImage");
            interact = GameObject.Find("InteractImage").GetComponentInChildren<Text>();
            interactImage.SetActive(false);
        }*/
        //if (this.gameObject.tag == )

        //speech = GameObject.Find("Text").GetComponent<Text>();
        //text = "this is a test version of a conversation abracadabra to do loo poo poo choo choo";
        text = "Hello again.";
    }
	
	// Update is called once per frame
	void Update () {
        pickup = player.GetComponent<Pickup>();
        dimensions = player.GetComponent<DimensionHop>();
        if (this.gameObject.tag == "npc2" && dimensions.unlockedDims[1] == false)//CHANGE THIS TO unlockedDims[1]
        {
            if (pickup.pickups == 0)
            {
                text = "To unlock the ability to hop to another dimension, you first need to find 3 stars. When you find them return to me.";
            }
            else if (pickup.pickups == 1)
            {
                text = "Great! You found one! Now you only need to find two more stars.";
            }
            else if (pickup.pickups == 2)
            {
                text = "Almost there! You only need to find one more star.";
            }
            else if (pickup.pickups >= 3)
            {
                text = "Great! You have now unlocked the ability to change to the underwater dimension in exchange for your stars. Be careful other dimensions may sound cool but they are full of dangerous enemies so watch out!";
                if (isRunning)
                {
                    dimensions.unlockedDims[1] = true;
                    pickup.pickups -= 3;
                }
            }
        }
        if (this.gameObject.tag == "npc3" && dimensions.unlockedDims[1] == true && dimensions.unlockedDims[2] == false)
        {
            if(pickup.pickups == 0 && pickup.keys == 0)
            {
                text = "Bring me three stars and two keys to unlock the fire dimension and your path back will be unblocked";
            }
            else if (pickup.pickups == 1 && pickup.keys == 0)
            {
                text = "Please return with two more stars and two more keys";
            }
            else if (pickup.pickups == 2 && pickup.keys == 0)
            {
                text = "Please return with one more star and two more keys";
            }
            else if (pickup.pickups == 3 && pickup.keys == 0)
            {
                text = "Please return with two more keys";
            }
            else if (pickup.pickups == 0 && pickup.keys == 1)
            {
                text = "Please return with three more stars and one more key";
            }
            else if (pickup.pickups == 1 && pickup.keys == 1)
            {
                text = "Please return with two more stars and one more key";
            }
            else if (pickup.pickups == 2 && pickup.keys == 1)
            {
                text = "Please return with one more star and one more key";
            }
            else if (pickup.pickups == 3 && pickup.keys == 1)
            {
                text = "Please return with one more key";
            }
            else if (pickup.pickups == 0 && pickup.keys == 2)
            {
                text = "Please return with three more stars";
            }
            else if (pickup.pickups == 1 && pickup.keys == 2)
            {
                text = "Please return with two more stars";
            }
            else if (pickup.pickups == 2 && pickup.keys == 2)
            {
                text = "Please return with one more star";
            }
            else if (pickup.pickups >= 3 && pickup.keys == 2)
            {
                text = "Ahh, I see you have brought me three stars and two keys. I will now grant you the ability to travel to the hell dimension and unblock your path";
                if (isRunning)
                {
                    dimensions.unlockedDims[2] = true;
                    pickup.pickups -= 5;
                    GameObject[] crates = GameObject.FindGameObjectsWithTag("crate");
                    for (int i = 0; i < 2; i++)
                    {
                        crates[i].SetActive(false);
                    }
                }


            }
        }

        if (this.gameObject.tag == "sign2")// && dimensions.unlockedDims[1] == false)
        {

            text = "Beware! Jumping down here without the ability to switch to the underwater dimension will result in death";
        }




        if (withinArea == true)
        {
            //interactImage.SetActive(true);
            if (Input.GetKeyDown("f") && isRunning == false)//allows player to enter the conversation
            {
                textBackground.SetActive(true);
                //interactImage.SetActive(false);
                StartCoroutine(showText());
                if (this.gameObject.tag == "npc5")
                {
                    interacted = true;
                }
                else
                {
                    interacted = false;
                }
            }
        }
        else
        {
           //interactImage.SetActive(false);
        }

        if (isRunning == true)//allow the player to skip the text appearing letter by letter
        {
            //interactImage.SetActive(false);
            if (Input.GetKeyDown("return"))
            {
                skip = true;
            }
        }
        if (textShowing == true && isRunning == false)//allow the player to exit the conversation
        {
            if (Input.GetKeyDown("return"))
            {
                textBackground.SetActive(false);
                textShowing = false;
            }
        }

        if (this.gameObject.tag == "npc1")
        {
            if (pickup.pickups == 0 && !lvOneComplete)
            {
                text = "The connecting cave here seems to be blocked by these crates, please find and collect a star and come back to me in order to move them out of your way";
            }
            else if (pickup.pickups == 0 && lvOneComplete)
            {
                text = "The crates have gone!";
            }
            if (pickup.pickups == 1 && !lvOneComplete)
            {
                GameObject[] crates = GameObject.FindGameObjectsWithTag("crate");
                for(int i = 0; i < 2; i++)
                {
                    crates[i].SetActive(false);
                }
                lvOneComplete = true;
                pickup.pickups -= 1;
            }
        }

        if (this.gameObject.tag == "npc5")
        {

            text = "Martha! You found me!" +
                "\nI switched Dimensions whilst on a walk and fell down this hole which broke my Dimension Jumper!" +
                "\nNow we can go through this door using your Dimension Jumper, Thank you for saving me!";
            if (interacted == true)
            {
                StartCoroutine(Credits());
            }

        }

    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(12.0f);
        SceneManager.LoadScene("Credits");
    }




    IEnumerator showText()
    {
        isRunning = true;
        textShowing = true;
        for(int i = 0; i < text.Length + 1; i++)
        {
            if (skip != true)
            {
                speech.text = text.Substring(0, i);
                yield return new WaitForSeconds(delay);
            }
            else
            {
                speech.text = text;
                isRunning = false;
                yield return new WaitForSeconds(0);
            }
        }
        isRunning = false;
        skip = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            withinArea = true;
            //interactImage.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            withinArea = false;
            //interactImage.SetActive(true);
        }
    }
}
