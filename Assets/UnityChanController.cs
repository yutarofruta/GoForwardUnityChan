using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネント
    Rigidbody2D rigid2D;

    //public AudioClip jump;
    //AudioSource aud;

    //地面の位置
    private float groundLevel = -2.9f;

    //ジャンプ速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;

	// Use this for initialization
	void Start () {
        //アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネント取得
        this.rigid2D = GetComponent<Rigidbody2D>();

        //this.aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y <= this.groundLevel);
        this.animator.SetBool("isGround", isGround);

        if (Input.GetMouseButtonDown(0) && isGround) {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
            //aud.PlayOneShot(this.jump);
        }

        if(Input.GetMouseButton(0) == false) {
            if(this.rigid2D.velocity.y > 0) {
                this.rigid2D.velocity *= this.dump;
            }
        }

        
        GetComponent<AudioSource>().volume = (isGround) ?1:0;
        

    }
}
