using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListHW : MonoBehaviour
{
    public Transform content;
    public UIItemElement itemElementPrefab;

    public PlayerItems pI;

    public void InitializeItem()
    {
        

        foreach (ItemDataScriptableObject data in PlayerItemManager.instance.itemDataList)
        {
            if (data.itemName == pI.itemName)
            {
                Instantiate(itemElementPrefab, content).Setdata(data);
            }
        }
    }
}
