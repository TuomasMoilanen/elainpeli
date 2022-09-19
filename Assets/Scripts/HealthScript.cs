using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int playerHealth = 100;
    private Rigidbody2D rb;
    public int playerScore = 0;
    public Slider slider;


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
            slider.value = slider.value - 20;
        }
    }
    public void GainHealth(int healAmount)
    {
        if (playerHealth < 100)
        { playerHealth = playerHealth + healAmount; }

        playerScore = playerScore + 1;

        if (slider.value < 100)
        {
            slider.value = slider.value + 20;
        }
    }
    void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        if (playerHealth <= 0)
        {
            this.GetComponent<GameOverScript>().GameOver(playerScore);
        }
    }
}
