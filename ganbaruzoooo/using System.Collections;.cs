using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundChange : MonoBehaviour
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
          songName = "SoundA";
          Sound = (AudioClip)Resources.Load("Sound/" + songName);
          audio.PlayOneShot(Sound);
        }
 
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
          songName = "SoundB";
          Sound = (AudioClip)Resources.Load("Sound/" + songName);
          audio.PlayOneShot(Sound);
        }
 
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
          songName = "SoundC";
          Sound = (AudioClip)Resources.Load("Sound/" + songName);
          audio.PlayOneShot(Sound);
        }
    }
}