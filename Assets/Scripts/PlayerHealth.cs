using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    float timeSinceLastHit;
    public float timeBetweenHits;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        timeSinceLastHit = timeBetweenHits;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastHit += Time.deltaTime;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Retry Scene");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && timeSinceLastHit > timeBetweenHits)
        {
            GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * -400f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * 200f);
            currentHealth -= collision.gameObject.GetComponent<EnemyScript>().damage;

            FindObjectOfType<AudioManager>().Play("TakeDamage");

            timeSinceLastHit = 0;
        }
    }
}