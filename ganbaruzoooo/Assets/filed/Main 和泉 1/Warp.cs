using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collections Collections)
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //transformを取得
        Transform myTransform = this.transform;

        //座標を取得
        Vector3 pos = myTransform.position;
        pos.x += 10000f;    //x座標へ10000加算
        pos.y += 10000f;    //y座標へ10000加算
        pos.z += 10000f;    //z座標へ10000加算

        myTransform.position = pos; //座標を設定
        
    }
}
