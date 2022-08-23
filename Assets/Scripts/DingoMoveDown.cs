using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DingoMoveDown : MonoBehaviour
{  public float speed = 5.0f;
    private float yDestroy = -40.0f;

    private Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.AddForce(Vector3.down * speed);
        if (transform.position.y < yDestroy)
        {
            Destroy(gameObject);
        }
    }
}
