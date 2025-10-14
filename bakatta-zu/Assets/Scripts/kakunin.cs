using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakunin : MonoBehaviour
{
   [SerializeField] GameObject prefab;
      void Start()
      {
         foreach (Sprite s in Resources.LoadAll<Sprite>("ScreenShots"))
         {
            GameObject obj = Instantiate(prefab);
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = s;
         }
      }
}