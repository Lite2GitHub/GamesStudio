using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateOnKeyPress : MonoBehaviour
{
    [SerializeField] Canvas uiCanvas;
    [Header("Objects to spawn")]
    [SerializeField] List<GameObject> spawnObjects = new List<GameObject>(); //first item is tied to 1 and so on

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (spawnObjects[0] != null) 
            {
                var go = Instantiate(spawnObjects[0]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            if (spawnObjects[1] != null)
            {
                var go = Instantiate(spawnObjects[1]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (spawnObjects[2] != null)
            {
                var go = Instantiate(spawnObjects[2]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (spawnObjects[3] != null)
            {
                var go = Instantiate(spawnObjects[3]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (spawnObjects[4] != null)
            {
                var go = Instantiate(spawnObjects[4]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (spawnObjects[5] != null)
            {
                var go = Instantiate(spawnObjects[5]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (spawnObjects[6] != null)
            {
                var go = Instantiate(spawnObjects[6]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (spawnObjects[7] != null)
            {
                var go = Instantiate(spawnObjects[7]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (spawnObjects[8] != null)
            {
                var go = Instantiate(spawnObjects[8]);

                SpawnGO(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (spawnObjects[9] != null)
            {
                var go = Instantiate(spawnObjects[9]);

                SpawnGO(go);
            }
        }
    }

    void SpawnGO(GameObject go)
    {
        go.transform.SetParent(uiCanvas.transform);
        go.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // set pos to centre of screen
        go.transform.localScale = Vector3.one; //spawns in at a weird scale for some reason
    }
}
