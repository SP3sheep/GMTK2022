using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void RetstartLevel()
    {
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneLoader>().lastCompletedScene);
    }
}
