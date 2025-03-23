using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sakuteki : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }(
    void OnTriggerStay(Collider col){
        if(col.gameObject.name == "player"){
            transform.LookAt(player);
            transform.Translate(0,0,0.1f)
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("みつけた");
    }
}