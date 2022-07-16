using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
