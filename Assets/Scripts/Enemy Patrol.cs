using System.Collections;
using UnityEngine;


//REF: https://www.youtube.com/watch?v=4mzbDk4Wsmk


public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint; //Indicates the array element npc is travelling to
    public float speed = 0.4f;
    private float originalSpeed;
    private float relativeX;

    private float proximityToTarget = .2f;

    public bool isTargetLeft; 
    public bool isFacingLeft; //default sprite is facing left

    public Animator animator;
    // bool isRight; for determining rolling direction
    // bool isNearEnd; trigger unrolling anims
    // bool isMoving; for pauses


    void Start()
    {
        targetPoint = 0;
        originalSpeed = speed;
        animator.SetBool("isMoving", true);
    }

    void Update()
    {
        if (patrolPoints.Length > 0) 
        {
            findRelativeXPosOfArray();
            //facingDirection();
            //flip();

            if (transform.position == patrolPoints[targetPoint].position)   //arrival on Target
            {
                increaseTargetInt();

                // insert pause here, by setting bool "isMoving" to false for 2 seconds then setting it back to true.
                StartCoroutine(PauseMovement());
            }

            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        }
        

        if (isTargetLeft)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", true);
        }   
        
        if (!isTargetLeft)
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
        }

        float distance = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

        if (distance < proximityToTarget) 
        {
            animator.SetBool("isNearEnd", true);
        }
        else
        {
            animator.SetBool("isNearEnd", false);
        }
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    IEnumerator PauseMovement()
    {
        speed = 0f;
        animator.SetBool("isMoving", false);

        yield return new WaitForSeconds(1f);

        speed = originalSpeed;
        animator.SetBool("isMoving", true);
    }

    //void facingDirection()  //default sprite is facing left
    //{
    //    if (transform.localScale.x < 0)
    //    {
    //        isFacingLeft = false;
    //    }

    //    if (transform.localScale.x > 0)
    //    {
    //        isFacingLeft = true;
    //    }
    //}

    void findRelativeXPosOfArray()  //Find xPos of the next array point
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

    //void flip() //Flip logic = When do I flip?; could be made cleaner i think
    //{
    //    if (!isFacingLeft && isTargetLeft)
    //    {
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1;
    //        transform.localScale = localScale;
    //    } 

    //    if (isFacingLeft && !isTargetLeft)
    //    {
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1;
    //        transform.localScale = localScale;
    //    }
    //}
}
