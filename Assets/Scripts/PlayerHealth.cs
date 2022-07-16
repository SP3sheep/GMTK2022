using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("You Lose");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && timeSinceLastHit > timeBetweenHits)
        {
            Debug.Log("You Hit");
            currentHealth -= collision.gameObject.GetComponent<EnemyScript>().damage;
            timeSinceLastHit = 0;
        }
    }
}