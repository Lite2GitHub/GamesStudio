using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpriteRenderer playerSprite;

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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
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
