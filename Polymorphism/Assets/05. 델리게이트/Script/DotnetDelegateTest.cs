using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // Action ��������Ʈ : �⺻���� ������ ������Ƽ�� Dotnet���� �⺻������ �����Ͽ� ����
    // ��ȯ���� ���� Method
    Action action;

    // action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam;
    // �Ķ���� 16�������� �̷��� ���� ����
    

    //Func ��������Ʈ : ��ȯ���� �ִ� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����.
    Func<object> func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� �ڴ� ��ȯ��, �� ���� �Ķ���� Ÿ�� ����

    Func<string, int> parseFunc;



    // Predicate ��������Ʈ : ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ.
    Predicate<float> predicate;
    // Func<float, bool>

    private void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithParam;
        parseFunc = Parse;

        // Predicate ��� ����
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);

        // intList���� ¦���� �̾ƿ��� �ʹ�.

        List<int> evenList = intList.FindAll(IsEven);

        foreach (int i in evenList)
        {
            print(i);
        }

        // Predicate�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ� Bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ���.


        // ¦���� Findall �� �� ���� �޼��带 ����� ���
        List<int> evenListByAnonymousMethod = intList.FindAll
            (
                delegate (int param)
                {
                    return param % 2 == 0;
                }
            );
    }

    private void SomeAction()
    {

    }

    private void SomeActionWithParam(int a)
    {
        // �Ķ���� A�� ���� �Ѵٰ� ġ��
    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }

}
