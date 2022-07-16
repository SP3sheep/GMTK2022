using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public float rechargeTime;

    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = rechargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldown > rechargeTime)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            bullet.GetComponent<BulletScript>().die = Random.Range(1, 6);

            cooldown = 0;
        }
    }
}
