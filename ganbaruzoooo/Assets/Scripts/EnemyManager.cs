using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
  
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance < 2)
        {
            //攻撃
            agent.speed = 0;
        }
        else if(distance < 7)
        {
            //追跡
            agent.speed = 2;
        }
        else
        {
            //待機
            agent.speed = 0;
        }
        animator.SetFloat("distance" , distance);
    }
       private void OnTriggerEnter(Collider other)
    {
        Damage damager = other.GetComponent<Damage>();
        if(damager != null)
        {
            Debug.Log("攻撃をくらう");

        }




    }
}
