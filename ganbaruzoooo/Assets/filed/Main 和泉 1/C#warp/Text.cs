using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
      [SerializeField] GameObject text;
 
    void Start()
    {
        text.SetActive(false);
    }
 
    

    // Update is called once per frame
    void OnTriggerEnter(Collider text1)
    {
        if (text1.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
 
    void OnTriggerExit(Collider text1)
    {
        if (text1.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
