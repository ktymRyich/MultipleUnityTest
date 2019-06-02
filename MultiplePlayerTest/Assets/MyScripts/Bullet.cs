using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // コリジョンと衝突した場合の処理
    void OnCollisionEnter(Collision collision) {

        var hit = collision.transform.parent.gameObject;
        var health = hit.GetComponent<Health>();
        Debug.Log(hit.name);
        //Debug.Log("yes");
        if (health != null) {
            Debug.Log("oh...");
            //health.TakeDamage(10);
        }

        // オブジェクトを削除
        Destroy(gameObject);

    }
}
