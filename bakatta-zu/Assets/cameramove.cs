using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public GameObject player;//playerのゲームオブジェクトを入れる変数を設定
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float my = Input.GetAxis("Mouse Y");
                
        if (Mathf.Abs(my) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.right, -my);
        }

    }
}
