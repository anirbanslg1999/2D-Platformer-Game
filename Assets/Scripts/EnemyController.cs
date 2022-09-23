using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    // list of transfrom where to patrol
    [SerializeField] List<Transform> patrolPoints;
    [SerializeField] float patrolSpeed;
    private int currentPatrolIndex;

    [SerializeField] float startWaitTime;
    private float waitTime;

    private Animator enemyAnimator;

    // Outscal Sol
   /* public float speed;
    public int movingRight = 1;
    public GameObject groundDetector;
    public float rayDistance;
    public Animator enemyAnimator;*/

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetBool("isRunning", true);
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, patrolSpeed * Time.deltaTime);
        //Debug.Log("Current index : " + currentPatrolIndex);
        if (transform.position == patrolPoints[currentPatrolIndex].position)
        {
            // changing the rotation acc to the enemy last patrol pointing towards
            transform.rotation = patrolPoints[currentPatrolIndex].rotation;
            enemyAnimator.SetBool("isRunning", false);
            //Debug.Log("Rotation Index :" + currentPatrolIndex);
            if (waitTime <= 0)
            {
                if (currentPatrolIndex < patrolPoints.Count - 1)
                {
                    currentPatrolIndex++;
                }
                else
                {
                    currentPatrolIndex = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
    }
    /*private void patrolEnemy()
    {
        enemyAnimator.SetBool("IsPatrol", true);
        transform.Translate(movingRight * Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if (!hit)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            movingRight = movingRight * -1;
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            uiManager.DecrementHealthCout();
        }
    }
}
