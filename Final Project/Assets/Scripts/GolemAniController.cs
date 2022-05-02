using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAniController : MonoBehaviour
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
    NavMeshAgent GolemAI;

    public Animator GolemAni;


    public float health = 130f;
    private bool canMove = false;
    Target target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GolemAI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if (distance <= FindingRange)//found player
        {
            canMove = true;
            if (canMove)
            {
                GolemAni.SetBool("PlayerFound", true);
                GolemAni.SetBool("CanAttack", false);
                GolemAI.SetDestination(player.transform.position);
            }

            if (distance <= AttackRange)//player in attack range
            {
                canMove = false;
                GolemAni.SetBool("CanAttack", true);

            }
            canMove = true;

        }
        //player out of range
        else
        {
            canMove = false;
            GolemAni.SetBool("PlayerFound", false);
            GolemAni.SetBool("CanAttack", false);
            GolemAI.SetDestination(this.transform.position);//become Idle
        }

    }

}
