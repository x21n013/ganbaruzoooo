using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatiW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framea
    public Vector3 pos;
    private void OnTriggerEnter(Collider ogawarp)

    {
        if(ogawarp.gameObject.tag =="Player"){
            ogawarp.gameObject.transform.position = new Vector3(pos.x,pos.y,pos.z);

        }else{

        }
        
    }
}
