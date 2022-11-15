using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider t){
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x = 575f;    // x座標へ0.01加算
        pos.y = 50f;    // y座標へ0.01加算
        pos.z = 280f;    // z座標へ0.01加算
 
        t.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);  // 座標を設定
    }
}
