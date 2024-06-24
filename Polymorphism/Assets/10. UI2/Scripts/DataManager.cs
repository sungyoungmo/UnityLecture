using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// �÷��̾� �����͸� �����ϴ� Ŭ����
public class PlayerData2
{
    private int[] currencyArray1 = new int[5];
    // �Ʒ��� ��ưų� �����ϸ� �̷��� �ϳ��� �־���� ��

    private int[] currencyArray = new int[Enum.GetValues(typeof(CurrencyType)).Length];
    // Enum.GetValues: Ÿ�� ���� ��� ���θ� �������� �Լ�

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

        print($"{type} ���:  {playerData[type]}");
    }

    public void AddCurrency(CurrencyType type, int amount)
    {

    }
}
