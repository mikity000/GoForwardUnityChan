using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // �Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    // ���s�����e�L�X�g
    private GameObject runLengthText;

    // ����������
    private float len = 0;

    // ���鑬�x
    private float speed = 5f;

    // �Q�[���I�[�o�[�̔���
    private bool isGameOver = false;

    void Start()
    {
        // �V�[���r���[����I�u�W�F�N�g�̎��̂���������
        gameOverText = GameObject.Find("GameOver");
        runLengthText = GameObject.Find("RunLength");
    }

    void Update()
    {
        if (!isGameOver)
        {
            // �������������X�V����
            len += speed * Time.deltaTime;

            // ������������\������
            runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        // �Q�[���I�[�o�[�ɂȂ����ꍇ
        if (isGameOver == true)
        {
            // �N���b�N���ꂽ��V�[�������[�h����
            if (Input.GetMouseButtonDown(0))
            {
                //SampleScene��ǂݍ���
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void GameOver()
    {
        // �Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o��\������
        gameOverText.GetComponent<Text>().text = "Game Over";
        isGameOver = true;
    }
}
