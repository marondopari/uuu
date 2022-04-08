using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public float speed = 6.0f;      //歩行速度
    public float jumpSpeed = 8.0f;  //ジャンプ速度
    public float gravity = 20.0f;   //重力の大きさ
    
    private Vector3 moveVelocity = Vector3.zero;   //移動速度ベクトル
    private CharacterController controller;         //キャラクターコンポ―ネント用の変数

    void Start()
    {
        controller = GetComponent<CharacterController>();   //キャラクターにアタッチされているキャラクターコンポーネントを取得する
    }

    void Update()
    { 
     //キャラクターコントローラーのついているこのオブジェクトが接地していたら
        if (controller.isGrounded)
        {

            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));  //左右上下のキー入力を取得し、移動方向に代入
            moveDirection = transform.TransformDirection(moveDirection);    //移動方向をローカルからワールド空間に変換する
            moveVelocity = moveDirection* speed;      //移動速度を掛ける

            //スペースキーが押されていたら
            if (Input.GetButton("Jump"))
            {
                moveVelocity.y = jumpSpeed;           //Y軸方向への移動を追加する
            }
        }
        
        moveVelocity.y = moveVelocity.y - (gravity* Time.deltaTime);     //y軸方向への移動に重力を加える
        controller.Move(moveVelocity* Time.deltaTime);                    //キャラクターコントローラーを移動させる
    }
}
