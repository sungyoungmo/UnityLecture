using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public RectTransform equipPage;
    public RectTransform inventoryContent;

    public int inventorySlotCount;
    public InventorySLot inventorySlotPrefab;
    private List<InventorySLot> inventorySLots = new();

    [Space(20)]
    public InventorySLot focusedSlot;
    public InventorySLot selectedSlot;

    public List<Weapon> tempWeapons;
    public List<Item2> tempItems;

    private void Start()
    {

        // tempItems ����Ʈ�� tempWeapons ��ҵ��� 0�� �ε������� ����
        tempItems.InsertRange(0, tempWeapons);

        for (int i = 0; i < tempItems.Count; i++)
        {
            // �ӽ� �������� inventory content ���� ���Կ� �Ѱ��� �Ҵ�.
            inventoryContent.GetChild(i).GetComponent<InventorySLot>().Item = tempItems[i];
        }
    }
}

[Serializable]
public class Item2
{
    public Sprite iconSprite;
    public string name;
    public string desc;
}

[Serializable]
public class Weapon : Item2
{
    public float damage;
    public GameObject equipPrefab;
}