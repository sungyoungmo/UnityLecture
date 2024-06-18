using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeForButton
{
    weapon,
    etc,
    equipment,
    consumeItem
}

public class ItemButton : MonoBehaviour
{
    GameItemManager gameitem;

    List<GameObject> inventory;

    public Transform transParent;

    private void Start()
    {
        gameitem = GameItemManager.instance;
    }

    void onButton(ItemTypeForButton itfb)
    {
        List<GameObject> GOList;
        gammaRollBack();

        switch (itfb)
        {
            case ItemTypeForButton.weapon:
                GOList = gameitem.ItemList.FindAll
                (
                    delegate (GameObject item)
                    {
                        return item.GetComponent<Item>().t1 == TypeOne.weapon;
                    }
                );
                break;
            case ItemTypeForButton.etc:
                GOList = gameitem.ItemList.FindAll
                (
                    delegate (GameObject item)
                    {
                        return item.GetComponent<Item>().t1 == TypeOne.ect;
                    }
                );
                break;
            case ItemTypeForButton.equipment:
                GOList = gameitem.ItemList.FindAll
                (
                    delegate (GameObject item)
                    {
                        return item.GetComponent<Item>().t2 == TypeTwo.equipment;
                    }
                );
                break;
            case ItemTypeForButton.consumeItem:
                GOList = gameitem.ItemList.FindAll
                (
                    delegate (GameObject item)
                    {
                        return item.GetComponent<Item>().t2 == TypeTwo.consumeItem;
                    }
                );
                break;
            default:
                GOList = null;
                break;
        }

        foreach (var item in GOList)
        {
            Color nowColor = item.GetComponent<Renderer>().material.color;
            nowColor.a = 1.0f;
            item.GetComponent<Renderer>().material.color = nowColor;
        }
    }

    void gammaRollBack()
    {
        foreach (var item in gameitem.ItemList)
        {
            Color nowColor = item.GetComponent<Renderer>().material.color;
            nowColor.a = 0.5f;
            item.GetComponent<Renderer>().material.color = nowColor;
        }
    }

    public void OnWeaponButton()
    {
        onButton(ItemTypeForButton.weapon);
    }

    public void OnEtcButton()
    {
        onButton(ItemTypeForButton.etc);
    }

    public void OnEquipmentButton()
    {
        onButton(ItemTypeForButton.equipment);
    }

    public void OnConsumeItemButton()
    {
        onButton(ItemTypeForButton.consumeItem);
    }


    // 이거 만들고 아래 삭제하는 코드는 따로 remove는 스크립트 만들어서 넣는게 좋을 듯
    public void addItemInventory()
    {
        int ranVal = Random.Range(0,4);

        switch (ranVal)
        {
            case 0:
                inventory.Add(gameitem.ItemList[0]);
                break;
            case 1:
                inventory.Add(gameitem.ItemList[1]);
                break;
            case 2:
                inventory.Add(gameitem.ItemList[2]);
                break;
            case 3:
                inventory.Add(gameitem.ItemList[3]);
                break;
        }
    }

    public void removeItemInventory()
    {
        int ranVal = Random.Range(0, 4);

        switch (ranVal)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

}
