using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // ゲームオーバーテキスト
    private Text gameOverText;
    // 走行距離テキスト
    private Text runLengthText;
    // 走った距離
    private float length = 0;
    // 走る速度
    private float speed = 5f;
    // ゲームオーバーの判定
    private bool isGameOver = false;

    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        runLengthText = GameObject.Find("RunLength").GetComponent<Text>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            // 走った距離を更新する
            length += speed * Time.deltaTime;
            // 走った距離を表示する
            runLengthText.text = $"Distance: {length.ToString("F2")}m";
        }

        // ゲームオーバー後クリックしたら、シーンを読み込む
        if (isGameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        // ゲームオーバーになったときに、画面上にゲームオーバを表示する
        gameOverText.text = "Game Over";
        isGameOver = true;
    }
}
