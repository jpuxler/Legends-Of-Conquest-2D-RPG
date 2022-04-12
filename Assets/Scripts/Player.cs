
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRigidBody2D;
    [SerializeField] private Animator playerAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        
        playerRigidBody2D.velocity = new Vector2(horizontalMovement, verticalMovement);
        
        playerAnimator.SetFloat("movementX", playerRigidBody2D.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody2D.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }
    }
}
