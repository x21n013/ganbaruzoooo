using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllScript : MonoBehaviour
{
//プライベートメンバ
private PlayerScript fpc;

void Start()
{
//プレイヤースクリプト取得
fpc = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
}

void Update()
{
}

/////////////////////////////////////////////////////////
//プレイヤースクリプトを有効にする
/////////////////////////////////////////////////////////
public void setPlayerActive()
{
fpc.enabled = true;
}

/////////////////////////////////////////////////////////
//プレイヤースクリプトを無効にする
/////////////////////////////////////////////////////////
public void setPlayerNotActive()
{
fpc.enabled = false;
}
}
