using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class GameScript1 : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform[] points;
    int n = 1;
 
    [SerializeField]
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        agent.destination = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
         // エージェントに目的地を設定
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = points[n].position;
 
            n++;
            if (n > 3) n = 0;
        }
 
        // ゲージを増減
        if (Input.GetMouseButton(0))
        {
            if (image.fillAmount > 0f)
            {
                image.fillAmount -= Time.deltaTime;
            }
            else
            {
                image.fillAmount = 0f;
            }
        }
        else {
            if (image.fillAmount < 1f)
            {
                image.fillAmount += Time.deltaTime;
            }
            else
            {
                image.fillAmount = 1f;
            }           
        }
        
 
    }
}
