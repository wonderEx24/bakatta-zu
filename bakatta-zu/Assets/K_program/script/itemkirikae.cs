using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemkirikae : MonoBehaviour
{
    public GameObject[] items;  // 持つアイテムを格納する配列
    public int motimono;
    public GameObject bulletPrefab;  // 弾のPrefab
    public Transform firePoint;  // 弾を発射する位置（例えば水鉄砲の先端）
    public float fireRate = 0.2f; // 連射の間隔（秒）
    private float nextFireTime = 0f; // 次に撃てる時間

    void Start()
    {
        motimono = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) motimono = 1; // スマホ持つ
        if (Input.GetKeyDown(KeyCode.Alpha2)) motimono = 2; // たら（ば）こ持つ
        if (Input.GetKeyDown(KeyCode.Alpha3)) motimono = 3; // 爪楊枝（？？？）持つ
        if (Input.GetKeyDown(KeyCode.Alpha4)) motimono = 4; // 花火持つ
        if (Input.GetKeyDown(KeyCode.Alpha5)) motimono = 5; // 除草剤持つ
        if (Input.GetKeyDown(KeyCode.Alpha6)) motimono = 6; // 虫持つ
        if (Input.GetKeyDown(KeyCode.Alpha7)) motimono = 7; // 水鉄砲持つ
        if (Input.GetKeyDown(KeyCode.Alpha8)) motimono = 8; // ハンマー（ピコピコ？）持つ
        if (Input.GetKeyDown(KeyCode.Alpha9)) motimono = 9; // カエンタケ（？？？）持つ
        if (Input.GetKeyDown(KeyCode.Alpha0)) motimono = 10; // 指（？？？？？）持つ

        // アイテムを切り替え
        ChangeItem();

        // **水鉄砲を持っていて、左クリックが押されている & 連射間隔を満たしたら発射**
        if (motimono == 7 && Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // 次に撃てる時間を更新
            ShootWaterGun();
        }
    }

    void ChangeItem()
    {
        foreach (GameObject item in items) item.SetActive(false);

        if (motimono > 0 && motimono <= items.Length)
        {
            items[motimono - 1].SetActive(true);
        }
    }

    void ShootWaterGun()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(firePoint.forward * 20f, ForceMode.VelocityChange);
            }

            Collider bulletCollider = bullet.GetComponent<Collider>();
            if (bulletCollider != null)
            {
                foreach (GameObject existingBullet in GameObject.FindGameObjectsWithTag("Bullet"))
                {
                    Collider existingCollider = existingBullet.GetComponent<Collider>();
                    if (existingCollider != null)
                    {
                        Physics.IgnoreCollision(bulletCollider, existingCollider);
                    }
                }
            }

            bullet.tag = "Bullet"; 
            Destroy(bullet, 5f);
        }
    }
}