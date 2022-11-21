using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;




public class PlayerManager : MonoBehaviour

{
    private Flowchart flowChart;
    Rigidbody rb;
    Animator animator;

    float x;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        /*PlayerPrefs.GetFloat("zahyoux",0);
        PlayerPrefs.GetFloat("zahyouy",0);
        PlayerPrefs.GetFloat("zahyouz",0);*/
    }
    
    // Update is called once per frame
    void Update()
    {
        //プレイヤーを上下左右に動かす。
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        Vector3 direction = transform.position +  new Vector3(x,0,z);
        transform.LookAt(direction);
        rb.velocity = new Vector3(x, 0, z)*3f;//移動速度
        animator.SetFloat("Speed",rb.velocity.magnitude);
    }

    //当たり判定
    private void OnTriggerEnter1(Collider other)
    {
        Damage damager = other.GetComponent<Damage>();
        if(damager != null)
        {
            Debug.Log("攻撃をくらう");
        }
    }

<<<<<<< HEAD
    //セーブ
    /*private void Save()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
        float positionX = transform.potion.x;
        float positionY = transform.potion.y;
        float positionZ = transform.potion.z;

        PlayerPrefs.SetFloat("zahyoux",positionX);
        PlayerPrefs.SetFloat("zahyouy",positionY);
        PlayerPrefs.SetFloat("zahyouz",positionZ);

        PlayerPrefs.Save();
        }
    }*/
    
=======
    void OnTriggerEnter(Collider collider){ 
        if (collider.gameObject.tag == "people"){
            Debug.Log("test");
        //animator.SetInteger("actid".(int)ActID.IDOL);
        flowChart = collider.gameObject.GetComponent<Flowchart>();
        flowChart.SendFungusMessage("Talk");
        }
     }
>>>>>>> 55786841f96a1f2dcc7c0ea2a40c9dc7da62d40e
}


