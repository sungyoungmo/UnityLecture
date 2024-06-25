using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// ����Ƽ �̺�Ʈ �ڵ鷯 �������̽�
// ȣ�� ��ü: EventSystem

public class InventorySLot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler  
{
    public Image iconImage;


    // internal : ������ Assemly(���� project ��) ���� �ִ� �ٸ� Ÿ�Ե��� �׼����� �� �ִ�.
    // ������, �ٸ� ����������� ������ �Ұ��ϴ�.
    // ����Ƽ������ Inpector���� ������ �ȵǰ�, ��� �ٸ� ��ũ��Ʈ������ ������ ����.
    // ���������� ���ȵ� ���� Ȱ�뵵�� ���� ������ �� ��� ����. �������� �Ʒ��� ����
    // ������Ÿ���� �� ���� ������ �ʿ��� �� HideInInspector ��Ʈ����Ʈ�� ��ü�Ͽ� Ȱ��

    internal Item2 item = null;

    private void Start()
    {
        Item = item;
    }


    public virtual Item2 Item { get { return item; }
        set { item = value;
        if (item == null)
            {
                iconImage.enabled = false;
            }
        else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.iconSprite;
            }
} }

    public virtual bool TrySwap(Item2 item)
    {
        if (item is Weapon && hasItem)
        {
            if (this.item is Weapon)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        return true;
            
    }

    // item �ʵ尡 null�� ��� false, null�� �ƴ� ��� true ��ȯ
    public bool hasItem { get { return item != null; }  }

    public void OnDrag(PointerEventData data)
    {
        
        if (false == hasItem)   // �������� ���ؼ� ! ������ ��� false == �� ���� ����
        {
            return;
        }

        // RectTransform.postition : ��ũ�� �󿡼��� ������ ��ġ
        iconImage.rectTransform.position = data.position;
        
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }


        // Transform.SetParent : ���̾��Ű�� �θ� ��������.
        // �Ķ���ͷ� null�� �Ҵ��� ��� �θ���� �ֻ������ �̵���.
        iconImage.rectTransform.SetParent(InventoryManager.instance.equipPage);

        // �巡�װ� ������ �� �κ� �Ŵ������� 1�� ����(�� �ڽ�)�� ���� �������� ����
        InventoryManager.instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }


        // �巡�װ� ���� ���� ������ ���� ���� �� : focused slot == this
        // �巡�װ� ���� ���� �κ��丮 ������ �ƴ� �� : focused slot == null;
        // ���� ��ȿ���� ���� �巡�� 
        // �Ʒ��� ��ȿ�� �巡��
        if ((InventoryManager.instance.focusedSlot != this) && (InventoryManager.instance.focusedSlot != null))
        {
            InventorySLot targetSlot = InventoryManager.instance.focusedSlot;

            if (targetSlot.TrySwap(item))
            {
            Item2 tempItem = targetSlot.Item;

            targetSlot.Item = item;

            this.Item = tempItem;

            // ��� ���Կ� �������� ���� ��
            //InventoryManager.instance.focusedSlot.Item = item;
            //SetItem(null);
            }
            //InventoryManager.instance.selectedSlot = null;
        }
        InventoryManager.instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);


        // anchoredPosition : ��Ŀ�κ����� ����� ��ġ
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = null;
    }
}
