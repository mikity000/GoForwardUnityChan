using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    // �L���[�u��Prefab
    public GameObject cubePrefab;

    // ���Ԍv���p�̕ϐ�
    private float delta = 0;

    // �L���[�u�̐����Ԋu
    private float span = 1.0f;

    // �L���[�u�̐����ʒu�FX���W
    private float genPosX = 12;

    // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetY = 0.3f;
    // �L���[�u�̏c�����̊Ԋu
    private float spaceY = 6.9f;

    // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetX = 0.5f;
    // �L���[�u�̉������̊Ԋu
    private float spaceX = 0.4f;

    // �L���[�u�̐������̏��
    private int maxBlockNum = 4;

    void Update()
    {
        delta += Time.deltaTime;

        // span�b�ȏ�̎��Ԃ��o�߂������𒲂ׂ�
        if (delta > span)
        {
            delta = 0;
            // ��������L���[�u���������_���Ɍ��߂�
            int n = Random.Range(1, maxBlockNum + 1);

            // �w�肵���������L���[�u�𐶐�����
            for (int i = 0; i < n; i++)
            {
                // �L���[�u�̐���
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(genPosX, offsetY + i * spaceY);
            }
            // ���̃L���[�u�܂ł̐������Ԃ����߂�
            span = offsetX + spaceX * n;
        }
    }
}
