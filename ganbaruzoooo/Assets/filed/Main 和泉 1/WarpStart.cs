void Start () {
	characterController = GetComponent<CharacterController> ();
	animator = GetComponent <Animator> ();
	state = WarpCharaState.normal;
	instantiateParticle = GetComponent<InstantiateParticle> ();
}
