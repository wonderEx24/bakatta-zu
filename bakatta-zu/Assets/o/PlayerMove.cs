using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb; //リジッドボディを取得するための変数
    public float upForce = 200f; //上方向にかける力
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //リジッドボディを取得
    }
    void Update()
    {
                if (Input.GetKey("d"))
                {
                    transform.Rotate(0, 3, 0);
                }
                if (Input.GetKey("a"))
                {
                    transform.Rotate(0, -3, 0);
                }
                if (Input.GetKey("w"))
                {
                    transform.position += transform.forward * 0.05f;
                }
                if (Input.GetKey("s"))
                {
                    transform.position -= transform.forward * 0.03f;
                }
                if (Input.GetKey("left shift"))
                {
                        transform.position += transform.forward * 0.1f;
                }
    }
    void OnCollisionStay(Collision qaz)
    {
        if(qaz.gameObject.tag == "Ground")
        {
            
            if(Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0, upForce = 200, 0)); //上に向かって力を加える
            }
        }
    }
}