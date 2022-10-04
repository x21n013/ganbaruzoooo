//
// 攻撃判定用 の Collider の有効化/無効化を行う
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonfire.Combat
{
    public class AttackAreaActivator : MonoBehaviour
    {
        // コライダー複数版にするときに配列にする予定
        Collider attackAreaCollider = null;

        AttackArea attackArea = null;

        // 攻撃したした回数 （後で多段ヒット防止に使う）
        int attackCount = 0;

        void Start()
        {
            SetAttackArea();
        }

        // 武器の付け替えなどのときに、コライダーを再取得する
        public void SetAttackArea()
        {
            attackArea = GetComponentInChildren<AttackArea>();
            attackAreaCollider = attackArea.GetComponent<Collider>();
            // 初期化時点では無効にしておく
            attackAreaCollider.enabled = false;
        }

        // アニメーションイベントのStartAttackHitを受け取ってコライダを有効にする
        void StartAttackHit()
        {
            attackCount++;
            attackAreaCollider.enabled = true;
            attackArea.attackCount = attackCount;          
        }

        // アニメーションイベントのEndAttackHitを受け取ってコライダを無効にする
        void EndAttackHit()
        {
            attackAreaCollider.enabled = false;
        }
    }
}