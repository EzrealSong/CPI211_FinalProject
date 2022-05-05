using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;
    [SerializeField]
    public float movespeed;
    [SerializeField]
    public float detectionRange;
    [SerializeField]
    public float attackRangeMelee;
    [SerializeField]
    public float attackRangeRanged;
    [SerializeField]
    NavMeshAgent CrabAi;

    public Animator CrabAni;

    public GameObject bullet;
    private float shootCooldown;
    public float startShootCooldown;
    public float health = 1;
    private bool canMove = false;
    private bool canAttackRanged = false;
    private bool canAttackMelee = false;
    private bool inCombat = false;
    public Transform[] waypoints;
    public int speed;

    private int waypointIndex;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        // waypointIndex = 0;
        // transform.LookAt(waypoints[waypointIndex].position);
        shootCooldown = startShootCooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CrabAi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(player.position, transform.position);

        // if(distance > detectionRange && inCombat == false)//PATROLLING
        // {
        //     dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        //     if(dist<1f)
        //     {
        //         IncreaseIndex();
        //     }
        //     //Patrol();
        // }

        if(distance <= detectionRange)//can move
        {
            inCombat = true;
                canMove = true;
                if(canMove)
                {
                    CrabAi.SetDestination(player.transform.position);
                    CrabAni.SetBool("PlayerFound",true);
                }
                if(distance <= attackRangeRanged)//can attack range
                {
                    canAttackRanged = true;
                    canAttackMelee = false;
                    canMove = true;
                    CrabAni.SetBool("CanAttack",true);
                    CrabAni.SetBool("CanAttack2",false);

                    //Vector3 direction = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, player.position.z - transform.position.z);
                    CrabAi.SetDestination(player.transform.position);

                    if(shootCooldown <= 0)
                    {
                        Instantiate(bullet, transform.position, transform.rotation);    
                            shootCooldown = startShootCooldown;
                    }
                    else
                    {
                        shootCooldown -= Time.deltaTime;
                    }
                }
                else if(distance <= attackRangeMelee)//can attack melee
                {
                    canAttackMelee = true;
                    canMove = false;
                    CrabAni.SetBool("CanAttack",false);
                    CrabAni.SetBool("CanAttack2",true);
                }
                /*if(inCombat == true)//turret mode
                {
                    do
                    {
                        shootCooldown = 0;
                        canAttackRanged = true; 
                        canAttackMelee = false;
                        canMove = false;

                        Vector3 direction = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, player.position.z - transform.position.z);

                        transform.up = direction;

                        if(shootCooldown <= 0)
                        {
                            Instantiate(bullet, transform.position, transform.rotation);
                                shootCooldown = startShootCooldown;
                        }
                        else
                        {
                            shootCooldown -= Time.deltaTime;
                        }
                    }
                    while(distance > detectionRange);
                    shootCooldown = startShootCooldown;
                }*/
                else
                {
                canMove = true;
                canAttackRanged = false;
                canAttackMelee = false;
                CrabAni.SetBool("CanAttack",false);
                CrabAni.SetBool("CanAttack2",false);
                }
                
        }
        else
        {
            CrabAni.SetBool("PlayerFound",false);
            CrabAni.SetBool("CanAttack",false);
            CrabAni.SetBool("CanAttack2",false);
            canMove = false;
            canAttackRanged = false;
            canAttackMelee = false;
            CrabAi.SetDestination(this.transform.position);
        }
    }

    // void Patrol()
    // {
    //     transform.Translate(Vector3.forward * speed * Time.deltaTime);
    // }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
