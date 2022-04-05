using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject target; //�ǂ�������^�[�Q�b�g
    public Vector3 offset; //�^�[�Q�b�g����J�����܂ł̋���


    void Start()
    {
        offset = transform.position - target.transform.position;    //�����̏����擾
    }

    void Update()
    {


        transform.position = target.transform.position + offset;    //������ۂ��Ȃ���J�������ړ�
        
    }
}
