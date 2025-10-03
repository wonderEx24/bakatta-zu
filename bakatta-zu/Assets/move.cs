using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower;
    public float mouseSensitivity = 2f; // マウス感度調整用
    public float arrowKeyRotationSpeed = 1f; // 矢印キー回転速度調整用

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Shiftキーが押されている場合
        if (Input.GetKey("left shift"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // 左回転
                this.transform.Rotate(0, -arrowKeyRotationSpeed, 0); // 矢印キー速度
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // 右回転
                this.transform.Rotate(0, arrowKeyRotationSpeed, 0); // 矢印キー速度
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // 前に移動
                this.transform.Translate(0.0f, 0.0f, 0.2f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                // 後ろに移動
                this.transform.Translate(0.0f, 0.0f, -0.2f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // 左回転（Shiftが押されていない場合も回転）
                this.transform.Rotate(0, -arrowKeyRotationSpeed/2, 0); // 矢印キー速度
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // 右回転
                this.transform.Rotate(0, arrowKeyRotationSpeed/2, 0); // 矢印キー速度
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // 前に移動
                this.transform.Translate(0.0f, 0.0f, 0.1f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                // 後ろに移動
                this.transform.Translate(0.0f, 0.0f, -0.1f);
            }
        }

        // マウス移動で回転を追加
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mx) > 0.001f)
    {
        this.transform.Rotate(0, mx * mouseSensitivity, 0); // マウス感度
    }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower);
        }
    }
}