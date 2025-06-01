using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class report : MonoBehaviour
{
    public static float count;
    // bool intercom;
    // Start is called before the first frame update
    void Start()
    {
        // intercom = move.isActioning;
    }

    // Update is called once per frame
    void Update()
    {
        //バカ行為カウント
        // if(intercom == true)
        // {
        //     count = count + 2;
        // }
        count += Time.deltaTime;
        if(count > 10)
        {
            count -= 10;
        }
    }
}
