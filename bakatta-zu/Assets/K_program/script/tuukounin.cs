using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuukounin : MonoBehaviour
{
    public float tiltThreshold = 30f; // 転倒とみなす傾きの閾値（度数）
    public float recoveryDelay = 2f; // 回復までの遅延時間（秒）
    private Vector3 fallenPosition; // 転倒後の位置
    private Quaternion fallenRotation; // 転倒後の回転
    private bool isRecovering = false; // 回復中かどうかのフラグ
    private bool hasFallen = false; // 転倒したかどうかのフラグ
    private bool isRecovered = false; // 復帰したかどうかのフラグ
    private Rigidbody rb; // Rigidbodyコンポーネント
    private float timeFallen = 0f; // 転倒してから経過した時間
    private float standingRecoveryTime = 1f; // 立ち上がりの回復時間
    private float velocityThreshold = 0.5f; // 吹っ飛んでいるかどうかを判断するための速度の閾値

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 吹っ飛んでいる途中では位置を保存しない
        if (rb.velocity.magnitude < velocityThreshold && !hasFallen && !isRecovered)
        {
            // 転倒を検知する
            if (IsFallen() && !hasFallen)
            {
                hasFallen = true; // 初めて転倒を検知
                fallenPosition = transform.position; // 倒れた位置を記録
                fallenRotation = transform.rotation; // 倒れた回転を記録
                timeFallen = Time.time; // 転倒開始時間を記録
                //Debug.Log("転倒しました！");
            }
        }

        // 転倒中にのみ時間をカウントしてから回復
        if (hasFallen)
        {
            if (Time.time - timeFallen > recoveryDelay && !isRecovering)
            {
                RecoverFromRagdoll(); // 転倒から指定時間後に復帰
            }
        }
    }

    // 衝突判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("プレイヤーが衝突しました！");
        }
    }

    // 転倒したかどうかを検知
    bool IsFallen()
    {
        // キャラクターの傾きを取得（回転のXまたはZ軸の角度をチェック）
        float tiltAngleX = Mathf.Abs(transform.rotation.eulerAngles.x);
        float tiltAngleZ = Mathf.Abs(transform.rotation.eulerAngles.z);

        // 0〜180度に調整
        tiltAngleX = (tiltAngleX > 180) ? 360 - tiltAngleX : tiltAngleX;
        tiltAngleZ = (tiltAngleZ > 180) ? 360 - tiltAngleZ : tiltAngleZ;

        // 傾きが閾値を超えているか、XまたはZ軸でどちらかが転倒とみなす閾値を超えた場合
        if (tiltAngleX > tiltThreshold || tiltAngleZ > tiltThreshold)
        {
            return true;
        }

        return false;
    }

    // 起き上がる処理（倒れた位置と回転に戻す）
    void RecoverFromRagdoll()
    {
        if (isRecovering || isRecovered) return; // すでに回復中または復帰済みなら処理しない
        isRecovering = true;

        // 倒れた位置と回転に戻す
        transform.position = fallenPosition;
        transform.rotation = fallenRotation;

        // 復帰後に少し待ってから立ち上がり処理を開始
        StartCoroutine(StandUpAfterRecovery());

        // 回復が終わったらフラグを戻す
        isRecovering = false;
        isRecovered = true; // 復帰済みフラグを立てる
        hasFallen = false; // 転倒状態を解除
    }

    // 復帰後に立ち上がるための処理
    IEnumerator StandUpAfterRecovery()
    {
        // 少し待ってから立ち上がり処理を行う
        yield return new WaitForSeconds(standingRecoveryTime);

        // 立ち上がりのための処理を行う
        // ここでは簡単に立ち上がりのための位置調整や回転補正を行います
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f); // Y軸だけの回転で立つ
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z); // Y位置を0に戻す

        // 立ち上がった後、再び倒れることができるようにする
        isRecovered = false;
    }
}
