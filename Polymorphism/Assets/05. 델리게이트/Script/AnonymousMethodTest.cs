using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonymousMethodTest : MonoBehaviour
{
    Action someAction;
    Action someAction2;
    Action<int, float> autoCastPlus;
    Func<int, string> someFunc;
    Func<int, int,string> someFunc2;


    // 무명 메서드란
    // 클래스내가 아닌 메서드 내에서 정의되는 메서드
    // 메서드에 이름이 없으며, Delegate에 할당하기 위해서는 해당 Delegate와 매개 변수와 반환형의 타입이 일치해야 함.

    // 무명 메서드의 장점: 일회성으로 사용되는 함수의 정의를 따로 함수 밖에서 할 필요가 없어 가독성이 증가하는 측면이 있다.
    // 또한 지역적으로 사용되는 델리게이트 변수에 할당하는 식으로 사용될 경우 해당 포커스가 종료되면 메모리 할당을 해제하므로 
    // 불필요하게 함수가 메모리를 점유하는 것을 방지할 수 있다.

    // 요약: 여러번 안쓰는 함수면 메모리를 아끼기 위해 사용하는 것이 좋음

    // 무명 메서드의 단점: 델리게이트 체이닝을 사용할 때, 해당 메서드만 체인에서 제거하는 것이 불가능하다.
    // someAction2를 만들고 someAction를 someAction2에 할당해서 사용하면 사용할 수는 있음
    // 또한, 한 메서드에서 많은 무명메서드 정의 시에 오히려 가독성이 떨어질 수 있다.

    // 요약: 체인을 쓰고싶으면 좀 복잡해지고 남발하면 가독성이 떨어진다.


    // 람다식: 무명메서드의 축약식 표현
    // (C# 한정으로) 람다식 = 무명메서드 축약형

    private void Awake()
    {
        // 이렇게 사용하는 것이 무명 메서드
        someAction2 = someAction = delegate ()
        {
            print("Anonymous Method Called.");
        };


        someAction2 -= someAction;

        autoCastPlus = delegate (int a, float b)
        {
            int result = a + (int)b;
            print(result);
        };

        // 무명 메서드 할당에서 매개변수 참조가 불필요할 경우 생략 가능
        autoCastPlus += delegate
        {
            print("Calc Finished!");
        };

        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("입력된 파라미터는 ");
            sb.Append(a);
            sb.Append("입니다. ");

            return sb.ToString();
        };

        // 람다식 표현방법
        someAction += (/*파라미터*/) => { /*함수 본문*/ };

        // delegate 키워드 대신 => 기호를 통해 무명 메서드임을 명시
        someFunc += (int a) => {return a + " is intager."; };

        // 자료형은 암시적으로 생략 가능, 함수본문의 중괄호도 return과 함께 생략하면 생략 가능.
        // 추가로 파라미터가 한 개라면 소괄호 생략 가능
        someFunc += a => a + " is intager.";

        // 매개변수가 2개 이상일 경우 반드시 괄호 안에 매개 변수명을 선언.
        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";
    }

    private void Start()
    {
        //someAction?.Invoke();        
        //someAction?.Invoke();
        someAction2?.Invoke();
        
        autoCastPlus?.Invoke(1, 1.1f);
        autoCastPlus(1, 1.1f);

        print(someFunc?.Invoke(1));
        
    }


}
