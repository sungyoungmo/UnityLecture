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
        // currency element �� �����ǰ� ���� ȣ��� �ʱ�ȭ �Լ�.

        iconImage.sprite = data.iconSprite; // ������ ��ü
        nameText.text = data.itemName;  // �̸� ����


        int currentCount = PlayerItemManager.instance.itemDataHW[data.itemDataType];

        damageText.text = $"Damage: {data.damage.ToString()}";

    }

}
