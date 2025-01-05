using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower = 5f;
    public float mouseSensitivity = 2f; // マウス感度調整用
    public float keyMovementSpeed = 0.2f; // 移動速度調整用
    private bool isGrounded = false; // 地面に接触しているか

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? keyMovementSpeed * 2 : keyMovementSpeed;

        if (Input.GetKey(KeyCode.A)) this.transform.Translate(-movementSpeed, 0.0f, 0.0f); // 左に移動
        if (Input.GetKey(KeyCode.D)) this.transform.Translate(movementSpeed, 0.0f, 0.0f); // 右に移動
        if (Input.GetKey(KeyCode.W)) this.transform.Translate(0.0f, 0.0f, movementSpeed); // 前に移動
        if (Input.GetKey(KeyCode.S)) this.transform.Translate(0.0f, 0.0f, -movementSpeed); // 後ろに移動

        float mx = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mx) > 0.001f) this.transform.Rotate(0, mx * mouseSensitivity, 0);

        // スペースキーでジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            isGrounded = false; // ジャンプしたら接地をリセット
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 地面に触れている間
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // 地面から離れたとき
        }
    }
}