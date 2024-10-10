//ink, 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] IHateMyselfSO hackyData;
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
        if (!hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

            //playerAnimator.SetFloat("Horizontal", movement.x);
            //playerAnimator.SetFloat("Vertical", movement.z);

            //playerAnimator.SetFloat("Speed", movement.sqrMagnitude);

            // OLD CODE V

            CheckFlipSprite();

            if (movement.x > 0.1 || movement.x < -0.1)    //Walking Sideways axis, 1 Sprite sheet
            {
                playerAnimator.SetBool("WalkingSide", true);
            }
            else
            {
                playerAnimator.SetBool("WalkingSide", false);
            }

            if (movement.z > 0.1)   //Walking Up direction, individual Sprite sheet 
            {
                playerAnimator.SetBool("WalkingUp", true);
            }
            else
            {
                playerAnimator.SetBool("WalkingUp", false);
            }

            if (movement.z < -0.1)  //Walking Down direction, individual Sprite sheet
            {
                playerAnimator.SetBool("WalkingDown", true);
            }
            else
            {
                playerAnimator.SetBool("WalkingDown", false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!hackyData.inventoryOpen && !hackyData.spiritTalking)
        {
            rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
        }
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
