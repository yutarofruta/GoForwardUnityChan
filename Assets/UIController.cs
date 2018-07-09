using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject unitychan;
    public GameObject runLength;
    public GameObject gameOver;

    private float distance = 0;
    private float speed = 0.3f;
    private float deadLine = -10f;

    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(!isGameOver) {
            distance += speed;
            runLength.GetComponent<Text>().text = "Distance: " + distance.ToString("F2") + "m";//F2=小数点2桁
        } else {
            if(Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene("GameScene");
                isGameOver = false;
            }
        }

        if(unitychan != null) {
            if (unitychan.transform.position.x < deadLine) {
                isGameOver = true;
                gameOver.GetComponent<Text>().text = "GAME OVER";
                Destroy(unitychan.gameObject);
            }
        }
        
	}
}
