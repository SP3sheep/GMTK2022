using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public float positionSpeed;
    public float scaleSpeed;

    public float duration;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, positionSpeed * Time.deltaTime, 0);

        transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, 0);
        // GetComponent<TextMesh>().fontSize += (int) (scaleSpeed * Time.deltaTime);

        GetComponentInChildren<TextMeshPro>().color -= new Color ( 0, 0, 0, 1) * Time.deltaTime;
        GetComponentInChildren<TextMeshPro>().sortingLayerID = SortingLayer.NameToID("Text");

        duration -= Time.deltaTime;

        if (duration < 0)
        {
            Destroy(gameObject);
        }
    }
}
