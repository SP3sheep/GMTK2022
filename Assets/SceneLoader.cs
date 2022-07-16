using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int lastCompletedScene;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            lastCompletedScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(lastCompletedScene);

            SceneManager.LoadScene("Next Level Scene");
        }
    }
}
