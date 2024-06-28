using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{

    private void Start()
    {
        IEnumerator someEunum = SomeCoroutine();
        while (someEunum.MoveNext())
        {
            //print(someEunum.Current);
        }

        IEnumerator<int> someIntEnum = SomeIntEnumerator();
        int a = 1000;
        while (someIntEnum.MoveNext())
        {
            a -= someIntEnum.Current;
            //print(a);
        }

        foreach (Transform child in transform)
        {
            //print(child.name);
        }

        //IEnumerator thisIsCoroutine = ThisIsCoroutine();
        //thisIsCoroutine.MoveNext();

        //print("�ڷ�ƾ �ѽ���Ŭ �Ѱ��");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondCoroutine(10, 0.5f));
        //StartCoroutine(RealTimeSecondsCoroutine(10, 0.5f));

        StartCoroutine(UntilCoroutine());
    }

    IEnumerator SomeCoroutine()
    {
        

        yield return "����";

        yield return 1;

        yield return false;

        yield return new object();
    }

    IEnumerator<int> SomeIntEnumerator()
    {
        yield return 6;
        yield return 2;
        yield return 923;
        yield return -323;
    }

    IEnumerator ThisIsCoroutine()
    {
        print("�ڷ�ƾ �����ߴ�");
        yield return new WaitForSeconds(1.0f); // MoveNext()�� ȣ��Ǹ� ���⼭ ���
        print("1�� ������");

        yield return new WaitForSeconds(3.0f);
        print("3�� �� ������");

        yield return new WaitForSeconds(4.0f);
        print("4�� �� ������");

    }

    IEnumerator SecondCoroutine(int count, float interval)
    {
        float timeTemp = 0;

        for (int i = 0; i < count; i++)
        {

            print($"{i}�� ȣ�� {timeTemp}�� ����");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }

    }

    IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;

        for (int i = 0; i < count; i++)
        {

            print($"������ {i}�� ȣ�� {timeTemp}�� ����");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    IEnumerator UntilCoroutine()
    {
        // WaitUntil �Ű������� �Ѿ �Լ��� Return�� false �� �� ���, true�� �� �Ѿ
        // () => : ���ٽ� �͸��Լ��̴�.
        yield return new WaitUntil(()=> { return continueKey; });

        print("��Ƽ�� Ű�� true ��");


        // WaitWhile �Ű������� �Ѿ �Լ��� Return�� true �� �� ���, false�� �� �Ѿ
        yield return new WaitWhile(() => { return continueKey; });

        print("��Ƽ�� Ű�� false�� ��");
    }
}
