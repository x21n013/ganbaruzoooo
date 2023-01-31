using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm1 : MonoBehaviour
{
    private AudioSource audio;
    private AudioClip Sound;
    private string songName;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter(Collider bgmch)
    {
        if(bgmch.gameObject.tag=="Player")
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
