using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    public Image cooltimeImage;

    internal Skill skill = null;


    private void Start()
    {
        Skill = skill;
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
            StartCoroutine(cooltime(SkillManager.instance.selectedSlot.skill.cooltime));

            SkillSlot targetSlot = SkillManager.instance.focusedSlot;

            Image targetImage = targetSlot.GetComponent<Image>();

            if (targetImage != null)
            {
                targetImage.sprite = iconImage.sprite;
                targetImage.color = iconImage.color;
                targetImage.type = iconImage.type;
                targetImage.preserveAspect = iconImage.preserveAspect;
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

    IEnumerator cooltime(float cooltime)
    {
        cooltimeImage.enabled = true;

        cooltimeImage.fillAmount = 1;

        while (cooltimeImage.fillAmount > 0)
        {
            cooltimeImage.fillAmount -= Time.deltaTime / cooltime;
            yield return null;
        }

        cooltimeImage.fillAmount = 0;

        cooltimeImage.enabled = false;
    }
}
