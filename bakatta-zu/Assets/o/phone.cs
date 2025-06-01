using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class phone : MonoBehaviour
{
    public bool usephone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            if(usephone == false)
            {
                this.transform.DOMove(new Vector3(0,-6,-5.6f), 1).SetRelative(true);
                usephone = true;
            }
        }
        if(Input.GetKeyDown("tab"))
        {
            if(usephone == true)
            {
                this.transform.DOMove(new Vector3(0,6,5.6f), 1).SetRelative(true);
                usephone = false;
            }
        }
    }
}
