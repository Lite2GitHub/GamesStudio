using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


//REF: https://www.youtube.com/watch?v=4mzbDk4Wsmk


public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float relativeX;

    void Start()
    {
        targetPoint = 0;    //this is the next element in the array on play
    }

    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void findRelativeXPosOfArray()
    {
        if (transform.position != patrolPoints[targetPoint].position)
        {
            float relativeX = patrolPoints[targetPoint].position.x;
            Debug.Log("Location?");
        }

        if (relativeX > transform.position.x)
        {
            flip();
        }
    }
}
