public void SetState(WarpCharaState state, Transform waitPoint = null, Transform warpPoint = null) {
    this.state = state;
    this.waitPoint = waitPoint;
    this.warpPoint = warpPoint;
 
    //　状態に応じた処理
    if (state == WarpCharaState.GoToWarpPoint) {
        velocity = Vector3.zero;
        characterController.enabled = false;
    } else if(state == WarpCharaState.Normal) {
        characterController.enabled = true;
    }
}