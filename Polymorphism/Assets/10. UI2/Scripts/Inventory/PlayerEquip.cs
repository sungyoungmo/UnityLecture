using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public Transform[] hands;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] weaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon)
    {
        if (index > weapons.Length)
        {
            return;
        }

        weapons[index] = weapon;

        // 착용하고 있던 아이템이 있다면
        if (weaponObjs[index] != null)
        {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }
        // 매개변수 weapone이 null이 아니면 
        if (weapon != null)
        {
            // 아래와 같게 하려면 2줄만 하는게 아니라 마지막에 로컬좌표계 기준으로 0,0,0으로 만들어줘야 한다.
            //var someWeapon = Instantiate(weapon.equipPrefab);
            //someWeapon.transform.SetParent(hands[index]);
            //someWeapon.transform.localPosition = Vector3.zero;



            // 무기 오브젝트 생성
            weaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }


    }



}
