using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject BulletPrefab;
    public Transform  BulletTransform;
    public GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            playerBody.GetComponent<MeshRenderer>().material.color = Color.red;
            return ;
        }

        // 左右方向の入力値を変数 x に代入
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        // 前後方向 入力値を変数 z に代入
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        // オブジェクトの方向転換の制御
        // （変数 xの値をオブジェクトのY軸回転に代入）
        transform.Rotate(0, x, 0);
        // オブジェクトの前進、後退の制御
        // （変数 z の値をオブジェクトのZ座標に代入）
        transform.Translate(0, 0, z);
        //なぜこのコードでwasdの操作ができるのかわからんのだが


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command]
    void CmdFire() {
        
        var bullet = (GameObject)Instantiate(BulletPrefab,
                                 BulletTransform.position,
                                 BulletTransform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        // MeshRenderer コンポーネントを取得してマテリアルカラーを blue に設定
        playerBody.GetComponent<MeshRenderer>().material.color = Color.black;
        //BulletPrefab.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
