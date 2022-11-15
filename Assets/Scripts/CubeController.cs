using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //ブロックの音
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // キューブを移動させる
        transform.Translate(speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("ground"))
        {
            audioSource.Play();
        }
        else if (c.gameObject.CompareTag("cube"))
        {
            audioSource.Play();
        }
    }
}
