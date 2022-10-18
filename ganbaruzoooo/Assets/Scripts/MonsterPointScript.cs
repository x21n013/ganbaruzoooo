using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPointScript : MonoBehaviour
{
//定数
const float ACTIVE_RANGE = 50f; //有効範囲

//パブリックメンバ
public GameObject baseObject; //ベースオブジェクト
public float instNextTime = 10; //再発生時間

//プライベートメンバ
private GameObject cloneObject; //クローンオブジェクト
private float elapsedTime; //経過時間
private GameObject playerObject; //プレイヤーオブジェクト

void Start()
{
elapsedTime = 0f;
cloneObject = null;

playerObject = GameObject.FindWithTag("Player");

//有効範囲内の時、モンスターを発生させる
if (Vector3.Distance(transform.position, playerObject.transform.position) <= ACTIVE_RANGE)
{
InstMonster();
}
}

void Update()
{
//有効範囲の判定
if (Vector3.Distance(transform.position, playerObject.transform.position) <= ACTIVE_RANGE)
{
//有効範囲内の時
if (cloneObject == null)
{
elapsedTime += Time.deltaTime;

//再発生時間が経過した時
if (elapsedTime > instNextTime)
{
//モンスターを発生させる
InstMonster();
//再発生時間初期化
elapsedTime = 0f;
}
}
}
else
{
//有効範囲外の時、モンスターオブジェクトを消す
if (cloneObject != null)
{
Destroy(cloneObject);
}
}
}

/////////////////////////////////////////////////////////
//モンスターを発生させる
/////////////////////////////////////////////////////////
void InstMonster()
{
//モンスターの向きをランダムに決定
var randomRotationY = Random.value * 360f;

//モンスターを発生させる
cloneObject = GameObject.Instantiate(baseObject,
transform.position,
Quaternion.Euler(0f, randomRotationY, 0f));
}
}