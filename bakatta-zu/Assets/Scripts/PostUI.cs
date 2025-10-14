using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PostUI : MonoBehaviour {
    public TMP_InputField userNameInput;
    public TMP_InputField messageInput;
    public Image imagePreview;
    public PostManager postManager;

    private Sprite selectedImage; // 選択した画像

    // 投稿ボタンを押した時
    public void OnSubmitPost() {
        string userName = userNameInput.text;
        string message = messageInput.text;

        if (string.IsNullOrEmpty(message)) {
            Debug.Log("メッセージが空です！");
            return;
        }

        postManager.CreatePost(userName, message, selectedImage);

        // 入力欄をクリア
        userNameInput.text = "";
        messageInput.text = "";
        imagePreview.sprite = null;
        selectedImage = null;
    }

    // 仮：画像選択（スクショやリソースから選ぶ処理を後で追加）
    public void OnSelectImage(Sprite sprite) {
        selectedImage = sprite;
        imagePreview.sprite = sprite;
    }
}
