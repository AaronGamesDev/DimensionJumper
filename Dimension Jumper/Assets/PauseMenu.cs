using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseCanvas;
	// Use this for initialization
	void Start () {
        pauseCanvas.SetActive(false);
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OnPlayClick()
    {
        Resume();
        SceneManager.LoadScene("Level1D1");
    }

    public void LoadLevel2()
    {
        Resume();
        SceneManager.LoadScene("Level2D2");
    }

    public void LoadLevel3()
    {
        Resume();
        SceneManager.LoadScene("Level3D3");
    }

    public void LoadLevel4()
    {
        Resume();
        SceneManager.LoadScene("Level2D3");
    }

    public void LoadLevel5()
    {
        Resume();
        SceneManager.LoadScene("Level1D3");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
