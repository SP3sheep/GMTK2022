using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{

    public float score;
    public float timeSinceStart;
    public int hitsOnRoll;

    public float timeSinceLastKill;
    public float multiKillThreshold;
    public int currentStreak;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceStart = 0;
        timeSinceLastKill = multiKillThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            timeSinceStart += Time.deltaTime;
        }

        timeSinceLastKill += Time.deltaTime;

        if (timeSinceLastKill > multiKillThreshold)
        {
            currentStreak = 0;
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
            timeSinceStart = 0;
            score = 0;
            timeSinceLastKill = 0;
            currentStreak = 0;
        }
    }

    public void Kill()
    {
        score += 75;

        if (timeSinceLastKill < multiKillThreshold)
        {
            score += 50;
            currentStreak++;

            if (currentStreak % 5 == -1)
            {
                score += 200;
            }
        }

        timeSinceLastKill = 0;
    }
}
