using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public DialogueUI DialogueUI => dialogueUI;
    public Interactable Interactable { get; set; }
    private float move, moveSpeed, rotation, rotationSpeed;
    public float sprintSpeed;
    private bool boosting;
    private float boostTimer;
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        moveSpeed = 20f;
        rotationSpeed = 100f;
        boosting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.IsOpen) return;

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(playerController: this);
            }
        }
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && PlayerSprintHandler.instance.currentStamina > 10)
        {
            boosting = true;
            moveSpeed = moveSpeed + sprintSpeed;
            PlayerSprintHandler.instance.UseStamina(40);

        }
     
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1)
            {
                moveSpeed = 20;
                boostTimer = 0;
                boosting = false;
            }
        }

    
        if (Input.GetAxisRaw("Vertical") != 0)
        {

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }




    IEnumerator StopRB()
    {
        yield return new WaitForSeconds(2f);
        // rb.isKinematic = true;
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.position = new Vector2(transform.position.x, transform.position.y);
        // rb.isKinematic = false;
        yield break;
    }

    public void PushBack(Vector2 enemyPos)
    {
        var playerPos = new Vector2(transform.position.x, transform.position.y);
        float pushPwr = 10f;
        Vector2 pushDir = playerPos - enemyPos;
        rb.AddForce(pushDir * pushPwr, ForceMode2D.Impulse);
        rb.AddForce(pushDir * pushPwr);
        StartCoroutine(StopRB());
    }

}