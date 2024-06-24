using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 플레이어 데이터를 참조하는 클래스
public class PlayerData2
{
    private int[] currencyArray1 = new int[5];
    // 아래가 어렵거나 복잡하면 이렇게 하나씩 넣어줘야 함

    private int[] currencyArray = new int[Enum.GetValues(typeof(CurrencyType)).Length];
    // Enum.GetValues: 타입 내의 요소 전부를 가져오는 함수

    public int this[CurrencyType type]
    {
        get { return currencyArray[(int)type]; }
        set { currencyArray[(int)type] = value; }
    }

}

public class DataManager : MonoBehaviour
{
    public List<CurrencyData> currencyDataList;
    public CurrencyList currencyList;

    public static DataManager instance { get; private set;}

    public PlayerData2 playerData = new PlayerData2();

    public Action<CurrencyType, int> onCurrencyAmountChange;    // deligate


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //foreach (CurrencyData currencyData in currencyDataList)
        //{
        //    print(currencyData.currencyName);
        //}

        currencyList.Initialize();
    }

    public void AddCurrency(int param)
    {
        CurrencyType type = (CurrencyType)param;

        playerData[type] +=5;

        onCurrencyAmountChange?.Invoke(type, playerData[type]);

        print($"{type} 상승:  {playerData[type]}");
    }

    public void AddCurrency(CurrencyType type, int amount)
    {

    }
}
