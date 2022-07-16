using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{

    public float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            score -= Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += resetScore;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= resetScore;
    }

    void resetScore(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            score = 1000;
        }
    }
}
