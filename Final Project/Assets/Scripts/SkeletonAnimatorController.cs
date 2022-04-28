using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAnimatorController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float FindingRange;
    [SerializeField]
    public float AttackRange;
    [SerializeField]
    NavMeshAgent Skeleton;
    [SerializeField]
    private Animator Animator;
    [SerializeField]

    public float health = 50f;
    private bool canMove = false;
    private bool canAttack = false;
    Target target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Skeleton = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= FindingRange)//found player
        {
            canMove = true;
            if(canMove)
            {
                Animator.SetBool("PlayerFound", true);
                Animator.SetBool("CanAttack", false);
                Skeleton.SetDestination(player.transform.position);
            }
            
            if(distance <= AttackRange)//player in attack range
            {
                canAttack = true;
                canMove = false;
                Animator.SetBool("CanAttack", true);
                
            }
            canMove = true;
            canAttack = false;
            
        }
         //player out of range
        else
        {
            canMove = false;
            canAttack = false;
            Animator.SetBool("PlayerFound", false);
            Animator.SetBool("CanAttack", false);
            Skeleton.SetDestination(this.transform.position);//become Idle
        }
        
    }
     
}
