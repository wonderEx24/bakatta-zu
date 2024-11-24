using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemkirikae : MonoBehaviour
{
    public GameObject[] items;  // 持つアイテムを格納する配列
    public int motimono;
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
            motimono = 1;//スマホ持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            motimono = 2;//たら（ば）こ持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            motimono = 3;//爪楊枝（？？？）持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            motimono = 4;//花火持つ
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            motimono = 5;//除草剤持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            motimono = 6;//虫持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            motimono = 7;//水鉄砲持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            motimono = 8;//ハンマー（ピコピコ？）持つ
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            motimono = 9;//カエンタケ（？？？）持つ
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            motimono = 10;//指（？？？？？）持つ（何も持ってないっていう解釈でよろしい？）
        }
        ChangeItem();
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
}
