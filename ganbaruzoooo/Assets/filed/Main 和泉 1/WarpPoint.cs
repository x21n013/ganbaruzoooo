void GoToWarpWaitPoint() {
 
    if (Vector3.Distance(transform.position, waitPoint.position) > 0.1f
        || Quaternion.Angle(transform.rotation, waitPoint.rotation) >= 5f
    ) {
        animator.SetFloat("Speed", 1f);
        Debug.Log("移動中");
        transform.position = Vector3.Lerp(transform.position, waitPoint.position, goToWaitPointSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, waitPoint.rotation, goToWaitPointSpeed * Time.deltaTime);
    } else if (transform.position != waitPoint.position
        //&& Quaternion.Angle(transform.rotation, waitPoint.rotation) < 5f
        ) {
        animator.SetFloat("Speed", 0f);
        Debug.Log("きっちり位置と角度を合わせる");
        transform.position = waitPoint.position;
        transform.rotation = waitPoint.rotation;
        //　ワープ用パーティクルの表示
        instantiateParticle.InstantiateWarpParticle(transform.position);
        //　3秒後にワープ
        Invoke("Warp", 3f);
    }
}