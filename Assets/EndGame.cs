using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] IHateMyselfSO hackyData;
    void OnTriggerEnter(Collider other)
    {
        hackyData.spiritTalking = true;
        sceneController.StartNextScene("LevelTest 1");
    }
}
