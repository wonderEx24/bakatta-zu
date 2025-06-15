using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject playerObject;
    public float rotateSpeed = 2.0f;
    private Vector3 offset;
    public Transform myTransform;
    bool canmove = phone.usephone;

    //呼び出し時に実行される関数
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerObject = GameObject.Find("player");
        // MainCamera(自分自身)とplayerとの相対距離を求める
        // offset = mainCamera.transform.position - playerObject.transform.position;
        myTransform = mainCamera.transform;
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        Debug.Log(canmove);
        //rotateCameraの呼び出し
        rotateCamera();
        //新しいトランスフォームの値を代入する
        // mainCamera.transform.position = playerObject.transform.position + offset;
        if(Input.anyKey)
        {
            if(!Input.GetKey("a") && !Input.GetKey("d"))
            {
                Vector3 localAngle = myTransform.localEulerAngles;
                float localangle_y = localAngle.y;
                Quaternion rotation = Quaternion.Euler(0, localangle_y, 0);
                playerObject.transform.rotation = Quaternion.Euler(0, localangle_y, 0);
                // playerObject.transform.rotation = mainCamera.transform.rotation;
            }
        }
        // if(Input.anyKeyDown)
        // {
        //     Transform myTransform = mainCamera.transform.eulerAngles.y;
        //     mainCamera.transform.Rotate( 0, myTransform, 0);
        // }
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        if(canmove == false)
        {
            if(!Input.anyKey)
            {
                //Vector3でX,Y方向の回転の度合いを定義
                Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,Input.GetAxis("Mouse Y") * rotateSpeed, 0);
                //transform.RotateAround()をしようしてメインカメラを回転させる
                mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
                mainCamera.transform.RotateAround(playerObject.transform.position, -transform.right, angle.y);
            }
            else
            {
                Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,Input.GetAxis("Mouse Y") * rotateSpeed, 0);
                mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
                // mainCamera.transform.RotateAround(playerObject.transform.position, -transform.right, angle.y);
            }
        }
        else
        {
        }
    }
}
