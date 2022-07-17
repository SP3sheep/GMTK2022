using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void RetstartLevel()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneLoader>().lastCompletedScene);
    }
    public void LoadMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene("Main Scene");
    }

}
