
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    public static Player instance;
    
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private Rigidbody2D playerRigidBody2D;
    [SerializeField] private Animator playerAnimator;

    public String transitionName;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;
    private bool deactivatedMovement;

    [SerializeField] private Tilemap tilemap;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null  && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (deactivatedMovement)
        {
            playerRigidBody2D.velocity = new Vector2(0f, 0f);
        }
        else
        {
            playerRigidBody2D.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }
    
        playerAnimator.SetFloat("movementX", playerRigidBody2D.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody2D.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            if (!deactivatedMovement)
            {
                playerAnimator.SetFloat("lastX", horizontalMovement);
                playerAnimator.SetFloat("lastY", verticalMovement);
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );
        


    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        this.topRightEdge = topEdgeToSet;
        this.bottomLeftEdge = bottomEdgeToSet;
    }

    public void SetDeactivatedMovement(bool deactivatedMovementSet)
    {
        deactivatedMovement = deactivatedMovementSet;
    }
}
