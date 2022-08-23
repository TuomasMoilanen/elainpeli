using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    Vector2 movement;
    public float defaultSpriteAngle = 90f;
    private Vector3 target;

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
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // target.z = transform.position.z; 
            RotateToMouse();
        }
        
       
         transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }

    void RotateToMouse()
    {
 Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

    }
}