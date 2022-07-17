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
    public LayerMask wallsLayer;

    private NavMeshAgent agent;
    Vector3 target;
    Vector3 targetLastSeen;

    GameObject player;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentDie = Random.Range(1, maxValue + 1);
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<SpriteRenderer>().sprite = sprites[currentDie - 1];
        transform.localScale = new Vector3(0.5f + currentDie / 3f, 0.5f + currentDie / 3f, 0);
        damage = currentDie;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        targetLastSeen = transform.position;
    }

    private void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, player.transform.position - transform.position,
                                                    Vector2.Distance(player.transform.position, transform.position), wallsLayer);
        
        //Debug.DrawRay(transform.position, (player.transform.position - transform.position));

        if (hits.Length == 0)
        {
            target = player.transform.position;
            targetLastSeen = target;
            Debug.DrawLine(transform.position, targetLastSeen);
        }
        else
        {
            Debug.DrawLine(transform.position, targetLastSeen);
        }

        agent.SetDestination(targetLastSeen);

        if (agent.remainingDistance < 0.1f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        // Move towards player
        rb.AddForce((player.transform.position - transform.position).normalized * speed/currentDie * Time.deltaTime);

        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distToPlayer > 2)
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
            transform.localScale = new Vector3(0.5f + currentDie / 3f, 0.5f + currentDie / 3f, 0);
            damage = currentDie;

            FindObjectOfType<AudioManager>().Play("DiceEnemyHit");
        }
    }
}
