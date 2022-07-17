using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{

    public float score;
    public float timeSinceStart;
    public int hitsOnRoll;

    public float timeSinceLastKill;
    public float multiKillThreshold;
    public int currentStreak;

    public GameObject ScoreTextPrefab;

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

    public void Kill(Vector2 positionOfKill)
    {
        float scoreForKill = 0;

        scoreForKill += 75;

        if (timeSinceLastKill < multiKillThreshold)
        {
            currentStreak++;
            scoreForKill += 50 * currentStreak;

            if (currentStreak % 5 == -1)
            {
                scoreForKill += 200;
            }
        }

        timeSinceLastKill = 0;

        GameObject scoreText = Instantiate(ScoreTextPrefab, positionOfKill, Quaternion.identity, parent: transform);
        string scoreString = scoreForKill.ToString();

        if (currentStreak > 2)
        {
            scoreString += "\n streak: " + currentStreak.ToString();
        }

        scoreText.GetComponent<TextMesh>().text = scoreString;

        score += scoreForKill;
    }

    
}
