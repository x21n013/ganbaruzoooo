using UnityEngine;
using System.Collections;
 
public class WarpChara : MonoBehaviour {
 
    public enum WarpCharaState
    {
        Normal,
        GoToWarpPoint,
    };
 
	private CharacterController characterController;
	private Animator animator;
	private Vector3 velocity = Vector3.zero;
	private WarpCharaState state;
	private Transform waitPoint;
	private Transform warpPoint;
	private InstantiateParticle instantiateParticle;
	//　歩く速さ
	public float walkSpeed;
	//　ワープポイントでキャラクターを中央に移動させたり回転させたりするスピード
	public float goToWaitPointSpeed;
}