using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySLot
{
    // 아이템을 장착 안했을 떄 보여줄 아이콘
    public Image defaultIconImage;

    public PlayerEquip playerEquip;
    public int handIndex;

    // Set Item을 할 때
    // Item propertie에 값을 대입할 때 로직을 수정

    public override Item2 Item 
    { 
        get => base.Item;
        set 
        { 
            if (value is Weapon)
            {
                // 넣으려는 아이템이 무기면
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;
                base.Item = value;
            }
            else if(value == null)
            {
                // 무기를 해제하려할 때 null을 대입.
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        
        } 
    }

    public override bool TrySwap(Item2 item)
    {
        if (item is Weapon || item is null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
