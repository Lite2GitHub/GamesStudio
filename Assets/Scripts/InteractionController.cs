using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] LayerMask layerMasks;

    [Header("Ray Cast Variables")]
    [SerializeField] float maxDistance;

    [SerializeField] List<GameObject> interactableObjects = new List<GameObject>();

    Ray ray;
    RaycastHit hit;
    [SerializeField] GameObject hoveredInteractable;

    void Update()
    {
        if (interactableObjects.Count > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance, layerMasks))
            {
                if (hit.collider != null)
                {
                    foreach (GameObject interactable in interactableObjects)
                    {
                        if (interactable == hit.collider.gameObject)
                        {
                            hoveredInteractable = interactable;
                            return;
                        }
                    }
                    hoveredInteractable = null;
                }
                else
                {
                    hoveredInteractable = null;
                }
            }
        }
        else
        {
            hoveredInteractable = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable !=null)
        {
            interactableObjects.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactableObjects.Remove(other.gameObject);
        }
    }
}
