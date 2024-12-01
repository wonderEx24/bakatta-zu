using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public float rotationSpeed = 5f;  // 回転速度
    public float verticalAngleLimit = 80f; // 上下回転の角度制限（度）

    private float yaw = 0f; // 水平回転角度
    private float pitch = 0f; // 垂直回転角度

    void Start()
    {
        // カメラの初期角度を取得
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        // マウスの移動量を取得
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // 水平回転（Y軸）
        yaw += mx * rotationSpeed;

        // 垂直回転（X軸）、角度制限を適用
        pitch -= my * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -verticalAngleLimit, verticalAngleLimit);

        // カメラの回転を計算
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0); // Z軸回転をゼロに固定
        transform.position = player.transform.position; // カメラをプレイヤーの位置に設定
        transform.rotation = rotation;

        // カメラをプレイヤーから一定距離後方に配置
        Vector3 offset = new Vector3(0, 0, -5f); // 適当な距離を指定
        transform.position += rotation * offset;
    }
}