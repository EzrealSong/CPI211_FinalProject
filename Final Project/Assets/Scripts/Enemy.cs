using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
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
    NavMeshAgent Skeleton;
    [SerializeField]
    private Animator Animator;
    [SerializeField]

    private bool canMove = false;
    private bool canAttack = false;
  
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

        if(distance <= FindingRange)
        {
            canMove = true;
            //transform.LookAt(player);
            //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            if(canMove == true)//player in range
            {
                Animator.SetBool("PlayerFound", true);
                Skeleton.SetDestination(player.transform.position);

            }
            
        }
        else //player out of range
        {
            canMove = false;
            Animator.SetBool("PlayerFound", false);
            Skeleton.SetDestination(this.transform.position);
        }
    }
}
