using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
                
        if (Mathf.Abs(my) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.right, -my);
        }
        if (Mathf.Abs(mx) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

    }
}
