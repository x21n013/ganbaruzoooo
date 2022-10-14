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
const float INVINCIBLE_TIME = 1.0f; //無敵時間（1.0秒）

private enum ActID
{
IDOL = 0, //アイドル
RUN = 1, //走る
ATTACK = 2 //戦う
}

private enum HitID
{
NEUTRAL = 0, //ニュートラル
HIT = 1, //ヒット
DOWN = 2 //ダウン
}

//パブリックメンバ
public int HitPoint; //体力

//プライベートメンバ
private CharacterController characterController;
private Animator animator;

private Vector3 targetPosition; //ターゲット位置
private GameObject lightObject; //ターゲットライトオブジェクト

private GameObject targetObject; //ターゲットオブジェクト
private bool isDamage; //攻撃を受けている状態
private float elapsedTime; //経過時間

void Start()
{
characterController = GetComponent<CharacterController>();
animator = GetComponent<Animator>();

targetPosition = Vector3.zero; //ターゲット位置
lightObject = GameObject.Find("Spot Light"); //ターゲットライトオブジェクト

isDamage = false; //攻撃を受けている状態
elapsedTime = 0f; //経過時間
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
targetObject = hit.collider.gameObject;

//モンスターをクリックした時
if (targetObject.tag == "Monster")
{
//モンスターをターゲットとする
targetPosition = targetObject.transform.position;
}
else
{
targetObject = null;

//クリック位置をターゲットとする
targetPosition = hit.point;
}
}
}

/////////////////////////////////////////////////////////
//ターゲット位置再設定
/////////////////////////////////////////////////////////
//モンスターがターゲットの時
if (targetObject != null)
{
//モンスターの位置を再設定する
targetPosition = targetObject.transform.position;
}
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

/////////////////////////////////////////////////////////
//プレイヤーのアニメーション
/////////////////////////////////////////////////////////
//ターゲットがある時
if (targetPosition != Vector3.zero)
{
//走る
animator.SetInteger("actid", (int)ActID.RUN);
}
else
{
//モンスターのターゲットがない時
if (targetObject == null)
{
//アイドル状態
animator.SetInteger("actid", (int)ActID.IDOL);
}
}

/////////////////////////////////////////////////////////
//攻撃を受けている時の無敵時間制御
/////////////////////////////////////////////////////////
if (isDamage)
{
elapsedTime += Time.deltaTime;
if (elapsedTime >= INVINCIBLE_TIME)
{
//無敵時間を経過した時、次の攻撃を受け付ける
isDamage = false;
animator.SetInteger("hitid", (int)HitID.NEUTRAL);
}
}
}

/////////////////////////////////////////////////////////
//Colliderに触れている時に呼ばれるメゾット
/////////////////////////////////////////////////////////
void OnTriggerStay(Collider collider)
{
//モンスターに触れている時
if (collider.gameObject.tag == "Monster")
{
if (targetObject != null)
{
//モンスターの方向に向きを変える
this.transform.LookAt(collider.gameObject.transform.position);

//アニメーション（攻撃）
animator.SetInteger("actid", (int)ActID.ATTACK);
}
}
//モンスターのダメージ部分に触れている時
if (collider.gameObject.tag == "Damage")
{
if (!isDamage)
{
//無敵時間制御用変数初期化
isDamage = true;
elapsedTime = 0f;

//体力計算
HitPoint--;
if (HitPoint <= 0)
{
//アニメーション（ダウン）
animator.SetInteger("hitid", (int)HitID.DOWN);
}
else
{
//アニメーション（ダメージ）
animator.SetInteger("hitid", (int)HitID.HIT);
}
}
}
}
}
