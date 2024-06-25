using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;

    internal Skill skill = null;


    private void Start()
    {
        
    }

    public virtual Skill Skill 
    { 
        get 
        { 
            return skill; 
        } 
    
        set
        {
            skill = value;
            if (skill == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = skill.iconSprite;
            }
        }
    
    }

    public virtual bool TrySwap(Skill skill)
    {
        if (hasSkill)
        {
            return false;
        }
        return true;
    }

    public bool hasSkill { get { return skill != null; } }

    

    public void OnDrag(PointerEventData data)
    {
        if (!hasSkill)
        {
            return;
        }
        iconImage.rectTransform.position = data.position;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (!hasSkill)
        {
            return;
        }
        iconImage.rectTransform.SetParent(SkillManager.instance.skillPage);

        SkillManager.instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!hasSkill)
        {
            return;
        }

        if ((SkillManager.instance.focusedSlot != this) && (SkillManager.instance.focusedSlot != null))
        {
            SkillSlot targetSlot = SkillManager.instance.focusedSlot;

            if (targetSlot.TrySwap(skill))
            {
                Skill tempItem = targetSlot.Skill;

                targetSlot.Skill = skill;

                this.Skill = tempItem;
            }
        }
        SkillManager.instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);

        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        SkillManager.instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        SkillManager.instance.focusedSlot = this;
    }
}
