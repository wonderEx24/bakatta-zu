using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resulting : MonoBehaviour
{
    public float Score;
    public float iine;
    public float retuiit;
    public TextMeshProUGUI result;
    public TextMeshProUGUI iineresult;
    public TextMeshProUGUI returesult;
    // Start is called before the first frame update
    public float Scorenow;

    public float wait2;
    public float wait;
    public float iinenow;
    public float retuiitnow;
    void Start()
    {
        wait2 = 0;
        wait = 0;
        Scorenow = 0;
        iinenow = 0;
        retuiitnow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Scorenow < Score)
        {
            Scorenow = Scorenow + Time.deltaTime * 1000;
        }
        else
        {
            wait = wait + Time.deltaTime * 1000;
            Scorenow = Score;
        }
        result.text = "Score:" + Scorenow.ToString("f0");

        if (wait > 500)
        {
            if (iinenow < iine)
            {
                iinenow = iinenow + Time.deltaTime * 100;
            }
            else
            {
                iinenow = iine;
                wait2 = wait2 + Time.deltaTime * 1000;
            }
            iineresult.text = "いいね！:" + iinenow.ToString("f0");
        }

        if (wait2 > 500)
        {
            

            if (retuiitnow < retuiit)
            {
                retuiitnow = retuiitnow + Time.deltaTime * 100;

            }
            else
            {
                retuiitnow = retuiit;
            }
            returesult.text = "いいね！:" + retuiitnow.ToString("f0");
        }


    }



}

