using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Button PlayButton, QuitButton;

	// Use this for initialization
	void Start () {
        //PlayButton.onClick.AddListener(OnPlayClick);
        //QuitButton.onClick.AddListener(OnQuitClick);
	}
    
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Level1D1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2D2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3D3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level2D3");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level1D3");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
