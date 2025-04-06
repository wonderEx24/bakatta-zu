// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class police : MonoBehaviour
// {
//     int report = false;
//     public bool catchP = false;
//     public GameObject[] police;
//     public GameObject prison;
//     void Start()
//     {
//     }
//     void Update()
//     {
//         //Report = スクリプト名.変数名;
//         //通報スクリプトには"public static int 変数名"と書く
//         if(report > 10)
//         {
//             //署から出動、確率でパトカー　プレファブにする
//             Instantiate(police[which], prison.transform.position, Quaternion.identity);
//             which = random.Range(0, police.Length);
//             report = 0;
//         }
//         if(catchP == true)
//         {
//             //手錠をかけて逮捕する
//         }
//     }
//     OnCollisionEnter(collision col)
//     {
//         if(col.gameObject.tag == "Player")
//         {
//             catchP = true;
//         }
//     }
// }
