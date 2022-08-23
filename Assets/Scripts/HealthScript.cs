using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            takeDamage(20);
        }
    }
    public void GainHealth(int healAmount)
    {
        playerHealth = playerHealth + healAmount;
    }
    void takeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
}
