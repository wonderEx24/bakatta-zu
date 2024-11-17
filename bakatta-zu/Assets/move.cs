using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("left shift"))
        {
            if (Input.GetKey (KeyCode.LeftArrow))
            {
            this.transform.Translate (-0.2f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.RightArrow))
            {
            this.transform.Translate (0.2f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.UpArrow))
            {
            this.transform.Translate (0.0f,0.0f,0.2f);
            }
            if (Input.GetKey (KeyCode.DownArrow))
            {
            this.transform.Translate (0.0f,0.0f,-0.2f);
            }
        }
            else
        {
            if (Input.GetKey (KeyCode.LeftArrow))
            {
            this.transform.Translate (-0.1f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.RightArrow))
            {
            this.transform.Translate (0.1f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.UpArrow))
            {
            this.transform.Translate (0.0f,0.0f,0.1f);
            }
            if (Input.GetKey (KeyCode.DownArrow))
            {
            this.transform.Translate (0.0f,0.0f,-0.1f);
            }
        }
        {
            float mx = Input.GetAxis("Mouse X");//カーソルの横の移動量を取得
            float my = Input.GetAxis("Mouse Y");//カーソルの縦の移動量を取得
            if (Mathf.Abs(mx) > 0.001f);
        } // X方向に一定量移動していれば横回転
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKey (KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower);
        }
    }
}