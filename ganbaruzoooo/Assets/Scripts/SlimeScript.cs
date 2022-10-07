using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
//定数
const int RANDOM_RANGE = 30; //ランダム範囲
const float ROTATE_SPEED = 200.0f; //回転スピード

const float INVINCIBLE_TIME = 1.0f; //無敵時間（1.0秒）
const float DESTROY_TIME = 1.0f; //削除時間（1秒）

//パブリックメンバ
public int HitPoint; //体力

//プライベートメンバ
private Rigidbody rigidbody;
private bool isDamage; //攻撃を受けている状態
private float elapsedTime; //経過時間

void Start()
{
rigidbody = GetComponent<Rigidbody>();

isDamage = false; //攻撃を受けている状態
elapsedTime = 0f; //経過時間
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
}
}
}

/////////////////////////////////////////////////////////
//Colliderに触れている時に呼ばれるメゾット
/////////////////////////////////////////////////////////
void OnTriggerStay(Collider collider)
{
//プレイヤーに触れている時
if (collider.gameObject.tag == "Player")
{
//プレイヤーの方向に向きを変える
this.transform.LookAt(collider.gameObject.transform.position);
//衝突で発生した回転を調整する
this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
}
//プレイヤーのダメージ部分（剣）に触れている時
if (collider.gameObject.tag == "Sword")
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
Destroy(this.gameObject, DESTROY_TIME);
}
}
}
}
}