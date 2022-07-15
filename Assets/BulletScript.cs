using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    public int die;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        die = GameObject.FindGameObjectWithTag("DiceScroller").GetComponent<DiceScroller>().value + 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[die - 1];
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

        if (collider.gameObject.tag != "Bullet" && collider.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}
