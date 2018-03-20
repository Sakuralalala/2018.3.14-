using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    public Rigidbody rigid;
    public float moveSpeed=5.0f;
    public float jumpSpeed = 5.0f;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public GameObject main;
    public GameObject leftPos;
    public GameObject rightPos;
    public Rigidbody rigidMain;
    
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        leftPos = GameObject.Find("left");//获取左锚点
        rightPos = GameObject.Find("right");//获取右锚点
        
        main = GameObject.FindGameObjectWithTag("MainCamera");//通过标签获取摄像机
        rigidMain = main.GetComponent<Rigidbody>();//相机的刚体

    }
    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");//左右
        float v = Input.GetAxis("Vertical");//上下
        if (Input.GetKey(leftKey))
        {
            rigid.velocity = new Vector3(moveSpeed*h,0,0);
        }
        if (Input.GetKey(rightKey))
        {
            rigid.velocity = new Vector3(moveSpeed * h, 0, 0);
        }
        if (Input.GetKey(jumpKey))
        {
            rigid.velocity = new Vector3(0,jumpSpeed*v,0);
        }
        
    }
    private void LateUpdate()
    {
      
        float smoothTime = 0.2f;
        float smoothTime2 = 60f;//起缓冲效果
        Vector3 velocity = new Vector3(0,0,-10);
        if (rigid.transform.position.x <= leftPos.transform.position.x)//当要超过左锚点的情况
        {
            main.transform.position = Vector3.SmoothDamp(main.transform.position, new Vector3(rigid.position.x, main.transform.position.y, -10), ref velocity, smoothTime);
            rigidMain.velocity = rigid.velocity;//设置相机速度与player速度相同,用以防止相机出现颠簸的情况
           
        }
        else if (rigid.position.x >= rightPos.transform.position.x)//当要超过右锚点的情况
        {
            main.transform.position = Vector3.SmoothDamp(main.transform.position, new Vector3(rigid.position.x, main.transform.position.y, -10), ref velocity, smoothTime);
            rigidMain.velocity = rigid.velocity;
        }
        else//当处于左右锚点之间的情况
        {
            main.transform.position = Vector3.SmoothDamp(main.transform.position, new Vector3(rigid.position.x, 0, -10), ref velocity, smoothTime2);
        }
       

    }
}
