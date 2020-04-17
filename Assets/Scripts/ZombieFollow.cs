using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator anim;

    public float moveSpeed = 4f;
    public float argoRange = 10f;
    public float attackRange = 1f;

    float attackCooldown = 60f;
    float attackTimer = 0;

    Vector3 distance;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        anim = GetComponent<Animator>();
        anim.SetTrigger("Reset");

        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    void FollowPlayer()
    {
        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("REACHING POGGERS PEEPO SLEEPO");
            anim.SetTrigger("Attack");
            PlayerHandler.Instance.TakeDamage(10);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetTrigger("Reset");
    }

    private void Update()
    {
        distance = player.transform.position - this.transform.position;

        attackTimer++;

        if (Mathf.Abs(distance.x) < 1 && Mathf.Abs(distance.z) < 1)
        {
            if (attackCooldown < attackTimer)
            {
                anim.SetTrigger("Attack");
                PlayerHandler.Instance.TakeDamage(10f);
                attackTimer = 0;
            }
        }

        if(Mathf.Abs(distance.x) > attackRange && Mathf.Abs(distance.z) > attackRange)
        {
            FollowPlayer();
        }
    }
}
