using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;

    float playerCurrentHealth;
    float playerMaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = player.GetComponent<PlayerHealth>().currentHealth;
        playerMaxHealth = player.GetComponent<PlayerHealth>().maxHealth;

        GetComponent<Slider>().maxValue = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentHealth = player.GetComponent<PlayerHealth>().currentHealth;
        GetComponent<Slider>().value = playerCurrentHealth;
    }
}
