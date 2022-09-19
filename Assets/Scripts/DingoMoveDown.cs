using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DingoMoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float yDestroy = -40.0f;

    private Rigidbody2D enemyRB;
    private Vector3 movementDirection = Vector3.down;
    private float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.AddForce(Vector3.down * speed);
        if (transform.position.y < yDestroy)
        {
            Destroy(gameObject);
        }

        // Rotation towards movement direction
        // if (enemyRB.velocity.sqrMagnitude > 0)
        // {
        //     Quaternion rotationDirection = Quaternion.LookRotation(movementDirection);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
        // }
    }
}
