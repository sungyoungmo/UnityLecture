using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDataHW
{
    private int[] ItemsArray = new int[Enum.GetValues(typeof(ItemDataType)).Length];

    public int this[ItemDataType type]
    {
        get { return ItemsArray[(int)type]; }
        set { ItemsArray[(int)type] = value; }
    }

}


public class PlayerItemManager : MonoBehaviour
{
    public List<ItemDataScriptableObject> itemDataList;
    public ItemListHW itemListHW;

    public static PlayerItemManager instance { get; private set; }
    public ItemDataHW itemDataHW = new ItemDataHW();


    /*
    
    플레이어의 대한 정보가 아닌 이미 등록된

    플레이어는 아이템이라는 것을 가지고 있어야 함
    플레이어가 가진 아이템의 정보는 제이슨 혹은 scriptable object를 통해 가져오면된다.
    (제이슨은 스프라이트에 대한 정보는 읽지 못하니 후자를 선택해야겠다.)

    우선 캐릭터가 가진 아이템의 리스트를 foreach를 통해 순회한 다음
    보유하고 있는 아이템은 인벤토리에 출력
    (ItemList/content/items[i] 안에 새로운 오브젝트를 생성한 후 거기에 <Image>부여 한 다음
    정보에 있는 스프라이트를 등록)


    그럼 캐릭터는 무얼 가지고 있어야 하냐
    캐릭터는 아이템을 리스트로 가지고 있어야 하고 
    그 리스트는 이 스크립트에서 매니저가 참조해 인벤토리에 뿌리는 역할


    scriptable object: 아이템은 
    enum으로 망토와 화살 등등을 정해놓고
    이름, 스프라이트, 타입(위 enum),공격력 이렇게 해놔야겠다.


    플레이어에 대한 정보가 아니라 아이템에 대한 정보니까 구분하기 위해 공격력을 추가해야 하고
    인벤토리 칸을 3*4가 아니라 4칸으로 만들고 왼쪽에 스프라이트 오른쪽에 공격력 및 이름을 넣어 놓는 것이 좋을 듯

    플레이어에 대한 정보


    */
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        itemListHW.InitializeItem();
    }
}
