using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerController : MonoBehaviour
{

    // -------------------------------------------------------
    /// <summary>
    /// ステータス.
    /// </summary>
    // -------------------------------------------------------
    [System.Serializable]
    public class Status
    {
        // 体力.
        public int Hp = 10;
        // 攻撃力.
        public int Power = 1;
    }
 
    // 攻撃HitオブジェクトのColliderCall.
    [SerializeField] ColliderCallReceiver attackHitCall = null;
    // 基本ステータス.
    [SerializeField] Status DefaultStatus = new Status();
    // 現在のステータス.
    public Status CurrentStatus = new Status();
 
    
    // 攻撃判定用オブジェクト.
    [SerializeField] GameObject attackHit = null;

    //設置判定用のColliderCall
    [SerializeField] ColliderCallReceiver footColliderCall = null;

    //ジャンプ力
    [SerializeField] float jumpPower = 10000f;

    // 自身のコライダー.
    [SerializeField] Collider myCollider = null;
    // 攻撃を食らったときのパーティクルプレハブ.
    [SerializeField] GameObject hitParticlePrefab = null;
    // パーティクルオブジェクト保管用リスト.
    List<GameObject> particleObjectList = new List<GameObject>();

    
        // PCキー横方向入力.
    float horizontalKeyInput = 0;
        // PCキー縦方向入力.
    float verticalKeyInput = 0;

    // アニメーター.
    Animator animator = null;

    //リジッドボディ
    Rigidbody rigid = null;

    // 攻撃アニメーション中フラグ
    bool isAttack = false;

    //接地フラグ
    bool isGround = false;
    

    // Start is called before the first frame update
    void Start()
    {
        // Animatorを取得し保管.
        animator = GetComponent<Animator>();
        //リジッドボディの取得
        rigid = GetComponent<Rigidbody>();
        // 攻撃判定用オブジェクトを非表示に.
        attackHit.SetActive( false );
        //FootSphereのイベント登録
        footColliderCall.TriggerStayEvent.AddListener( OnFootTriggerStay );
        footColliderCall.TriggerExitEvent.AddListener( OnFootTriggerExit );
        // 攻撃判定用コライダーイベント登録.
        attackHitCall.TriggerEnterEvent.AddListener( OnAttackHitTriggerEnter );
        // 現在のステータスの初期化.
        CurrentStatus.Hp = DefaultStatus.Hp;
        CurrentStatus.Power = DefaultStatus.Power;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalKeyInput = Input.GetAxis( "Horizontal" );
        verticalKeyInput = Input.GetAxis( "Vertical" );
 
        // プレイヤーの向きを調整.
        bool isKeyInput = ( horizontalKeyInput != 0 || verticalKeyInput != 0 );
        if( isKeyInput == true && isAttack == false )
        {
            bool currentIsRun = animator.GetBool( "isRun" );
            if( currentIsRun == false ) animator.SetBool( "isRun", true );
            Vector3 dir = rigid.velocity.normalized;
            dir.y = 0;
            this.transform.forward = dir;
        }
        else
        {
            bool currentIsRun = animator.GetBool( "isRun" );
            if( currentIsRun == true ) animator.SetBool( "isRun", false );
        }

    }

    void FixedUpdate()
    {
        if( isAttack == false )
            {
                 Vector3 input = new Vector3( horizontalKeyInput, 0, verticalKeyInput );
                Vector3 move = input.normalized * 8f;  //スピード変更
                //if(float )

                Vector3 cameraMove = Camera.main.gameObject.transform.rotation * move;
                 cameraMove.y = 0;
                Vector3 currentRigidVelocity = rigid.velocity;
                currentRigidVelocity.y = 0;
 
                rigid.AddForce( cameraMove - currentRigidVelocity, ForceMode.VelocityChange );
            }
    }   

    // ---------------------------------------------------------------------
    /// <summary>
    /// 攻撃ボタンクリックコールバック.
    /// </summary>
    // ---------------------------------------------------------------------
    public void OnAttackButtonClicked()
    {
        if( isAttack == false )
        {
            // AnimationのisAttackトリガーを起動.
            animator.SetTrigger( "isAttack" );
            // 攻撃開始.
            isAttack = true;
        }
    }

    // ---------------------------------------------------------------------
    /// <summary>
    /// ジャンプボタンクリックコールバック.
    /// </summary>
    // ---------------------------------------------------------------------
    public void OnjumpButtonClicked()
    {
         if( isGround == true )
        {
            rigid.AddForce( Vector3.up * jumpPower, ForceMode.Impulse );
        }
    }

     // ---------------------------------------------------------------------
    /// <summary>
    /// FootSphereトリガーステイコール.
    /// </summary>
    /// <param name="col"> 侵入したコライダー. </param>
    // ---------------------------------------------------------------------
    void OnFootTriggerStay( Collider col )
    {
        if( col.gameObject.tag == "Ground" )
        {
            if( isGround == false ) isGround = true;
            if( animator.GetBool( "isGround" ) == false ) animator.SetBool( "isGround", true );

        }
    }

    // ---------------------------------------------------------------------
    /// <summary>
    /// 攻撃判定トリガーエンターイベントコール.
    /// </summary>
    /// <param name="col"> 侵入したコライダー. </param>
    // ---------------------------------------------------------------------
    void OnAttackHitTriggerEnter( Collider col )
    {
        if( col.gameObject.tag == "Enemy" )
        {
            var enemy = col.gameObject.GetComponent<EnemyBase>();
            enemy?.OnAttackHit( CurrentStatus.Power, this.transform.position );
            attackHit.SetActive( false );
        }
    }

    // ---------------------------------------------------------------------
    /// <summary>
    /// FootSphereトリガーイグジットコール.
    /// </summary>
    /// <param name="col"> 侵入したコライダー. </param>
    // ---------------------------------------------------------------------
    void OnFootTriggerExit( Collider col )
    {
        if( col.gameObject.tag == "Ground" )
        {
            isGround = false;
            animator.SetBool( "isGround", false );

        }
    
    }
    /*富永会話システム


    private Flowchart flowChart;
    void OnTriggerEnter(Collider collider){ 
        
            if (collider.gameObject.tag == "people"){
            float? horizontalKeyInput = null;
            float? verticalKeyInput = null;
            flowChart = collider.gameObject.GetComponent<Flowchart>();
            flowChart.SendFungusMessage("Talk");
            }
        }
    */

    // ---------------------------------------------------------------------
    /// <summary>
    /// 敵の攻撃がヒットしたときの処理.
    /// </summary>
    /// <param name="damage"> 食らったダメージ. </param>
    // ---------------------------------------------------------------------
    
    public void OnEnemyAttackHit( int damage, Vector3 attackPosition )
    {
        CurrentStatus.Hp -= damage;
 
        var pos = myCollider.ClosestPoint( attackPosition );
        var obj = Instantiate( hitParticlePrefab, pos, Quaternion.identity );
        var par = obj.GetComponent<ParticleSystem>();
        StartCoroutine( WaitDestroy( par ) );
        particleObjectList.Add( obj );
 
        if( CurrentStatus.Hp <= 0 )
        {
            OnDie();
        }
        else
        {
            Debug.Log( damage + "のダメージを食らった!!残りHP" + CurrentStatus.Hp );
        }
    }
 
    // ---------------------------------------------------------------------
    /// <summary>
    /// パーティクルが終了したら破棄する.
    /// </summary>
    /// <param name="particle"></param>
    // ---------------------------------------------------------------------
    IEnumerator WaitDestroy( ParticleSystem particle )
    {
        yield return new WaitUntil( () => particle.isPlaying == false );
        if( particleObjectList.Contains( particle.gameObject ) == true ) particleObjectList.Remove( particle.gameObject );
        Destroy( particle.gameObject );
    }

    // ---------------------------------------------------------------------
    /// <summary>
    /// 死亡時処理.
    /// </summary>
    // ---------------------------------------------------------------------
    void OnDie()
    {
        Debug.Log( "死亡しました。" );

        StopAllCoroutines();
        if( particleObjectList.Count > 0 )
        {
            foreach( var obj in particleObjectList ) Destroy( obj );
            particleObjectList.Clear();
        }
    }

    // ---------------------------------------------------------------------
    /// <summary>
    /// 攻撃アニメーションHitイベントコール.
    /// </summary>
    // ---------------------------------------------------------------------
    void Anim_AttackHit()
    {
        Debug.Log( "Hit" );
        // 攻撃判定用オブジェクトを表示.
        attackHit.SetActive( true );
    }
    
    // ---------------------------------------------------------------------
    /// <summary>
    /// 攻撃アニメーション終了イベントコール.
    /// </summary>
    // ---------------------------------------------------------------------
    void Anim_AttackEnd()
    {
        Debug.Log( "End" );
        // 攻撃判定用オブジェクトを非表示に.
        attackHit.SetActive( false );
        // 攻撃終了.
        isAttack = false;
    }

}