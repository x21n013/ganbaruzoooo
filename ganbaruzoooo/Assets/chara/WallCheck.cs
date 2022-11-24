/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public int targetPosition;
    public int desiredPosition;
    public int wallHit;
    public int wallLayers;
    public int wallHitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //壁がカメラを貫通しないコマンド
protected bool wallCheck(){
    if (Physics.Raycast(targetPosition, desiredPosition - targetPosition, out wallHit, Vector3.Distance(targetPosition, desiredPosition), wallLayers, QueryTriggerInteraction.Ignore)){
        wallHitPosition = wallHit.point;
        return true;
    }else{
        return false;
    }
}
}*/