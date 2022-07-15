using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    public int die;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && collider.gameObject.GetComponent<EnemyScript>().currentDie == die)
        {
            collider.gameObject.GetComponent<EnemyScript>().TakeDamage();
        }

        if (collider.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
