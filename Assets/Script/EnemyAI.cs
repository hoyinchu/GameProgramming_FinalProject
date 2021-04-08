using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum FSMStates
    {
        Idle,
        Patrol,
        Attack,
        Chase,
        Die
    }

    public FSMStates currentState;
    public float enemySpeed = 5;
    public float chaseDist = 20;
    public float attackDist = 10;
    public GameObject player;
    //public GameObject[] spellProjectiles;
    //public GameObject wandTip;
    //public float shootRate = 2;
    //public GameObject deadVFX;
    public Transform enemyEyes;
    public float fieldOfView = 150f;

    GameObject[] wanderPoints;
    //Animator anim;
    Vector3 nextDest;
    //EnemyHealth enemyHealth;
    int health;
    int currentDest = 0;
    float distToPlayer;
    float elapsedTime = 0;
    private LevelManager levelM;

    //Transform deadTransform;
    //bool isDead;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        this.levelM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        wanderPoints = GameObject.FindGameObjectsWithTag("WanderPoint");
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //health = enemyHealth.currentHealth;

        switch (currentState)
        {
            case FSMStates.Patrol:
                UpdatePatrolState();
                break;
            case FSMStates.Chase:
                UpdateChaseState();
                break;
           
        }
        elapsedTime += Time.deltaTime;
    }

    void Initialize()
    {

        currentState = FSMStates.Patrol;
        FindNextPoint();


    }


    void UpdatePatrolState()
    {
        Debug.Log("Patrolling");
        //anim.SetInteger("animState", 1);
        agent.stoppingDistance = 0;
        agent.speed = 3.5f;

        if (Vector3.Distance(transform.position, nextDest) < 1.5f)
        {
            FindNextPoint();
        }
        else if (distToPlayer <= chaseDist && IsPlayerInClearFOV())
        {
            currentState = FSMStates.Chase;
        }
        FaceTarget(nextDest);
        agent.SetDestination(nextDest);
        //transform.position = Vector3.MoveTowards(transform.position, nextDest, enemySpeed * Time.deltaTime);

    }

    void UpdateChaseState()
    {
        Debug.Log("Chasing");
        //anim.SetInteger("animState", 2);
        nextDest = player.transform.position;
        agent.stoppingDistance = attackDist;
        agent.speed = 5;

        if (distToPlayer <= attackDist)
        {
            levelM.LevelLost();
        }
        else if (distToPlayer > chaseDist)
        {
            FindNextPoint();
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDest);
        agent.SetDestination(nextDest);

        //transform.position = Vector3.MoveTowards(transform.position, nextDest, enemySpeed * Time.deltaTime);
    }


    void FindNextPoint()
    {
        nextDest = wanderPoints[currentDest].transform.position;
        currentDest = (currentDest + 1) % wanderPoints.Length;
        agent.SetDestination(nextDest);

    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDist);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDist);

        Vector3 frontRayPoint = enemyEyes.position + (enemyEyes.forward * chaseDist);
        Vector3 leftRayPoint = Quaternion.Euler(0, fieldOfView * 0.5f, 0) * frontRayPoint;
        Vector3 rightRayPoint = Quaternion.Euler(0, -fieldOfView * 0.5f, 0) * frontRayPoint;

        Debug.DrawLine(enemyEyes.position, frontRayPoint, Color.cyan);
        Debug.DrawLine(enemyEyes.position, leftRayPoint, Color.yellow);
        Debug.DrawLine(enemyEyes.position, rightRayPoint, Color.yellow);


    }
    bool IsPlayerInClearFOV()
    {
        RaycastHit hit;

        Vector3 directionToPlayer = player.transform.position - enemyEyes.position;
        if (Vector3.Angle(directionToPlayer, enemyEyes.forward) <= fieldOfView)
        {
            if (Physics.Raycast(enemyEyes.position, directionToPlayer, out hit, chaseDist))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        return false;
    }
}
