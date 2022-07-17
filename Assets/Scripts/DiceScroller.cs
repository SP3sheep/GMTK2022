using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScroller : MonoBehaviour
{
    public float rollRate = 1;
    public Sprite[] sprites;
    public int value;

    public float soundQueue;

    float timer;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        value = Random.Range(0, 6);
        image.sprite = sprites[value];
        timer = 0;

        soundQueue = 2f;
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0, Mathf.Clamp((timer - (rollRate * 0.95f))*900, 0, 360)));

        if (timer >= rollRate - soundQueue)
        {
            if (!FindObjectOfType<AudioManager>().FindSource("ExtendedDiceRoll").source.isPlaying)
            {
                FindObjectOfType<AudioManager>().Play("ExtendedDiceRoll");
            }
        }

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
