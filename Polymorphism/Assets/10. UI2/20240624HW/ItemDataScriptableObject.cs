using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemDataType
{
    ARROW,
    AXE
}

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject", order = 1)]
public class ItemDataScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite iconSprite;
    public ItemDataType itemDataType;
    public int damage;

}
