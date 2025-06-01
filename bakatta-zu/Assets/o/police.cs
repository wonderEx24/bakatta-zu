using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour
{
    float Report;
    bool catchP = false;
    bool catchPC = false;
    public GameObject[] polices;
    public GameObject prison;
    private int number;
    void Start()
    {
    }
    void Update()
    {
        Report = report.count;
        // Debug.Log(Report);
        if(Report > 9.98f)
        {
            //署から出動、確率でパトカー　プレファブにする
            Instantiate(polices[number], prison.transform.position, Quaternion.identity);
            number = Random.Range(0, polices.Length);
        }
        if(catchP == true)
        {
            //手錠をかけて逮捕する
        }
    }
    void OnTrrigerStay(Collider col)
    {
        if(col.gameObject.tag == "police")
        {
            catchP = true;
        }
        if(col.gameObject.tag == "policecar")
        {
            catchPC = true;
        }
    }
}