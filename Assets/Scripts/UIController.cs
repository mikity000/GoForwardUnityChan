using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // �Q�[���I�[�o�[�e�L�X�g
    private Text gameOverText;
    // ���s�����e�L�X�g
    private Text runLengthText;
    // ����������
    private float length = 0;
    // ���鑬�x
    private float speed = 5f;
    // �Q�[���I�[�o�[�̔���
    private bool isGameOver = false;

    void Start()
    {
        // �V�[���r���[����I�u�W�F�N�g�̎��̂���������
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        runLengthText = GameObject.Find("RunLength").GetComponent<Text>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            // �������������X�V����
            length += speed * Time.deltaTime;
            // ������������\������
            runLengthText.text = $"Distance: {length.ToString("F2")}m";
        }

        // �Q�[���I�[�o�[��N���b�N������A�V�[����ǂݍ���
        if (isGameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        // �Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o��\������
        gameOverText.text = "Game Over";
        isGameOver = true;
    }
}
