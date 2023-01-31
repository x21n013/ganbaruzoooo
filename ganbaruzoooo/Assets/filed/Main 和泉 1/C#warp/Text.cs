using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  Textの部分もかぶらないように
public class Text : MonoBehaviour
{
      [SerializeField] GameObject panel;
 
    void Start()
    {
        panel.SetActive(false);
    }
 
    
//text1・text2以外 ←text〇   
    // Update is called once per frame
    void OnTriggerEnter(Collider text1)
    {
        if (this.gameObject.name == "Cube")
        {
            panel.SetActive(true);
        }
    }
 //text1・text2以外 ←text〇
    void OnTriggerExit(Collider text1)
    {
        if (this.gameObject.name == "Cube")
        {
            Destroy(panel,3);
        }
    }
}
