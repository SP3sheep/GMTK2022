using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScroller : MonoBehaviour
{
    public float rollRate = 1;
    public Sprite[] sprites;
    public int value;

    float timer;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        value = Random.Range(0, 6);
        image.sprite = sprites[value];
        timer = 0;
    }
    
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >= rollRate)
        {
            GetComponentInParent<InventoryHandler>().availableDice = new bool[] { true, true, true, true };

            value = Random.Range(0, 6);
            image.sprite = sprites[value];
            timer = 0;
        }
    }
}
