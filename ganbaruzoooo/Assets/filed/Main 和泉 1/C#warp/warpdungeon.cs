using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpdungeon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public Vector3 pos;
    //↓この文は使わない
    // private string answerTag = "Player";
 
    private void OnCollisionEnter(Collision dungeon1)
    {
    if (dungeon1.gameObject.tag=="Player"){
        dungeon1.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }else{

    }
    }
}
