using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthScript : MonoBehaviour
{
    public int playerHealth = 100;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            var enemyPos = new Vector2(other.transform.position.x, other.transform.position.y);
            gameObject.GetComponent<PlayerController>().PushBack(enemyPos);
        }
    }
    public void GainHealth(int healAmount)
    {
        playerHealth = playerHealth + healAmount;
    }
    void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
}
