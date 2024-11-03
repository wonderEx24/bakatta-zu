using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("left shift"))
        {
            if (Input.GetKey (KeyCode.LeftArrow))
            {
            this.transform.Translate (-0.2f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.RightArrow))
            {
            this.transform.Translate (0.2f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.UpArrow))
            {
            this.transform.Translate (0.0f,0.0f,0.2f);
            }
            if (Input.GetKey (KeyCode.DownArrow))
            {
            this.transform.Translate (0.0f,0.0f,-0.2f);
            }
        
            else
            {
            if (Input.GetKey (KeyCode.LeftArrow))
    　　　　　{
            this.transform.Translate (-0.1f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.RightArrow))
            {
            this.transform.Translate (0.1f,0.0f,0.0f);
            }
            if (Input.GetKey (KeyCode.UpArrow))
            {
            this.transform.Translate (0.0f,0.0f,0.1f);
            }
            if (Input.GetKey (KeyCode.DownArrow))
            {
            this.transform.Translate (0.0f,0.0f,-0.1f);
            }
            }
        }
    }
}
