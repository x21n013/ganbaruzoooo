using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeontrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public Vector3 pos;
    
 
    private void OnCollisionEnter(Collision dungeontrap)
    {
    if (dungeontrap.gameObject.tag=="Player"){
        dungeontrap.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        
    }else{

    }
    }
}
