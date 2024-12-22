using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower;
    public float mouseSensitivity = 2f; // マウス感度調整用
    public float keyMovementSpeed = 0.2f; // 移動速度調整用

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? keyMovementSpeed * 2 : keyMovementSpeed;

        // 左右移動 (A, Dキー)
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-movementSpeed, 0.0f, 0.0f); // 左に移動
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(movementSpeed, 0.0f, 0.0f); // 右に移動
        }

        // 前後移動 (W, Sキー)
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, movementSpeed); // 前に移動
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -movementSpeed); // 後ろに移動
        }

        // マウス移動で回転を追加
        float mx = Input.GetAxis("Mouse X");

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