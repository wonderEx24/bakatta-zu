using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class phone : MonoBehaviour
{
    public static bool usephone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(usephone == false)
        {
            if(Input.GetKeyDown("tab"))
            {
                Debug.Log("usephone");
                this.transform.DOLocalMove(new Vector3(0,0,0.4f), 1);
                this.transform.DORotate(new Vector3(90,180,0), 1, RotateMode.Fast);
                Invoke("Fals",0.1f);
            }
        }
        if(usephone == true)
        {
            if(Input.GetKeyDown("tab"))
            {
                Debug.Log("notuse");
                this.transform.DOLocalMove(new Vector3(0.3f,-1.3f,-0.3f), 1);
                this.transform.DORotate(new Vector3(120,-45,120), 1, RotateMode.Fast);
                Invoke("Tru",0.1f);
            }
        }
    }
    void Fals()
    {
        usephone = true;
    }
    void Tru()
    {
        usephone = false;
    }
}
