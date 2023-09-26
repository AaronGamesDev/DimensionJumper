using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class ButtonsM : MonoBehaviour {

    public Button ChangeButton;
    public MovementM movement;

	// Use this for initialization
	void Start () {
        ChangeButton.onClick.AddListener(OnButtonClick);
	}

    void Awake()
    {
        
    }

    void OnButtonClick()
    {
        if(movement.isUnderWater == true)
        {
            movement.isUnderWater = false;
        }
        else if(movement.isUnderWater == false)
        {
            movement.isUnderWater = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
