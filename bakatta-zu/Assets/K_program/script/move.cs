using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower = 5f;
    public float mouseSensitivity = 2f;
    public float keyMovementSpeed = 0.2f;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? keyMovementSpeed * 2 : keyMovementSpeed;

        if (Input.GetKey(KeyCode.A)) transform.Translate(-movementSpeed, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.D)) transform.Translate(movementSpeed, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W)) transform.Translate(0.0f, 0.0f, movementSpeed);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0.0f, 0.0f, -movementSpeed);

        float mx = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mx) > 0.001f) transform.Rotate(0, mx * mouseSensitivity, 0);

        // ジャンプ処理
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // 接触面の法線が上向き（45°以内）か確認
                if (Vector3.Angle(contact.normal, Vector3.up) < 45f)
                {
                    isGrounded = true;
                    return; // 1つでも上向きの面があれば地面判定
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}