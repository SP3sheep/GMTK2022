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
        score = GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<ScoreTracker>().score;

        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + score.ToString() + " points");
    }
}
