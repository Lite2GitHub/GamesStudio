using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOnCollision : MonoBehaviour
{
    [SerializeField] string hintText;

    HintController hintController;

    void Start()
    {
        hintController = GameObject.FindGameObjectWithTag("Hint").GetComponent<HintController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintController.GiveHint(hintText);
            Destroy(gameObject);
        }
    }
}
