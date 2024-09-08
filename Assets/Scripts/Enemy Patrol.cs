using UnityEngine;


//REF: https://www.youtube.com/watch?v=4mzbDk4Wsmk


public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint; //Indicates the array element npc is travelling to
    public float speed;
    public float relativeX;

    public bool isTargetLeft; //default
    public bool isFacingLeft; //default

    void Start()
    {
        targetPoint = 0;
    }

    void Update()
    {
        findRelativeXPosOfArray();
        facingDirection();
        flip();

        if (transform.position == patrolPoints[targetPoint].position)   //arrival on Target
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

    void facingDirection()
    {
        if (transform.localScale.x < 0)
        {
            isFacingLeft = false;
        }

        if (transform.localScale.x > 0)
        {
            isFacingLeft = true;
        }
    }

    void findRelativeXPosOfArray()
    {
        if (transform.position.x != patrolPoints[targetPoint].position.x)
        {
            relativeX = patrolPoints[targetPoint].position.x;
        }

        if (relativeX > transform.position.x)   //Target is to the right
        {
            isTargetLeft = false;
        }

        if (relativeX < transform.position.x)   //Target is to the Left
        {
            isTargetLeft = true;
        }

    }

    void flip()
    {
        if (!isFacingLeft && isTargetLeft)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        } 

        if (isFacingLeft && !isTargetLeft)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
