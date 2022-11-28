using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
 
    void Update()
    {
        if(target.GetComponent<PlayerController>().isArea == true) 
        {
            agent.destination = target.transform.position;
        }
    }
}