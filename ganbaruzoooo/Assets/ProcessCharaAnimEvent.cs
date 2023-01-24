using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCharaAnimEvent : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip attackSound;
    [SerializeField]
    private Transform equipTransform;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetCompoment <AudioSorce>();
    }

    // Update is called once per frame
    void AttackStart(){
        weponCollder.enable = true;
        if (equip.GetChild(0).CompareTag ("sword")){
            audioSource.PlayOneshot (attackSound);
        }
    }
    if (equipTransform.GetChild(0).name == "Broadsword(Clone)"){
        audioSource.PlayOneshot(attackSound);
    }
}
