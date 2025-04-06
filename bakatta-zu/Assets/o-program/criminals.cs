// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class criminals : MonoBehaviour
// {
//     public bool intercom = false;
//     public bool catchY = false;
//     public GameObject robbery;
//     public GameObject office;
//     void Start()
//     {
//     }
//     void Update()
//     {
//         if(intercom == true)
//         {
//             //事務所から出てくる
//             Instantiate(robbery, office.transform.position, Quaternion.identity);
            
//         }
//         if(catchY == true)
//         {
//             //捕縛してドラム缶
//         }
//     }
//     OnCollisionEnter(collision col)
//     {
//         if(col.gameObject.tag == "Player")
//         {
//             catchY = true;
//         }
//     }
// }
