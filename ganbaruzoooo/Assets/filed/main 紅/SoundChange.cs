using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private AudioSource audio;
    private AudioClip sound;
    private string songName;

    void Start()
    {
            sudio = GetCompoment<AudioSource>();
    }

    public void attack()
    {
        songName = "SoundA";
        Sound = (AudioClip)Resources.Load("Sound/" + songName);
        audio,PlayOnShot(Sound);
    }
    
    public void jump()
    {
        songName = "SoundB";
        Sound = (AudioClip)Resources.Load("Sound/" + songName);
        audio.PlayOnShot(Sound);
    }
}
