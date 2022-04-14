using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private float distance;
    public float moveSpeed;
    public float close;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= close)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
    }
}
