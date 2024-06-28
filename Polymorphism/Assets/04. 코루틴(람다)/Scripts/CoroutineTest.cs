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

        //print("코루틴 한싸이클 넘겼다");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondCoroutine(10, 0.5f));
        //StartCoroutine(RealTimeSecondsCoroutine(10, 0.5f));

        StartCoroutine(UntilCoroutine());
    }

    IEnumerator SomeCoroutine()
    {
        

        yield return "하이";

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
        print("코루틴 시작했다");
        yield return new WaitForSeconds(1.0f); // MoveNext()가 호출되면 여기서 대기
        print("1초 지났다");

        yield return new WaitForSeconds(3.0f);
        print("3초 더 지났다");

        yield return new WaitForSeconds(4.0f);
        print("4초 더 지났다");

    }

    IEnumerator SecondCoroutine(int count, float interval)
    {
        float timeTemp = 0;

        for (int i = 0; i < count; i++)
        {

            print($"{i}번 호출 {timeTemp}초 지남");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }

    }

    IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;

        for (int i = 0; i < count; i++)
        {

            print($"실제로 {i}번 호출 {timeTemp}초 지남");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    IEnumerator UntilCoroutine()
    {
        // WaitUntil 매개변수로 넘어간 함수의 Return이 false 일 때 대기, true일 때 넘어감
        // () => : 람다식 익명함수이다.
        yield return new WaitUntil(()=> { return continueKey; });

        print("컨티뉴 키가 true 됨");


        // WaitWhile 매개변수로 넘어간 함수의 Return이 true 일 때 대기, false일 때 넘어감
        yield return new WaitWhile(() => { return continueKey; });

        print("컨티뉴 키가 false가 됨");
    }
}
