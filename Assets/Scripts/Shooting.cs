using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public float rechargeTime;

    float cooldown;

    InventoryHandler inventory;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = rechargeTime;
        inventory = GameObject.FindGameObjectWithTag("InventoryHandler").GetComponent<InventoryHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldown > rechargeTime && inventory.availableDice[inventory.currentlySelectedInt])
        {

            Instantiate(bullet, transform.position, transform.rotation);
            bullet.GetComponent<BulletScript>().die = inventory.currentlySelected.value + 1;
            inventory.availableDice[inventory.currentlySelectedInt] = false;

            cooldown = 0;

            FindObjectOfType<AudioManager>().Play("DiceRoll");


        }
    }
}
