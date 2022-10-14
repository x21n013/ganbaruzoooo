using UnityEngine;
using System.Collections;
 
public class Warp : MonoBehaviour {
 
	public Transform warpPoint;
 
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			//　キャラクターの状態をワープ状態に変更
			col.GetComponent <WarpChara>().SetState(WarpChara.WarpCharaState.GoToWarpPoint, transform, warpPoint);
		}
	}
}
 
