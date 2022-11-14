using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warpsys : MonoBehaviour
{
    // Start is called before the first frame update
      void OnTriggerEnter(Collider ta){
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x = -80f;    // x座標へ0.01加算
        pos.y = 1500.5f;    // y座標へ0.01加算
        pos.z = -40f;    // z座標へ0.01加算
 
        myTransform.position = pos;  // 座標を設定
        ta.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);  // 座標を設定
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
