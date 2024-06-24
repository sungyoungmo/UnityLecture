using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemElement : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damageText;

    private ItemDataScriptableObject data;

    public void Setdata(ItemDataScriptableObject data)
    {
        this.data = data;
        // currency element 가 생성되고 나서 호출될 초기화 함수.

        iconImage.sprite = data.iconSprite; // 아이콘 교체
        nameText.text = data.itemName;  // 이름 변경


        int currentCount = PlayerItemManager.instance.itemDataHW[data.itemDataType];

        damageText.text = $"Damage: {data.damage.ToString()}";

    }

}
