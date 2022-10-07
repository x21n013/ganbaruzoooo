using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
//定数
const int RANDOM_RANGE = 30; //ランダム範囲
const float ROTATE_SPEED = 200.0f; //回転スピード

//プライベートメンバ
private Rigidbody rigidbody;

void Start()
{
rigidbody = GetComponent<Rigidbody>();
}

void Update()
{
/////////////////////////////////////////////////////////
//モンスターの移動
/////////////////////////////////////////////////////////
int i = (int)Random.Range(0, RANDOM_RANGE);

//乱数で０の時
if (i == 0)
{
//前方に力を加えて前進させる
Vector3 moveVec =
transform.TransformDirection(new Vector3(0, 0, 1));
rigidbody.AddForce(moveVec, ForceMode.Impulse);
}
//乱数で１の時
else if (i == 1)
{
//右方向に回転させる
var aim = transform.right;
var look =
Quaternion.RotateTowards(transform.rotation,
Quaternion.LookRotation(aim, Vector3.up),
ROTATE_SPEED * Time.deltaTime);
this.transform.localRotation = look;
}
}
}
