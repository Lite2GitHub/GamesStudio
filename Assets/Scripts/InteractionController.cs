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
    public string heldItem;

    Ray ray;
    RaycastHit hit;
    [SerializeField] GameObject hoveredInteractable;

    void Update()
    {
        CheckForHover();

        if (hoveredInteractable && Input.GetMouseButtonDown(0))
        {
            hoveredInteractable.GetComponent<IInteractable>().interact(heldItem);
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
            interactable.LeftRange();
            interactableObjects.Remove(other.gameObject);
        }
    }

    void CheckForHover()
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
                            if (hoveredInteractable != interactable)
                            hoveredInteractable = interactable;
                            print(hit.collider.gameObject);
                            hoveredInteractable.GetComponent<IInteractable>().hover(true);
                            return;
                        }
                    }

                }
            }
            if (hoveredInteractable != null)
            {
                hoveredInteractable.GetComponent<IInteractable>().hover(false);
                hoveredInteractable = null;
            }
        }
        else
        {
            if (hoveredInteractable != null)
            {
                hoveredInteractable.GetComponent<IInteractable>().hover(false);
                hoveredInteractable = null;
            }
        }
    }
}
