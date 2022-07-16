using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        mainVolumeSlider.value = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().mainVolume;
        musicVolumeSlider.value = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().musicVolume;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void UpdateMainVolume()
    {
        GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().mainVolume = mainVolumeSlider.value;
    }

    public void UpdateMusicVolume()
    {
        GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().musicVolume = musicVolumeSlider.value;
    }
}
