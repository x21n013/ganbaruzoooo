using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
      [SerializeField] GameObject panel;
 
    void Start()
    {
        panel.SetActive(false);
    }
 
    

    // Update is called once per frame
    void OnTriggerEnter(Collider text1)
    {
        if (this.gameObject.name == "Cube")
        {
            
            panel.SetActive(true);
        }
    }
 
    void OnTriggerExit(Collider text1)
    {
        if (this.gameObject.name == "Cube")
        {
            panel.SetActive(false);
        }
    }
}
