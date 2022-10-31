using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wa2 : MonoBehaviour
{
    // Start is called before the first frame update
    
      // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
       Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x += -80f;    // x座標へ0.01加算
        pos.y += 1500.5f;    // y座標へ0.01加算
        pos.z += -40f;    // z座標へ0.01加算
 
        myTransform.position = pos;  // 座標を設定
    }
}


    // Update is called once per frame
   
