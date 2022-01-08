using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Transform attackSpawn;

    public Vector3 attackSpawnVector;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator zombie;

    public Text score;
    public int scoreInt;
    public int addedPoints;

    public ParticleSystem HitP;

    public Transform PTransform;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        else
        
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
       
        if (playerInAttackRange && playerInSightRange && !alreadyAttacked) AttackPlayer();
       
        attackSpawnVector = attackSpawn.position;

    }

    private void Patroling()
    {
        zombie.Play("Running");

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        zombie.Play("Running");
        agent.SetDestination(player.position);
        sightRange = 9999;
    }

    private void AttackPlayer()
    {
        zombie.Play("Attack");        
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, attackSpawnVector, Quaternion.identity).GetComponent<Rigidbody>();

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    public void SightRangeDis()
    {
        sightRange = 10000;
    }
    //Blood Particals(Not to good, needs work)
    //public void Hit()
    //{
        //Instantiate(HitP, PTransform.position, PTransform.rotation);
    //}
}