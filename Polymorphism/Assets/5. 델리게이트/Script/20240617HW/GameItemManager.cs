using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameItemManager : MonoBehaviour
{
    public static GameItemManager instance;

    public List<GameObject> ItemList = new List<GameObject>();
    Action<GameObject> someAction;
    

    private void Awake()
    {
        instance = this;
        //someAction = (name) => { ItemList.Add(GameObject.Find(name)); };
        someAction = (gameO) => { ItemList.Add(gameO); };
    }
}
