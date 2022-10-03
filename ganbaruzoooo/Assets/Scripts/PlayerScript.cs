using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
//定数
const float RAY_RANGE = 100f; //レイを飛ばす範囲
const float MOVE_SPEED = 5.0f; //移動スピード
const float ROTATE_SPEED = 200.0f; //回転スピード
const float GRAVITY = 5.0f; //重力
const float TARGET_RANGE = 1.5f; //ターゲット範囲
const float LIGHT_HEIGHT = 5; //ライトの高さ

//プライベートメンバ
private CharacterController characterController;

private Vector3 targetPosition; //ターゲット位置
private GameObject lightObject; //ターゲットライトオブジェクト

void Start()
{
characterController = GetComponent<CharacterController>();

targetPosition = Vector3.zero; //ターゲット位置
lightObject = GameObject.Find("Spot Light"); //ターゲットライトオブジェクト
}

void Update()
{
/////////////////////////////////////////////////////////
//ターゲット設定
/////////////////////////////////////////////////////////
if (Input.GetMouseButtonDown(0))
{
//クリック位置を取得
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

RaycastHit hit;
if (Physics.Raycast(ray, out hit, RAY_RANGE))
{
//クリック位置をターゲットとする
targetPosition = hit.point;
}
}

/////////////////////////////////////////////////////////
//ターゲット位置再設定
/////////////////////////////////////////////////////////
//ターゲットに近い時、ターゲットを初期化する
if (Vector3.Distance(transform.position, targetPosition) <= TARGET_RANGE)
{
targetPosition = Vector3.zero;
}

/////////////////////////////////////////////////////////
//ターゲット位置をライトで照らす
/////////////////////////////////////////////////////////
if (targetPosition != Vector3.zero)
{
lightObject.transform.position =
new Vector3(targetPosition.x, targetPosition.y + LIGHT_HEIGHT, targetPosition.z);
}

/////////////////////////////////////////////////////////
//プレイヤーの移動
/////////////////////////////////////////////////////////
Vector3 moveVec = Vector3.zero; //プレイヤーを動かす方向

//ターゲットがある時
if (targetPosition != Vector3.zero)
{
//ターゲットの方向に向きを変える
var aim = targetPosition - transform.position;
aim.y = 0; //上下（Y軸）の向きは変えない
var look =
Quaternion.RotateTowards(transform.rotation,
Quaternion.LookRotation(aim, Vector3.up),
ROTATE_SPEED * Time.deltaTime);
this.transform.localRotation = look;

//前進させる
moveVec = transform.TransformDirection(new Vector3(0, 0, MOVE_SPEED * Time.deltaTime));
}
//重力を加える
moveVec.y -= GRAVITY * Time.deltaTime;

//プレイヤーを移動する
characterController.Move(moveVec);
}
}
