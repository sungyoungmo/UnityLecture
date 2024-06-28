using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameItemManager : MonoBehaviour
{
    public static GameItemManager instance;

    public List<GameObject> ItemList;
    Action<GameObject> someAction;
    


    private void Awake()
    {
        instance = this;
       
    }
}
