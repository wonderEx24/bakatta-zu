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
                this.transform.DOMove(new Vector3(0,-6,-5.6f), 1).SetRelative(true);
                Invoke("Fals",0.1f);
            }
        }
        if(usephone == true)
        {
            if(Input.GetKeyDown("tab"))
            {
                Debug.Log("notuse");
                this.transform.DOMove(new Vector3(0,6,5.6f), 1).SetRelative(true);
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
