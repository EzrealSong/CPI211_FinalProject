using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    public enum States { Patrol, Follow, Attack }

    public NavMeshAgent agent;
    public Transform target;

    [Header("AI Properties")]
    public float shootDistance = 10f;
    //public Weapon attackWeapon;

    private bool inSight;
    private Vector3 directionToTarget;

    public Transform[] waypoints;

    public States currentState; 

    public int currentWaypoint = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStates();
        CheckForPlayer();
    }

    private void UpdateStates()
    {
        switch (currentState)
        {
            case States.Patrol:
                Patrol();
                break;
            case States.Follow:
                Follow();
                break;
            case States.Attack:
                Attack();
                break;
        }
    }

    private void CheckForPlayer()
    {
        directionToTarget = target.position - transform.position;

        RaycastHit hitInfo;

        if(Physics.Raycast(transform.position, directionToTarget.normalized, out hitInfo))
        {
            inSight = hitInfo.transform.CompareTag("Player");
        }
    }

    private void Patrol()
    {
        if(agent.destination != waypoints[currentWaypoint].position);
        {
            agent.destination = waypoints[currentWaypoint].position;
        }

        if(HasReached())
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    private void Follow()
    {
        if(agent.remainingDistance <= shootDistance && inSight)
        {
            agent.ResetPath();
            currentState = States.Attack;
        }
        else
        {
            if(target != null)
        {
            agent.SetDestination(target.position);
        }
        }
    }

    private void Attack()
    {
        if(!inSight)
        {
            currentState = States.Follow;
        }
        //attackWeapon.Fire();
    }

    private bool HasReached()
    {
        return (agent.hasPath && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);
    }
}
