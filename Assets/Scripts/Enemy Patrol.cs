using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


//REF: https://www.youtube.com/watch?v=4mzbDk4Wsmk


public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoints;
    public float speed;

    void Start()
    {
        targetPoints = 0;
    }

    void Update()
    {
        if (transform.position == patrolPoints[0].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);

    }

    void increaseTargetInt()
    {
        targetPoints++;
    }

}
