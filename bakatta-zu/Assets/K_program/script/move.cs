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

    // ピンポン（チャイム）オブジェクトと距離判定の設定
    public Transform[] doorbells;  // 複数のピンポン（チャイム）の位置を配列で設定
    [Range(0.1f, 10f)] // 0.1から10の範囲で距離を設定できるようにする
    public float interactDistance = 2f;  // ピンポンに近づく距離
    public AudioClip doorbellSound;  // ピンポンの音
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // オーディオソースを取得
    }

    void Update()
    {
        // プレイヤーの足元の位置を取得（またはColliderの中心）
        Vector3 playerFeetPosition = transform.position;

        // 複数のピンポンとプレイヤーの距離をチェック
        for (int i = 0; i < doorbells.Length; i++)
        {
            // ピンポンとの距離を計算
            float distance = Vector3.Distance(playerFeetPosition, doorbells[i].position);

            // 距離がゼロに近くても、少し余裕を持って反応できるように調整
            if (distance <= interactDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    RingDoorbell(i);  // どのピンポンを鳴らすか指定する
                }
            }

            // 距離が外れた時のデバッグ
            else
            {
                //Debug.Log($"ピンポン{i + 1}までの距離: {distance}");  // 距離を表示
            }
        }

        // 移動の処理
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

    void RingDoorbell(int index)
    {
        // 音を鳴らす（音が設定されていれば）
        if (doorbellSound != null)
        {
            audioSource.PlayOneShot(doorbellSound);  // ピンポンの音を鳴らす
        }
        Debug.Log($"ピンポン{index + 1}が鳴りました！");
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
