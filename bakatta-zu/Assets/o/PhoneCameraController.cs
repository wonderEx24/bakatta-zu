using UnityEngine;
using UnityEngine.UI;

public class PhoneCameraController : MonoBehaviour
{
    [Header("スマホのカメラ")]
    public Camera phoneCamera; // スマホに取り付けたカメラ
    public RenderTexture phoneRenderTexture; // スマホ画面に映す映像用

    [Header("スマホスクリーン (RawImage or MeshRenderer用)")]
    public RawImage screenImage; // UIベースのスクリーン
    // public MeshRenderer screenMeshRenderer; // 3Dモデルのスクリーン用ならこちらを使う

    private bool isCameraActive = false;

    void Start()
    {
        // 起動時はカメラオフ、スクリーン非表示
        phoneCamera.enabled = false;
        screenImage.enabled = false;

        // もしRenderTextureが指定されていればカメラに割り当て
        if (phoneRenderTexture != null)
        {
            phoneCamera.targetTexture = phoneRenderTexture;
            screenImage.texture = phoneRenderTexture;
            // screenMeshRenderer.material.mainTexture = phoneRenderTexture; // MeshRendererを使うなら
        }
    }

    // 「kamera」アプリをクリックしたときに呼ぶ関数
    public void ActivatePhoneCamera()
    {
        isCameraActive = !isCameraActive;

        phoneCamera.enabled = isCameraActive;
        screenImage.enabled = isCameraActive;

        // デバッグ用ログ
        Debug.Log("Phone Camera " + (isCameraActive ? "Activated" : "Deactivated"));
    }
}
