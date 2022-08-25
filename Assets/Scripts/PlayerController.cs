using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    Vector2 movement;
    public float defaultSpriteAngle = 90f;
    private Vector2 target;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);

        }
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPos = rb.transform.position;
            // target.z = transform.position.z; 

        }

        CheckMovement();



        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    void RotateToMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

    }

    void CheckMovement()
    {
        if (rb.position == lastPos)
        {
            RotateToMouse();
        }
        lastPos = rb.transform.position;
    }
    public void PushBack(Vector2 enemyPos)
    {
        var playerPos = new Vector2(transform.position.x, transform.position.y);
        float pushPwr = 160f;
        Vector2 pushDir = playerPos - enemyPos;
        rb.AddForce(pushDir * pushPwr);
        StartCoroutine(StopRB());
    }
    IEnumerator StopRB()
    {
        yield return new WaitForSeconds(2f);
        rb.isKinematic = true;
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.isKinematic = false;
        yield break;
    }
}