using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSliderHandle : MonoBehaviour
{
    public Sprite[] sprites;
    
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }
    void Update()
    {
        img.sprite = sprites[Mathf.RoundToInt(transform.parent.parent.GetComponent<Slider>().value * (sprites.Length - 1))];
    }
}
