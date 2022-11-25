using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
       public Vector3 pos;
    
 
    private void OnTriggerEnter(Collider Goal)
    {
    if (Goal.gameObject.tag=="Player"){
        Goal.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        
    }else{

    }
    }
}
