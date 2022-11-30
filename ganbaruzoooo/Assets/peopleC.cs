using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class peopleC : MonoBehaviour
{
    
     public GameObject Playre;
     public GameObject people;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
         float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 0;
        float dz = Input.GetAxis("Vertical") * Time.deltaTime * 0;
        transform.position = new Vector3 (
            transform.position.x + dx, 0, transform.position.z + dz
        );
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DogPolyart Variant" ){
            Playre.GetComponent<PlayerController>().enabled = false;
            Playre.GetComponent<Animator>().enabled = false;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            //GetComponent<BoxCollider>().enabled = false;
            Debug.Log("test");
        }
    }
   /* void update(){
        Playre.GetComponent<PlayerController>().enabled = true;
        Playre.GetComponent<Animator>().enabled = true;
    }*/
}
