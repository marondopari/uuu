using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public float speed = 6.0f;      //���s���x
    public float jumpSpeed = 8.0f;  //�W�����v���x
    public float gravity = 20.0f;   //�d�͂̑傫��
    
    private Vector3 moveVelocity = Vector3.zero;   //�ړ����x�x�N�g��
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

            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));  //���E�㉺�̃L�[���͂��擾���A�ړ������ɑ��
            moveDirection = transform.TransformDirection(moveDirection);    //�ړ����������[�J�����烏�[���h��Ԃɕϊ�����
            moveVelocity = moveDirection* speed;      //�ړ����x���|����

            //�X�y�[�X�L�[��������Ă�����
            if (Input.GetButton("Jump"))
            {
                moveVelocity.y = jumpSpeed;           //Y�������ւ̈ړ���ǉ�����
            }
        }
        
        moveVelocity.y = moveVelocity.y - (gravity* Time.deltaTime);     //y�������ւ̈ړ��ɏd�͂�������
        controller.Move(moveVelocity* Time.deltaTime);                    //�L�����N�^�[�R���g���[���[���ړ�������
    }
}
