using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatiWGoal: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framea
    public Vector3 pos;
    private void OnTriggerEnter(Collider ogawarp1)

    {
        if(ogawarp1.gameObject.tag =="Player"){
            ogawarp1.gameObject.transform.position = new Vector3(pos.x,pos.y,pos.z);

        }else{

        }
        
    }
}
