using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to change the movement speed


    void Start()
    {

    }

    void Update()
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            // Example: You can add a log message or any other action when the player collides with a pick-up object
            Debug.Log("Picked up item!");
        }
    }
}
