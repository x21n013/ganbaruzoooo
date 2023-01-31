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
 
    public void SoundA()
    {
        songName = "SoundA";
        Sound = (AudioClip)Resources.Load("Sound/" + songName);
        audio.PlayOneShot(Sound);
    }
 
    public void SoundB()
    {
        songName = "SoundB";
        Sound = (AudioClip)Resources.Load("Sound/" + songName);
        audio.PlayOneShot(Sound);
    }
 
}