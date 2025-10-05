using UnityEngine;

public class PhoneCameraAligner : MonoBehaviour
{
    public Camera mainCamera;     // MainCamera の参照
    public Camera phoneCamera;    // PhoneCamera の参照

    void Update()
    {
        // 毎フレーム、向きと位置を同期させる
        phoneCamera.transform.rotation = mainCamera.transform.rotation;
        // 位置も合わせたい場合はこちらも
        // phoneCamera.transform.position = mainCamera.transform.position;
    }
}
