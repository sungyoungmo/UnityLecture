using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster
{
    public string orcPassive = "오크는 데미지를 10% 덜 받습니다.";

    private void Start()
    {
        maxHp = currentHP = 150;
    }

    public override void Hit(float damage)
    {
        damage *= .9f;

        base.Hit(damage);

    }


}
