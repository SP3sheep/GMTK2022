using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GameObject player;

    int playerCurrentHealth;
    int playerMaxHealth;

    public float offset;
    public GameObject healthDicePrefab;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerCurrentHealth = player.GetComponent<PlayerHealth>().currentHealth;
        playerMaxHealth = player.GetComponent<PlayerHealth>().maxHealth;

        GetComponent<Slider>().maxValue = playerMaxHealth;

        // UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentHealth = player.GetComponent<PlayerHealth>().currentHealth;
        GetComponent<Slider>().value = playerCurrentHealth;
    }

    String ConvertToBase(int numberToConvert, int baseToConvertTo)
    {
        string newNumber = "";

        while (numberToConvert > 0)
        {
            int remainder = numberToConvert % baseToConvertTo;
            
            numberToConvert /= baseToConvertTo;

            newNumber = remainder.ToString() + newNumber;

        }

        return newNumber;
    }

    public void UpdateHealth()
    {
        Debug.Log(ConvertToBase(playerCurrentHealth, 6));
        foreach (GameObject hp in GameObject.FindGameObjectsWithTag("HealthBarDice"))
        {
            Destroy(hp);
        } 

        if (ConvertToBase(playerCurrentHealth, 6).Length == 1)
        {
            GameObject healthDice = Instantiate(healthDicePrefab, transform);
            healthDice.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            healthDice.GetComponent<Image>().sprite = sprites[int.Parse(ConvertToBase(playerCurrentHealth, 6))];

            return;
        }

        for (int i = 0; i < int.Parse(ConvertToBase(playerCurrentHealth, 6)) / 10 + 1; i++)
        {
            GameObject healthDice = Instantiate(healthDicePrefab, transform);
            healthDice.transform.position = new Vector3(transform.position.x + i * offset, transform.position.y, 0);


            if (i == int.Parse(ConvertToBase(playerCurrentHealth, 6)) / 10 && int.Parse(ConvertToBase(playerCurrentHealth, 6)) % 10 != 0)
            {
                healthDice.GetComponent<Image>().sprite = sprites[int.Parse(ConvertToBase(playerCurrentHealth, 6)) % 10];
            }
        }
    }
}