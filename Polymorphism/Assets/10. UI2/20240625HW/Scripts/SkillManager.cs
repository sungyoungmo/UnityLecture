using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance { get; private set; }

    
    private void Awake()
    {
        instance = this;
    }
    public RectTransform skillPage;
    public RectTransform skillContent;

    public SkillSlot SkillSlotPrefab;
    private List<SkillSlot> skillSlots = new();

    public SkillSlot focusedSlot;
    public SkillSlot selectedSlot;

    public List<Skill> tempSkills;

    private void Start()
    {

        for (int i = 0; i < tempSkills.Count; i++)
        {
            skillContent.GetChild(i).GetComponent<SkillSlot>().Skill = tempSkills[i];
        }
    }


}

[Serializable]
public class Skill
{
    public Sprite iconSprite;
    public string skillName;
    public string desc;
    public float damage;
    public float cooltime;
}
