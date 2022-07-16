using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneLoader>();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneLoader.lastCompletedScene + 1);
    }
}
