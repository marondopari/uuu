using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    private const int maxHp = 100;  //�v���C���[HP�ő�l100
    private int currentHp;          //���݂�HP
    public Slider hpSlider;            //�V�[���ɔz�u����Slider�i�[�p

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GameObject.Find("Slider").GetComponent<Slider>();  // �X���C�_�[���擾����
        hpSlider.maxValue = maxHp;    // Slider�̍ő�l���v���C���[HP�ő�l�ƍ��킹��
        
        currentHp = maxHp;      // ������Ԃ�HP���^��
        hpSlider.value = currentHp;	// Slider�̏�����Ԃ�ݒ�iHP���^���j
    }
    
    // �����蔻��
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy")    // �G�l�~�[�ƂԂ������Ƃ�
        {
            currentHp -= 10;        // ���݂�HP�����炷
            hpSlider.value = currentHp;   // Slider�Ɍ���HP��K�p
            Debug.Log("slider.value = " + hpSlider.value);

            // Slider���ŏ��l�ɂȂ�����i��F���񂾂�j
            if (hpSlider.value <= 0)
            {
                Destroy(gameObject);            // ���̂�����
                Destroy(GameObject.Find("Slider")); // Slider������
            }
        }
    }
}
