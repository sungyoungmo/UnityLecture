using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOne
{
    weapon,
    ect
}

public enum TypeTwo
{
    equipment,
    consumeItem
}

public class Item : MonoBehaviour
{
    public TypeOne t1;
    public TypeTwo t2;

    
}
