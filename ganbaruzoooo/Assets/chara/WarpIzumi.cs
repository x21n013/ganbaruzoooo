using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpIzumi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
public Vector3 pos;
    
        private void OnTriggerEnter(Collider Izumi)
    {
    if (Izumi.gameObject.tag=="Player"){
        Izumi.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }else{

    }
    }
}
