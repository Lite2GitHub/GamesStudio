using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Animator playerAnimator;

    [Header("Movement Variables")]
    [SerializeField] float movementSpeed;


    Rigidbody rb;

    Vector3 movement;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        CheckFlipSprite();

        if (movement.x > 0.1 || movement.z > 0.1 || movement.x < -0.1 || movement.z < -0.1)
        {
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            playerAnimator.SetBool("Walking", false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }

    void CheckFlipSprite()
    {
        if (movement.x < 0)
        {
            if (facingRight)
            {
                playerSprite.flipX = true;
                facingRight = false;
            }
        }
        else if (movement.x > 0)
        {
            if (!facingRight)
            {
                playerSprite.flipX = false;
                facingRight = true;
            }
        }
    }
}
