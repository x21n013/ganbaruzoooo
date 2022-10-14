// Update is called once per frame
void Update () {
	if (state == WarpCharaState.normal) {
		if (characterController.isGrounded) {
			velocity = Vector3.zero;
			var input = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
 
			if (input.magnitude > 0f) {
				transform.LookAt (transform.position + input);
				velocity += transform.forward * walkSpeed;
				animator.SetFloat ("Speed", 1f);
			} else {
				animator.SetFloat ("Speed", 0f);
			}
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move (velocity * Time.deltaTime);
	} else if (state == WarpCharaState.goToWarpPoint) {
		GoToWarpWaitPoint ();
	}
}
