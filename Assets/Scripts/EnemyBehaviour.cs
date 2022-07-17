using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;

    public GameObject enemyDie;

    int value;
    EnemyScript enemyScript;
    Transform player;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    float timer;
    int numberSpawned;
    
    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        value = enemyScript.currentDie;
        timer += Time.deltaTime;
        switch (value)
        {
            case 1:
                sprite.color = color1;
                enemyScript.speed = 250f;
                break;
            case 2:
                sprite.color = color2;
                if (timer >= 1.5f)
                {
                    rb.AddForce((transform.position - (player.position - Random.insideUnitSphere * 2)).normalized * -2f, ForceMode2D.Impulse);
                    timer = 0;
                }
                break;
            case 3:
                sprite.color = color3;
                break;
            case 4:
                sprite.color = color4;
                if (timer >= 0.5f)
                {
                    rb.AddForce(Random.insideUnitCircle * 4, ForceMode2D.Impulse);
                    timer = 0;
                }
                break;
            case 5:
                sprite.color = color5;
                break;
            default:
                sprite.color = color6;
                if(timer >= 10 && numberSpawned <= 3 && Vector2.Distance(transform.position, player.position) < 5)
                {
                    GameObject e = Instantiate(enemyDie, transform.position, transform.rotation);
                    e.GetComponent<EnemyScript>().randomStartValue = false;
                    e.GetComponent<EnemyScript>().currentDie = 1;
                    numberSpawned++;
                    timer = 0;
                }
                break;
        }

    }
}
