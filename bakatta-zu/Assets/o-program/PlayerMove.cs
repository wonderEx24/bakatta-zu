using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // private Quaternion rot;
    private Rigidbody rb; //リジッドボディを取得するための変数
    public float upForce = 200f; //上方向にかける力
    // public GameObject gun;
    // bool spead = false;
    // public change_player change1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //リジッドボディを取得
    }
    // Update is called once per frame
    void Update()
    {
        // rot = transform.rotation;
        // float X_Rotation = Input.GetAxis("Mouse X");
        // float Y_Rotation = Input.GetAxis("Mouse Y");
        // Screen.lockCursor = true;
        // Cursor.visible = false;
        // if(change1.change1 == 4)
        // {
        // }
        // else
        // {
            // if (Input.GetKey("f"))
            // {
            //     // 構えるとしゃがみ込み(右足下で左足上)、<この時は照準を覗き込む>。<構えながら移動する時は腰撃ちになり>、<randumを使って球ぶれを起こす>。<視点と銃をリンクさせる。>、
            //     if (Input.GetKey("d"))
            //     {
            //         transform.position += transform.right * 0.05f;
            //     }
            //     if (Input.GetKey("a"))
            //     {
            //         transform.position -= transform.right * 0.05f;
            //     }
            //     if (Input.GetKey("w"))
            //     {
            //         transform.position += transform.forward * 0.075f;
            //         if(spead == true)
            //         {
            //             transform.position += transform.forward * 0.05f;
            //         }
            //     }
            //     if (Input.GetKey("s"))
            //     {
            //         transform.position -= transform.forward * 0.05f;
            //         if(spead == true)
            //         {
            //             transform.position -= transform.forward * 0.03f;
            //         }
            //     }
            // }
            // else
            // {
                if (Input.GetKey("d"))
                {
                    transform.Rotate(0, 3, 0);
                }
                if (Input.GetKey("a"))
                {
                    transform.Rotate(0, -3, 0);
                }
                if (Input.GetKey("w"))
                {
                    transform.position += transform.forward * 0.05f;
                    // if(spead == true)
                    // {
                    //     transform.position += transform.forward * 0.13f;
                    // }
                }
                // if (Input.GetKeyDown("w"))
                // {
                //     gun.transform.DOLocalMove(new Vector3(-0.2f, 0.05f, -0.12f), 0.7f);
                //     gun.transform.DOLocalRotate(new Vector3(0, -90, 0), 0.7f, RotateMode.Fast);
                // }
                if (Input.GetKey("s"))
                {
                    transform.position -= transform.forward * 0.03f;
                    // if(spead == true)
                    // {
                    //     transform.position -= transform.forward * 0.08f;
                    // }
                }
                if (Input.GetKey("left shift"))
                {
                    // if(spead == true)
                    // {
                        transform.position += transform.forward * 0.1f;
                    // }
                }
    }
        // if ((rot.x < 20f)&&(rot.x > -20f))
        // {
        //     // camera.transform.Rotate(new Vector3(0, Y_Rotation * 4, 0));
        //     transform.Rotate(0,X_Rotation,Y_Rotation);
        //     // matome.transform.Rotate(-Y_Rotation, X_Rotation, 0);
        // }
        // else
        // {
        //     transform.Rotate(0,-X_Rotation,-Y_Rotation);
        //     // matome.transform.Rotate(Y_Rotation, -X_Rotation, 0);
        // }
        // if (Input.GetKeyDown("c"))
        // {
        //     transform.rotation = this.transform.rotation;
        // }
    // }
    void OnCollisionStay(Collision qaz)
    {
        if(qaz.gameObject.tag == "Ground")
        {
            
            if(Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0, upForce = 200, 0)); //上に向かって力を加える
            }
        }
    }
    // void OnTriggerEnter(Collider spe)
    // {
    //     if(spe.gameObject.tag == "spead")
    //     {
    //         Debug.Log("true!!");
    //         spead = true;
    //     }
    // }
}