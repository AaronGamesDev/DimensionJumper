using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenuScript : MonoBehaviour {

    //private static audioScript instance = null;
    //public static audioScript Instance
    public AudioMixer audioMixer;
    public Slider volume;
    public Dropdown resDropdown;
    //public AudioSource ambient, jumpSound, switchSound;
    Resolution[] resolutions;
    /*
    {
        get { return instance;  }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }*/

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int resIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string res = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(res);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = resIndex;
        resDropdown.RefreshShownValue();
    }

    void Update()
    {
        audioMixer.SetFloat("volume", volume.value);
        //ambient.volume = volume.value;
        //jumpSound.volume = volume.value;
        //switchSound.volume = volume.value;
    }

    public void changeQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullscreen(bool isFullscreen)
    {
        //Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
