using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // ゲームオーバーテキスト
    private GameObject gameOverText;

    // 走行距離テキスト
    private GameObject runLengthText;

    // 走った距離
    private float len = 0;

    // 走る速度
    private float speed = 5f;

    // ゲームオーバーの判定
    private bool isGameOver = false;

    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        gameOverText = GameObject.Find("GameOver");
        runLengthText = GameObject.Find("RunLength");
    }

    void Update()
    {
        if (!isGameOver)
        {
            // 走った距離を更新する
            len += speed * Time.deltaTime;

            // 走った距離を表示する
            runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        // ゲームオーバーになった場合
        if (isGameOver == true)
        {
            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void GameOver()
    {
        // ゲームオーバーになったときに、画面上にゲームオーバを表示する
        gameOverText.GetComponent<Text>().text = "Game Over";
        isGameOver = true;
    }
}
