using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapreturn1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Vector3 pos;
    
 
    private void OnTriggerEnter(Collider dungeonreturn1)
    {
    if (dungeonreturn1.gameObject.tag=="Player"){
        dungeonreturn1.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        
    }else{

    }
    }
}
