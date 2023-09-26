using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void OnMouseDown()
    {
        if (this.name == "Start")
        {
            SceneManager.LoadScene("level1");
        }
        else if (this.name == "Quit")
        {
            Application.Quit();
        }
    }
}
