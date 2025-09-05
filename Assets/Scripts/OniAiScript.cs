using UnityEngine;
using UnityEngine.AI;


public class OniAiScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol State
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerChar").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    //patrol player state - searches for walkPoint, moves towards it until point it rached
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    //search for availabe walking points
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); //sets walking point

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) //prevents walking into the abyess 
        {
            walkPointSet = true;
        }
    }

    //chase player stater - sets destination to player
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    //attack player state
    private void AttackPlayer() //attack player
    {
        //Make sure enemy doesn't move while attacking
        agent.SetDestination(transform.position);

        transform.LookAt(player); //gets enemy to look at player when attacking

        if (!alreadyAttacked) //prevents attack spam - if alreadyattacked = false - attack and set already attack to true
        {
            /*
             Add attack code here
            */
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    //resets attack via setting alreadyAttacked to false when called
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
