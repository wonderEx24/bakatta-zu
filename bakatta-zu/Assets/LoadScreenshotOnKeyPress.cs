using UnityEngine;

public class LoadScreenshotOnKeyPress : MonoBehaviour
{
    // 表示開始位置や間隔はここで調整可能
    public Vector3 startPosition = Vector3.zero;
    public float spacing = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            DisplayAllScreenshots();
        }
    }

    void DisplayAllScreenshots()
    {
        // Resources/ScreenShots フォルダから全スプライトを読み込み
        Sprite[] sprites = Resources.LoadAll<Sprite>("ScreenShots");

        if (sprites.Length == 0)
        {
            Debug.LogWarning("ScreenShotsフォルダにスプライトが見つかりません");
            return;
        }

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject go = new GameObject("Screenshot_" + i);
            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = sprites[i];

            // 横に spacing ずつずらして配置
            go.transform.position = startPosition + new Vector3(i * spacing, 0, 0);
        }

        Debug.Log(sprites.Length + "枚のスクリーンショットを表示しました");
    }
}
