using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster
{
    public string orcPassive = "��ũ�� �������� 10% �� �޽��ϴ�.";

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
