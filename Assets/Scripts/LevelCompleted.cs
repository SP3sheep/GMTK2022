using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string lastCompleted = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneLoader>().lastCompletedScene.ToString();
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Level " + lastCompleted + " completed");
    }
}
