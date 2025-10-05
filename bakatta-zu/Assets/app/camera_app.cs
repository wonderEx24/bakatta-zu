using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camera_app : MonoBehaviour
{
    public PhoneCameraController phoneCameraController;
    public GameObject ph;
    public GameObject scree;
    public phone.usephone currentState;
    

    private void OnMouseDown()
    {
        if (phoneCameraController != null)
        {
            phoneCameraController.ActivatePhoneCamera();
        }
        ph.transform.DOLocalMove(new Vector3(0,0,0.7f), 1);
        ph.transform.DOLocalRotate(new Vector3(100,180,0), 1, RotateMode.Fast);
        scree.transform.localPosition = new Vector3(0f,1f,0f);
        currentState = phone.usephone.Recording;
    }
}
