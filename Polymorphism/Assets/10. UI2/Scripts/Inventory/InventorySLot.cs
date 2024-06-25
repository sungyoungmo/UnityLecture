using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// 유니티 이벤트 핸들러 인터페이스
// 호출 주체: EventSystem

public class InventorySLot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler  
{
    public Image iconImage;


    // internal : 동일한 Assemly(같은 project 내) 내에 있는 다른 타입들이 액세스할 수 있다.
    // 하지만, 다른 어셈블리에서는 접근이 불가하다.
    // 유니티에서는 Inpector에서 참조가 안되고, 대신 다른 스크립트에서는 접근이 가능.
    // 현업에서는 보안도 낮고 활용도도 낮기 때문에 잘 사용 안함. 현업에선 아래와 같이
    // 프로토타입핑 등 빠른 구현이 필요할 때 HideInInspector 어트리뷰트를 대체하여 활용

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

    // item 필드가 null일 경우 false, null이 아닐 경우 true 반환
    public bool hasItem { get { return item != null; }  }

    public void OnDrag(PointerEventData data)
    {
        
        if (false == hasItem)   // 가독성을 위해서 ! 연산자 대신 false == 쓸 때도 있음
        {
            return;
        }

        // RectTransform.postition : 스크린 상에서의 포지션 위치
        iconImage.rectTransform.position = data.position;
        
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }


        // Transform.SetParent : 하이어라키상 부모를 지정해줌.
        // 파라미터로 null을 할당할 경우 부모없이 최상단으로 이동함.
        iconImage.rectTransform.SetParent(InventoryManager.instance.equipPage);

        // 드래그가 시작할 때 인벤 매니저에게 1개 슬롯(나 자신)을 선택 슬롯으로 저장
        InventoryManager.instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }


        // 드래그가 끝난 곳이 시작한 곳과 같을 때 : focused slot == this
        // 드래그가 끝난 곳이 인벤토리 슬롯이 아닐 때 : focused slot == null;
        // 위는 유효하지 않은 드래그 
        // 아래는 유효한 드래그
        if ((InventoryManager.instance.focusedSlot != this) && (InventoryManager.instance.focusedSlot != null))
        {
            InventorySLot targetSlot = InventoryManager.instance.focusedSlot;

            if (targetSlot.TrySwap(item))
            {
            Item2 tempItem = targetSlot.Item;

            targetSlot.Item = item;

            this.Item = tempItem;

            // 대상 슬롯에 아이템이 없을 때
            //InventoryManager.instance.focusedSlot.Item = item;
            //SetItem(null);
            }
            //InventoryManager.instance.selectedSlot = null;
        }
        InventoryManager.instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);


        // anchoredPosition : 앵커로부터의 상대적 위치
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
