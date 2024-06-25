using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSkillSlot : SkillSlot
{
    public override Skill Skill
    {
        get => base.Skill;
        set
        {            
            if (value == null)
            {
                base.Skill = value;
            }

        }
    }

    public override bool TrySwap(Skill skill)
    {
        if (skill is null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
