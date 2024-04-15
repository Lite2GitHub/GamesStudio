using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to change the movement speed
    public bool isInteracting = false;

    void Update()
    {
        if (!isInteracting)
        {
            // movement
            PlayerMovementHandler();
        } 
        else
        {
            // stop player movement
        }
    }

    void PlayerMovementHandler()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;
        movement.Normalize();

        if (movement.magnitude > 0.5f)
        {
            movement *= 0.7071f; // 1/sqrt(2), approximately 0.7071, to maintain consistent diagonal speed
        }

        // Apply speed and time factor
        movement *= moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    public void SetInteracting(bool interacting)
    {
        isInteracting = interacting;

        /*
        if (isInteracting)
        {

        }
        else
        {

        }
        */
    }

}
