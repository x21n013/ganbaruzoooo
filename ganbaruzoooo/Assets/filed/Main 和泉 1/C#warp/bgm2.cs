using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class bgm2 : MonoBehaviour
{
    private AudioSource audio;
    private AudioClip Sound;
    private string songName;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
          songName = "bgm1";
          Sound = (AudioClip)Resources.Load("Sound/" + songName);
          audio.PlayOneShot(Sound);
        }
 
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
          songName = "bgm2";
          Sound = (AudioClip)Resources.Load("Sound/" + songName);
          audio.PlayOneShot(Sound);
        }
 
       
    }
}