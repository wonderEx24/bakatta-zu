using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemkirikae : MonoBehaviour
{
    public GameObject[] items;  // 持つアイテムを格納する配列
    public int motimono;
    public GameObject bulletPrefab;  // 弾のPrefab
    public Transform firePoint;  // 弾を発射する位置（例えば水鉄砲の先端）

    // Start is called before the first frame update
    void Start()
    {
        motimono = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            motimono = 1; // スマホ持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            motimono = 2; // たら（ば）こ持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            motimono = 3; // 爪楊枝（？？？）持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            motimono = 4; // 花火持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            motimono = 5; // 除草剤持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            motimono = 6; // 虫持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            motimono = 7; // 水鉄砲持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            motimono = 8; // ハンマー（ピコピコ？）持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            motimono = 9; // カエンタケ（？？？）持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            motimono = 10; // 指（？？？？？）持つ（何も持ってないっていう解釈でよろしい？）
        }

        // アイテムを切り替え
        ChangeItem();

        // 水鉄砲を撃つ
        if (motimono == 7 && Input.GetMouseButtonDown(0)) // 水鉄砲を持っていてマウスの左クリック
        {
            ShootWaterGun();
        }
    }

    void ChangeItem()
    {
        // アイテムを非表示に
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }

        // motimonoに対応したアイテムを表示
        if (motimono > 0 && motimono <= items.Length)
        {
            items[motimono - 1].SetActive(true);  // motimonoに応じてアイテムを表示
        }
    }

    // 水鉄砲を撃つ処理
    void ShootWaterGun()
    {
        // 弾を発射
        if (bulletPrefab != null && firePoint != null)
        {
            // 弾を発射位置からインスタンス化
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 弾に Rigidbody を取得して力を加える
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // 発射方向に力を加える
                rb.AddForce(firePoint.forward * 20f, ForceMode.VelocityChange);  // 発射方向に力を加える
            }

            // 一定時間後に弾を削除
            Destroy(bullet, 5f);  // 5秒後に弾を削除
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーでないかをチェック
        if (collision.gameObject.CompareTag("Player2"))  // プレイヤーには衝突しない
        {
            return;  // プレイヤーに当たった場合は処理を行わない
        }

        // プレイヤー以外のオブジェクトには反応
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            // 敵にダメージを与えるなどの処理
        }

        // 衝突したら弾を削除
        Destroy(gameObject);
    }
}