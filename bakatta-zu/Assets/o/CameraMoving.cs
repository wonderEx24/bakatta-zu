using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
        
    }
}
