using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criminals : MonoBehaviour
{
    bool Intercom;
    bool catchY = false;
    public GameObject robbery;
    public GameObject office;
    void Start()
    {
    }
    void Update()
    {
        // Intercom = intercom.push;
        // Debug.Log(Intercom);
        if(Intercom == true)
        {
            //事務所から出てくる
            Instantiate(robbery, office.transform.position, Quaternion.identity);
            // robbery.transform.position = office.transform.position;
            Intercom = false;
        }
        if(catchY == true)
        {
            //捕縛してドラム缶
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "criminals")
        {
            catchY = true;
        }
        if(col.gameObject.tag == "Player")
        {
            Intercom = true;
        }
    }
}
