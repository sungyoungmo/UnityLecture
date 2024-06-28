using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDirectory : MonoBehaviour
{
    public Sprite[] ItemList;
    public Transform PanelParent;

    private void Start()
    {
        foreach (var item in ItemList)
        {
            GameObject child = new GameObject("Item");
            child.transform.SetParent(PanelParent, false);

            // RectTransform ¼³Á¤
            RectTransform rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100);

            Image image = child.AddComponent<Image>();
            image.sprite = item;
        }
    }
}
