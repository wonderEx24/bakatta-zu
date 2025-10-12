using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeLinePost : MonoBehaviour
{
    public string userName;
    public string text;
    public Sprite image; 
    public System.DateTime time;
}


public class TimeLineManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject postPrefab;       // 投稿プレハブ（PostPrefab）
    public Transform contentParent;     // ScrollViewのContentを指定

    private List<TimelinePost> posts = new List<TimelinePost>();

    void Start()
    {
        // テスト投稿を追加して表示
        AddPost("UserA", "こんにちは！Unityでタイムラインを作ってます。");
        AddPost("UserB", "画像投稿もできるようにしました。", Resources.Load<Sprite>("sample_image"));
        DisplayPosts();
    }

    /// <summary>
    /// 投稿をリストに追加（新しいものを上に表示）
    /// </summary>
    public void AddPost(string userName, string text, Sprite image = null)
    {
        posts.Insert(0, new TimelinePost
        {
            userName = userName,
            text = text,
            image = image,
            time = System.DateTime.Now
        });
    }

    /// <summary>
    /// 投稿をUIに反映
    /// </summary>
    public void DisplayPosts()
    {
        // 古い投稿UIを削除
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        // 投稿を上から順に生成
        foreach (var post in posts)
        {
            var obj = Instantiate(postPrefab, contentParent);

            obj.transform.Find("UserName").GetComponent<TextMeshProUGUI>().text = post.userName;
            obj.transform.Find("PostText").GetComponent<TextMeshProUGUI>().text = post.text;

            var imgObj = obj.transform.Find("PostImage").GetComponent<Image>();
            if (post.image != null)
            {
                imgObj.sprite = post.image;
                imgObj.gameObject.SetActive(true);
            }
            else
            {
                imgObj.gameObject.SetActive(false);
            }
        }
    }
}
