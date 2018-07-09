using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public AudioClip block;

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.y < deadLine) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "BlockTag" || collision.gameObject.tag == "GroundTag") {
            GetComponent<AudioSource>().PlayOneShot(block);
        }


    }
}
