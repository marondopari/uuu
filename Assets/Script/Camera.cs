using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject target; //追いかけるターゲット
    public Vector3 offset; //ターゲットからカメラまでの距離


    void Start()
    {
        offset = transform.position - target.transform.position;    //距離の情報を取得
    }

    void Update()
    {


        transform.position = target.transform.position + offset;    //距離を保ちながらカメラを移動
        
    }
}
