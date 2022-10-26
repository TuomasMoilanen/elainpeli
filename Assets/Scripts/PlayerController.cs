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
   
    

     void Start()
    {
        moveSpeed = 20f;
        rotationSpeed = 100f;
    }



    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.IsOpen) return;

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(playerController:this);
            }
        }
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") *- rotationSpeed * Time.deltaTime;
        

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
}