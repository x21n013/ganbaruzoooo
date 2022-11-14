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

    void OnTriggerEnter(Collider collider){ 
        if (collider.gameObject.tag == "people"){
            Debug.Log("test");
        //animator.SetInteger("actid".(int)ActID.IDOL);
        flowChart = collider.gameObject.GetComponent<Flowchart>();
        flowChart.SendFungusMessage("Talk");
        }
     }
}


