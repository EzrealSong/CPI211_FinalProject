using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Giant : MonoBehaviour
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
    NavMeshAgent GiantAI;

    public Animator GiantAni;


    public float health = 50f;
    private bool canMove = false;
    private bool canAttack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GiantAI = GetComponent<NavMeshAgent>();
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
                GiantAni.SetBool("PlayerDetected", true);
                GiantAni.SetBool("PlayerInRange", false);
                GiantAI.SetDestination(player.transform.position);
            }

            if (distance <= AttackRange)//player in attack range
            {
                canAttack = true;
                canMove = false;
                GiantAni.SetBool("PlayerInRange", true);

            }
            canMove = true;
            canAttack = false;

        }
        //player out of range
        else
        {
            canMove = false;
            canAttack = false;
            GiantAni.SetBool("PlayerDetected", false);
            GiantAni.SetBool("PlayerInRange", false);
            GiantAI.SetDestination(this.transform.position);//become Idle
        }

    }

}
