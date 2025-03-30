using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class sakuteki : MonoBehaviour
{
    
    public Transform player;
    // Start is called before the first frame update
    async Task Start()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "player")
        {
            transform.LookAt(player);
            transform.Translate(0,0,0.1f);
             Debug.Log("みつけた");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}