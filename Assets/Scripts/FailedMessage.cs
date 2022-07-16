using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FailedMessage : MonoBehaviour
{

    string[] failMessages =
    {
        "Run out of luck?",
        "Unlucky",
        "Better luck next time",
        "That wasn't very Yatzy of you"
    };
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = failMessages[Random.Range(0, failMessages.Length)];
    }
}
