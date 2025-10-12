using UnityEngine;
using UnityEngine.UI;

public class LoadScreenshotOnKeyPress : MonoBehaviour
{
    public Canvas canvas; // ← 上司の指示により、ここにCanvasを指定して使う
    public Vector2 startPosition = Vector2.zero;
    public float spacing = 200f; // UI上の間隔(px)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            DisplayAllScreenshots();
        }
    }

    void DisplayAllScreenshots()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("ScreenShots");

        if (sprites.Length == 0)
        {
            Debug.LogWarning("ScreenShotsフォルダにスプライトが見つかりません");
            return;
        }

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject go = new GameObject("ScreenshotUI_" + i);
            go.transform.SetParent(canvas.transform, false); // ← Canvasの子に設定

            Image image = go.AddComponent<Image>();
            image.sprite = sprites[i];
            image.SetNativeSize(); // 元画像サイズで表示

            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = startPosition + new Vector2(i * spacing, 0);
        }

        Debug.Log(sprites.Length + "枚のスクリーンショットをCanvasに表示しました");
    }
}