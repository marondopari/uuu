using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public float speed = 6.0f;      //���s���x
    public float jumpSpeed = 8.0f;  //�W�����v��
    public float gravity = 20.0f;   //�d�͂̑傫��

    private Vector3 moveDirection = Vector3.zero;   //�ړ���������ƃx�N�g���i�����́A���x�j
    private CharacterController controller;         //�L�����N�^�[�R���|�\�l���g�p�̕ϐ�

    void Start()
    {
        controller = GetComponent<CharacterController>();   //�L�����N�^�[�ɃA�^�b�`����Ă���L�����N�^�[�R���|�[�l���g���擾����
    }

    void Update()
    {
        //�L�����N�^�[�R���g���[���[�̂��Ă��邱�̃I�u�W�F�N�g���ڒn���Ă�����
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));  //���E�㉺�̃L�[���͂��擾���A�ړ��ʂɑ��
            moveDirection = transform.TransformDirection(moveDirection);    //�ړ����������[�J�����烏�[���h��Ԃɕϊ�����
            moveDirection = moveDirection * speed;      //�ړ����x���|����

            //�X�y�[�X�L�[��������Ă�����
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;           //Y�������ւ̈ړ���ǉ�����
            }
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);     //y�������ւ̈ړ��ɏd�͂�������
        controller.Move(moveDirection * Time.deltaTime);                    //�L�����N�^�[�R���g���[���[���ړ�������
    }
}
