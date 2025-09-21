using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Post {
    public string userName;
    public string message;
    public Sprite image;
    public System.DateTime time;
}

public class PostManager : MonoBehaviour {
    public Transform contentParent; // ScrollViewのContent
    public GameObject postPrefab;   // 投稿カードのPrefab
    private List<Post> posts = new List<Post>();

    public void CreatePost(string userName, string message, Sprite image = null) {
        Post newPost = new Post {
            userName = userName,
            message = message,
            image = image,
            time = System.DateTime.Now
        };

        posts.Insert(0, newPost); // 上に追加
        UpdateTimeline();
    }

    void UpdateTimeline() {
        foreach (Transform child in contentParent) {
            Destroy(child.gameObject);
        }

        foreach (var post in posts) {
            GameObject obj = Instantiate(postPrefab, contentParent);
            obj.transform.Find("UserName").GetComponent<TextMeshProUGUI>().text = post.userName;
            obj.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = post.message;
            obj.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = post.time.ToString("HH:mm");
            if (post.image != null) {
                obj.transform.Find("Image").GetComponent<Image>().sprite = post.image;
            } else {
                obj.transform.Find("Image").gameObject.SetActive(false);
            }
        }
    }
}

