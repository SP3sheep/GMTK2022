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
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[die - 1];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if(collider.gameObject.GetComponent<EnemyScript>().currentDie == die)
            {
                // Correct dice hit
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
                collider.gameObject.GetComponent<EnemyScript>().TakeDamage();
                GameObject.FindGameObjectWithTag("SceneHandler").GetComponentInChildren<ScoreTracker>().Kill(collider.transform.position);
                Debug.Log("correct hit");
            }
            else
            {
                // Incorrect dice hit
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Player").transform.position - collider.transform.position) * 1f, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play("IncorrectHit");
                Debug.Log("incorrect hit");
            }
        }

        if (collider.gameObject.tag != "Bullet" && collider.gameObject.tag != "Player")
        {
            FindObjectOfType<AudioManager>().Play("DiceHitWall");
            Destroy(gameObject);
        }
    }

}
