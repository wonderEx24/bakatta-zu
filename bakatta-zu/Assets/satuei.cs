using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satuei : MonoBehaviour
{
    private bool isKeyPressed = false;  // Qキーが押されたかどうかを記録するフラグ
    public MeshRenderer targetRenderer;  // 操作対象のMeshRenderer
    private Coroutine currentCoroutine = null;  // 現在のコルーチンを管理
    public itemkirikae MonoBehaviour;  // MotimonoManagerスクリプトを参照する
    // Start is called before the first frame update
    void Start()
    {
        targetRenderer.enabled = !targetRenderer.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (MonoBehaviour.motimono == 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                isKeyPressed = false;  // フラグをリセット
            }

            // 新しいコルーチンを開始してMeshRendererを表示
            targetRenderer.enabled = !targetRenderer.enabled;  // 最初に表示
            currentCoroutine = StartCoroutine(HideMeshAfterSeconds(0.5f));
        }
    }

    IEnumerator HideMeshAfterSeconds(float seconds)
    {
        // 指定時間待機
        yield return new WaitForSeconds(seconds);

        // 0.5秒後に非表示
        targetRenderer.enabled = !targetRenderer.enabled;
        currentCoroutine = null;  // コルーチンの参照をクリア
    }
}