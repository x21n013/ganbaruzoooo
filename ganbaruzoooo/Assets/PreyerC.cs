using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class PreyerC : MonoBehaviour
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

    void PlayerC()
    {

        Playre.GetComponent<PlayerController>().enabled = true;
        Playre.GetComponent<Animator>().enabled = true; 
        Debug.Log("test");
    }
}
