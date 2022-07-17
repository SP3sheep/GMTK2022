using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        mainVolumeSlider.value = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().mainVolume;
        musicVolumeSlider.value = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().musicVolume;

        FindObjectOfType<AudioManager>().SetVolume(mainVolumeSlider.value);
        FindObjectOfType<AudioManager>().SetVolume(mainVolumeSlider.value * musicVolumeSlider.value, "Music");
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Main Scene");
    }

    public void UpdateMainVolume()
    {
        GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().mainVolume = mainVolumeSlider.value;
        FindObjectOfType<AudioManager>().SetVolume(mainVolumeSlider.value);
        FindObjectOfType<AudioManager>().SetVolume(mainVolumeSlider.value * musicVolumeSlider.value, "Music");
    }

    public void UpdateMusicVolume()
    {
        GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<Options>().musicVolume = musicVolumeSlider.value;
        FindObjectOfType<AudioManager>().SetVolume(mainVolumeSlider.value * musicVolumeSlider.value, "Music");
    }
}
