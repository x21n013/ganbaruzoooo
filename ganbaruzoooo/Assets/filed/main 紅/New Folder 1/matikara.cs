using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matikara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Vector3 pos;
    
        private void OnTriggerEnter(Collider matikara)
    {
    if (matikara.gameObject.tag=="Player"){
        matikara.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }else{

    }
    }
}

