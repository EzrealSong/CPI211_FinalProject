using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAnimatorController : MonoBehaviour
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
    NavMeshAgent SpiderAI;

    public Animator SpiderAni;


    public float health = 30f;
    private bool canMove = false;
    private bool canAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpiderAI = GetComponent<NavMeshAgent>();
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
                SpiderAni.SetBool("PlayerFound", true);
                SpiderAni.SetBool("InAttackRange", false);
                SpiderAI.SetDestination(player.transform.position);
            }

            if (distance <= AttackRange)//player in attack range
            {
                canAttack = true;
                canMove = false;
                SpiderAni.SetBool("InAttackRange", true);

            }
            canMove = true;
            canAttack = false;

        }
        //player out of range
        else
        {
            canMove = false;
            canAttack = false;
            SpiderAni.SetBool("PlayerFound", false);
            SpiderAni.SetBool("InAttackRange", false);
            SpiderAI.SetDestination(this.transform.position);//become Idle
        }

    }

}
