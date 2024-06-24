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
    
    �÷��̾��� ���� ������ �ƴ� �̹� ��ϵ�

    �÷��̾�� �������̶�� ���� ������ �־�� ��
    �÷��̾ ���� �������� ������ ���̽� Ȥ�� scriptable object�� ���� ��������ȴ�.
    (���̽��� ��������Ʈ�� ���� ������ ���� ���ϴ� ���ڸ� �����ؾ߰ڴ�.)

    �켱 ĳ���Ͱ� ���� �������� ����Ʈ�� foreach�� ���� ��ȸ�� ����
    �����ϰ� �ִ� �������� �κ��丮�� ���
    (ItemList/content/items[i] �ȿ� ���ο� ������Ʈ�� ������ �� �ű⿡ <Image>�ο� �� ����
    ������ �ִ� ��������Ʈ�� ���)


    �׷� ĳ���ʹ� ���� ������ �־�� �ϳ�
    ĳ���ʹ� �������� ����Ʈ�� ������ �־�� �ϰ� 
    �� ����Ʈ�� �� ��ũ��Ʈ���� �Ŵ����� ������ �κ��丮�� �Ѹ��� ����


    scriptable object: �������� 
    enum���� ����� ȭ�� ����� ���س���
    �̸�, ��������Ʈ, Ÿ��(�� enum),���ݷ� �̷��� �س��߰ڴ�.


    �÷��̾ ���� ������ �ƴ϶� �����ۿ� ���� �����ϱ� �����ϱ� ���� ���ݷ��� �߰��ؾ� �ϰ�
    �κ��丮 ĭ�� 3*4�� �ƴ϶� 4ĭ���� ����� ���ʿ� ��������Ʈ �����ʿ� ���ݷ� �� �̸��� �־� ���� ���� ���� ��

    �÷��̾ ���� ����


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
