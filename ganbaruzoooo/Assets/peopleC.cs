using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleC : MonoBehaviour
{
     public GameObject Playre;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
         float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
        float dz = Input.GetAxis("Vertical") * Time.deltaTime * 3;
        transform.position = new Vector3 (
            transform.position.x + dx, 0, transform.position.z + dz
        );
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DogPolyart Variant" ){
            Playre.GetComponent<PlayerController>().enabled = false;
        }
    }
}
