using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunner : MonoBehaviour
{
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("e"))
        Instantiate(gun, this.transform.position, this.transform.rotation);
    }
}
