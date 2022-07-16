using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    float score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<ScoreTracker>().score
                + Mathf.Max(1000 - 10 * GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<ScoreTracker>().timeSinceStart);

        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + ((int)score).ToString() + " points");
    }
}
