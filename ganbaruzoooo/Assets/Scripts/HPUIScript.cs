using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUIScript : MonoBehaviour
{
private StatusScript status; //親のステータススクリプト
private Slider hpSlider; //子のスライダー

void Start()
{
//親のステータススクリプト取得
GameObject parent = transform.parent.gameObject;
status = parent.gameObject.GetComponent<StatusScript>();

//子のスライダー取得
GameObject child = transform.Find("HPBar").gameObject;
hpSlider = child.gameObject.GetComponent<Slider>();
}

void Update()
{
//カメラと同じ向きに設定
transform.rotation = Camera.main.transform.rotation;

//スライダーに体力／最大体力を設定する
hpSlider.value = (float)status.HitPoint / (float)status.MaxHitPoint;
}
}

