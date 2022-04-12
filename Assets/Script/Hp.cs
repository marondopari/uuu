using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    private const int maxHp = 100;  //プレイヤーHP最大値100
    private int currentHp;          //現在のHP
    public Slider hpSlider;            //シーンに配置したSlider格納用

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GameObject.Find("Slider").GetComponent<Slider>();  // スライダーを取得する
        hpSlider.maxValue = maxHp;    // Sliderの最大値をプレイヤーHP最大値と合わせる
        
        currentHp = maxHp;      // 初期状態はHP満タン
        hpSlider.value = currentHp;	// Sliderの初期状態を設定（HP満タン）
    }
    
    // 当たり判定
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy")    // エネミーとぶつかったとき
        {
            currentHp -= 10;        // 現在のHPを減らす
            hpSlider.value = currentHp;   // Sliderに現在HPを適用
            Debug.Log("slider.value = " + hpSlider.value);

            // Sliderが最小値になったら（例：死んだら）
            if (hpSlider.value <= 0)
            {
                Destroy(gameObject);            // 物体を消去
                Destroy(GameObject.Find("Slider")); // Sliderも消去
            }
        }
    }
}
