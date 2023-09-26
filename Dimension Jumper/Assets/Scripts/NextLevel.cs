using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Level1D1")
            {
                SceneManager.LoadScene("Level2D2");
            }
            if (SceneManager.GetActiveScene().name == "Level2D2")
            {
                SceneManager.LoadScene("Level3D3");
            }
            if (SceneManager.GetActiveScene().name == "Level3D3")
            {
                SceneManager.LoadScene("Level2D3");
            }
            if (SceneManager.GetActiveScene().name == "Level2D3")
            {
                SceneManager.LoadScene("Level1D3");
            }

        }
    }
}
