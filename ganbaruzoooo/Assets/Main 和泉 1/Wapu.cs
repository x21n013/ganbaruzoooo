using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wapu : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider wa)
    {
         transform.position = new Vector3(transform.position.x + 575f, transform.position.y + 50f , transform.position.z + 280f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
