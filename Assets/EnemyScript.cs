using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public int currentDie;
    public int damage;
    public int maxValue;

    public float speed;
    public Sprite[] sprites;
    public LayerMask enemiesLayer;

    private NavMeshAgent agent;

    GameObject player;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentDie = Random.Range(1, maxValue);
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<SpriteRenderer>().sprite = sprites[currentDie - 1];
        transform.localScale = new Vector3(currentDie / 2f, currentDie / 2f, 0);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        // Move towards player
        rb.AddForce((player.transform.position - transform.position).normalized * speed/currentDie * Time.deltaTime);

        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distToPlayer > 1)
        {
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, 1, enemiesLayer);
            foreach (Collider2D e in nearbyEnemies)
            {
                rb.AddForce((transform.position - e.transform.position).normalized * 2f);
            }
        }
        */
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
            transform.localScale = new Vector3(currentDie / 2f, currentDie / 2f, 0);
        }
    }
}
