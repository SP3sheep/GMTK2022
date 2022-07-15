using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int currentDie;
    public int damage;
    public int maxValue;

    public float speed;
    public Sprite[] sprites;

    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        currentDie = Random.Range(1, maxValue);
        player = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentDie - 1];
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player
        transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        currentDie--;

        if (currentDie == 0) {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentDie - 1];
        }
    }
}
