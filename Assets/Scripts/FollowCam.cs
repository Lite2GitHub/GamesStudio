using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -7);

    void LateUpdate()
    {
        // Camera offset by adding extra vector3s, cam position = player.
        transform.position = player.transform.position + offset;
    }
}
