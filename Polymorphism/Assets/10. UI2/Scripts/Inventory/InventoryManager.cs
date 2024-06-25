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

        // tempItems 리스트에 tempWeapons 요소들을 0번 인덱스부터 삽입
        tempItems.InsertRange(0, tempWeapons);

        for (int i = 0; i < tempItems.Count; i++)
        {
            // 임시 아이템을 inventory content 내의 슬롯에 한개씩 할당.
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