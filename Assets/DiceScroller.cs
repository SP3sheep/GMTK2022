using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScroller : MonoBehaviour
{
    public float rollRate = 1;
    public Sprite[] sprites;
    [HideInInspector] public int value;

    float timer;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }
    
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >= rollRate)
        {
            value = Random.Range(0, 6);
            image.sprite = sprites[value];
            timer = 0;
        }
    }
}
