using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Delegate (대리자)
C++ 의 함수 포인터와 유사한 기능
메서드를 변수처럼 가변적으로 활용할 수 있는 기능

Delegate 정의 -> 일종의 (레퍼런스)자료형처럼 형식을 지정하도록 정의해야 한다.

Delegate 정의 위치는 class, enum 등과 동일하다.


*/


//[지정자] delegate [반환형] [이름] ([매개변수 지정]);
public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);


public class DelegateTest : MonoBehaviour
{
    // delegate 필드 선언
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    public float x;
    public float y;

    private void Start()
    {
        //someDelegate = Minus;
        //정의할거면 파라미터 개수 및 자료형, 반환형 모두 일치해야 한다.

        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        //otherDelegate = PrintMessage;
        //otherDelegate = print; // 매개변수가 암시적 캐스팅이 가능한 경우에도 가능

        //Delegate도 인스턴스를 참조하는 형식으로 생성됨
        otherDelegate = null;
        //otherDelegate("Hello"); 이건 안됨
        otherDelegate = new OtherDelegateMethod(PrintMessage); // 이게 정석 위에 Plus는 생략해서 사용할 수 있게 만들어 놓은 것

        //otherDelegate("");
        otherDelegate?.Invoke("");  // ?는 null 체크를 하고 뒤에 있는 함수를 실행 하는 새로운 문법, 안전하기 때문에 사용
        // if (otherDelegate != null) otherDelegate(""); 이것과 마찬가지

    }

    public void CalcCahnge(int i)
    {
        switch (i)
        {
            case 0:
                someDelegate = Plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }

        ButtonClick();
    }


    public void ButtonClick()
    {
        //print(someDelegate(x, y));
        print(someDelegate?.Invoke(x,y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float y)
    {
        return x - y;
    }

    public float Multiple(float a, float b)
    {
        return a * b;
    }

    public float Divide(float x, float y)
    {
        return x / y;
    }



    public void PrintMessage(string message)
    {
        print(message);
    }

}
