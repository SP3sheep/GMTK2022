using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public Image slider;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<Slider>().maxValue = player.GetComponent<PlayerMovement>().dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().dashTimer > player.GetComponent<PlayerMovement>().dashCooldown)
        {
            slider.enabled = false;
        }
        else
        {
            GetComponent<Slider>().value = player.GetComponent<PlayerMovement>().dashTimer;
            slider.enabled = true;
        }

    }
}
