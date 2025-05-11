using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class phone : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("tab"))
        {
            camera.transform.DOMove(new Vector3(0,-2,5), 1).SetRelative(true);
            this.transform.DOMove(new Vector3(0,5,0), 1).SetRelative(true);
        }
    }
}
