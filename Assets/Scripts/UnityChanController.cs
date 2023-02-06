using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator anim;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rb2D;
    // 地面の位置
    private float groundLevel = -3.0f;
    // ジャンプの速度の減衰
    private float dump = 0.8f;
    // ジャンプの速度
    float jumpVelocity = 20;
    // ゲームオーバーになる位置
    private float deadLine = -9;

    void Start()
    {
        // アニメータのコンポーネントを取得する
        anim = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        anim.SetFloat("Horizontal", 1);
        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > groundLevel) ? false : true;
        anim.SetBool("isGround", isGround);
        // ジャンプ状態のときにはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;


        // 着地状態でクリックされた場合、上方向の力をかける
        if (Input.GetMouseButtonDown(0) && isGround)
            rb2D.velocity = new Vector2(0, jumpVelocity);

        // クリックをやめたら上方向への速度を減速する
        if (!Input.GetMouseButton(0) && rb2D.velocity.y > 0)
            rb2D.velocity *= dump;

        // デッドラインを超えた場合ゲームオーバにする
        if (transform.position.x < deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            // ユニティちゃんを破棄する
            Destroy(gameObject);
        }
    }
}
