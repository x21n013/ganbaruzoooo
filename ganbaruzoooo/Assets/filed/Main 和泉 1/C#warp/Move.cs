using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    
    public Vector3 pos;
 
    private void OnCollisionEnter(Collision colli)
    {
        colli.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
