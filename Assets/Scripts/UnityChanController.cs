using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������
    Rigidbody2D rigid2D;

    // �n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    // �W�����v�̑��x�̌���
    private float dump = 0.8f;

    // �W�����v�̑��x
    float jumpVelocity = 20;

    // �Q�[���I�[�o�[�ɂȂ�ʒu
    private float deadLine = -9;


    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        animator = GetComponent<Animator>();
        // Rigidbody2D�̃R���|�[�l���g���擾����
        rigid2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
        animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > groundLevel) ? false : true;
        animator.SetBool("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;


        // ���n��ԂŃN���b�N���ꂽ�ꍇ
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // ������̗͂�������
            rigid2D.velocity = new Vector2(0, jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������
        if (Input.GetMouseButton(0) == false)
        {
            if (rigid2D.velocity.y > 0)
            {
                rigid2D.velocity *= dump;
            }
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�ɂ���
        if (transform.position.x < deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ���j�e�B������j������
            Destroy(gameObject);
        }
    }
}
