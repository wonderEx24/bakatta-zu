using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class phone : MonoBehaviour
{
    public enum usephone
    {use, notuse, Recording}
    public usephone currentState = usephone.notuse;  // 初期状態
    public GameObject came;
    private bool isRotating = false;
    private float rotationDuration = 1f; // 回転にかける時間（秒）
    private float elapsedTime = 0f;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == phone.usephone.notuse || currentState == phone.usephone.Recording)
        {
            if(Input.GetKeyDown("tab"))
            {
                // Debug.Log("usephone");
                this.transform.DOLocalMove(new Vector3(0.1f,-0.3f,0.8f), 1);
                this.transform.DOLocalRotate(new Vector3(95,0,175), 1, RotateMode.Fast);
                // Vector3 worldAngle = came.transform.eulerAngles.y;
                // came.transform.DORotate(new Vector3(10,0,0),1, RotateMode.Fast);

                startRotation = came.transform.rotation;
                // 現在の回転を基に、X軸を20度にしたターゲット回転を作成
                Vector3 currentEuler = came.transform.eulerAngles;
                Vector3 targetEuler = new Vector3(10f, currentEuler.y, currentEuler.z);
                targetRotation = Quaternion.Euler(targetEuler);
                elapsedTime = 0f;
                isRotating = true;
                Invoke("Fals",0.1f);
            }
        }
        if(currentState == phone.usephone.use)
        {
            if(Input.GetKeyDown("tab"))
            {
                // Debug.Log("notuse");
                this.transform.DOLocalMove(new Vector3(0.3f,-1.3f,-0.3f), 1);
                this.transform.DOLocalRotate(new Vector3(245,-60,135), 1, RotateMode.Fast);
                // came.transform.DORotate(new Vector3(-10,0,0),1, RotateMode.Fast);

                startRotation = came.transform.rotation;
                // 現在の回転を基に、X軸を20度にしたターゲット回転を作成
                Vector3 currentEuler = came.transform.eulerAngles;
                Vector3 targetEuler = new Vector3(0f, currentEuler.y, currentEuler.z);
                targetRotation = Quaternion.Euler(targetEuler);
                elapsedTime = 0f;
                isRotating = true;
                Invoke("Tru",0.1f);
            }
        }
        // 回転中の処理
        if (isRotating)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            // 回転を補間して適用
            came.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            // 回転完了したら終了
            if (t >= 1f)
            {
                isRotating = false;
            }
        }
    }
    void Fals()
    {
        currentState = usephone.use;
    }
    void Tru()
    {
        currentState = usephone.notuse;
    }
}
