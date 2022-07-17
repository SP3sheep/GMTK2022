using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour
{
    SceneLoader sceneLoader;

    public GameObject nextLevelButton;
    public GameObject creditsButton;

    private void Start()
    {
        sceneLoader = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneLoader>();

        if (sceneLoader.lastCompletedScene == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelButton.SetActive(false);
            creditsButton.SetActive(true);
        }
        else
        {
            creditsButton.SetActive(false);
            nextLevelButton.SetActive(true);
        }
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadNextLevel()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene(sceneLoader.lastCompletedScene + 1);
    }

    public void LoadCreditsMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Credits Scene");
    }
}
