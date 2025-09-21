using UnityEngine;
using System.Collections.Generic;

public class ScreenshotLoader : MonoBehaviour
{
    // 撮影したスクリーンショットのファイル名を格納するリスト
    private List<string> screenshotFileNames = new List<string>();

    void Start()
    {
        // 例として、最後に撮影したスクリーンショットをロード
        LoadLatestScreenshot();
    }

    // 最新のスクリーンショットをロードするメソッド
    void LoadLatestScreenshot()
    {
        // リストにファイル名があれば最後のアイテムを取得
        if (screenshotFileNames.Count > 0)
        {
            string latestScreenshotName = screenshotFileNames[screenshotFileNames.Count - 1];

            // ファイル名があれば、それを元にリソースからロード
            Texture2D screenshotTexture = Resources.Load<Texture2D>("ScreenShots/" + latestScreenshotName);

            if (screenshotTexture != null)
            {
                Debug.Log("最新のスクリーンショットをロードしました！");
                // ここで画像をUIなどに表示する処理を追加
            }
            else
            {
                Debug.LogError("スクリーンショットの読み込みに失敗しました。");
            }
        }
        else
        {
            Debug.LogError("スクリーンショットのファイル名リストが空です。");
        }
    }

    // スクリーンショットが撮影された際に呼ばれる
    public void OnScreenshotTaken(string fileName)
    {
        // 撮影されたファイル名をリストに追加
        screenshotFileNames.Add(fileName);

        Debug.Log("撮影されたスクリーンショット: " + fileName);
    }
}