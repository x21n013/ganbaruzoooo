using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Pst : MonoBehaviour
{
    public GameObject Playre;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    void Playerst()
    {

        Playre.GetComponent<PlayerController>().enabled = false;
        //Playre.GetComponent<Animator>().enabled = false; 
        
    }
}