using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]


    [Header("Movement Variables")]
    [SerializeField] float movementSpeed;


    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
