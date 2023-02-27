using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    public float lookRadius = 10f;
    public static bool chasing = false;
    public Animator animator;
    
    //This script controlls the enemy AI.
    void Start()
    {
        //Looks for player game elements
        target = PlayerNavMesh.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //If player gets in the attack zone, the enemy will start walking towards the player
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            //Switches the animation to walk
            animator.SetBool("AOE", true);
            chasing = true;
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                //attack
                FaceTarget();
            }
        }
        else if (distance >= lookRadius)
        {
        //switches the animation back to idle
        animator.SetBool("AOE", false);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        //draws the attack zone in scene mode
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
