using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // ----------------------------------------------------------
    /// <summary>
    /// ステータス.
    /// </summary>
    // ----------------------------------------------------------
    [System.Serializable]
    public class Status
    {
        // HP.
        public int Hp = 10;
        // 攻撃力.
        public int Power = 1;
    }

    // 基本ステータス.
    [SerializeField] Status DefaultStatus = new Status();
    // 現在のステータス.
    public Status CurrentStatus = new Status();

    void Start()
    {
        // 最初に現在のステータスを基本ステータスとして設定.
        CurrentStatus.Hp = DefaultStatus.Hp;
        CurrentStatus.Power = DefaultStatus.Power;
    }

    // ----------------------------------------------------------
    /// <summary>
    /// 攻撃ヒット時コール.
    /// </summary>
    /// <param name="damage"> 食らったダメージ. </param>
    // ----------------------------------------------------------
    public void OnAttackHit( int damage )
    {
        CurrentStatus.Hp -= damage;
        Debug.Log( "Hit Damage " + damage + "/CurrentHp = " + CurrentStatus.Hp );

        if( CurrentStatus.Hp <= 0 )
        {
            OnDie();
        }
    }

    // ----------------------------------------------------------
    /// <summary>
    /// 死亡時コール.
    /// </summary>
    // ----------------------------------------------------------
    void OnDie()
    {
        Debug.Log( "死亡" );
        this.gameObject.SetActive( false );
    }

    // ----------------------------------------------------------
    /// <summary>
    /// 死亡アニメーション終了時コール.
    /// </summary>
    // ----------------------------------------------------------
    void Anim_DieEnd()
    {
    }
}