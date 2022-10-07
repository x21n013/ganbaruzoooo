using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraScript : MonoBehaviour
{
//定数
const float MOVE_SPEED = 5.0f; //移動スピード
const float ROTATE_SPEED = 200.0f; //回転スピード
const float TARGET_DISTANCE = 10.0f;//ターゲットの距離
const float CAMERA_HEIGHT = 5; //カメラの高さ

//プライベートメンバ
private GameObject targetObject; //ターゲットオブジェクト
private Vector3 targetPosition; //ターゲット位置

void Start()
{
//プレイヤーのオブジェクトをターゲットとする
targetObject = GameObject.FindWithTag("Player");
}

void Update()
{
if (targetObject != null)
{
//ターゲットの位置を取得
targetPosition = targetObject.transform.position;

//ターゲットの方向に向きを変える
var aim = targetPosition - transform.position;
//aim.y = 0; //上下（Y軸）の向きは変えない
var look = Quaternion.RotateTowards(transform.rotation,
Quaternion.LookRotation(aim, Vector3.up),
ROTATE_SPEED * Time.deltaTime);
this.transform.localRotation = look;

//ターゲットが離れた時
if (Vector3.Distance(transform.position, targetPosition) > TARGET_DISTANCE)
{
//前進させる
transform.position +=
transform.TransformDirection(new Vector3(0, 0, MOVE_SPEED * Time.deltaTime));
}

//Ｙ座標をターゲットに併せる
transform.position =
new Vector3(transform.position.x, targetPosition.y + CAMERA_HEIGHT, transform.position.z);
}
}
}
