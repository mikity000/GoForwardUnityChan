using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // �X�N���[�����x
    private float scrollSpeed = -10;
    // �w�i�I���ʒu
    private float deadLine = -16;
    // �w�i�J�n�ʒu
    private float startLine = 15.8f;

    void Update()
    {
        // �w�i���ړ�����
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����A��ʉE�[�Ɉړ�����
        if (transform.position.x < deadLine)
            transform.position = new Vector2(startLine, 0);
    }
}
