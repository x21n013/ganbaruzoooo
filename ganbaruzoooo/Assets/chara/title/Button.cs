
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class GameStart : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("小川　石流");
    }
}