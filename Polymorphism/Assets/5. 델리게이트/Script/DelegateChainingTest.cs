using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        otherDelegate = MessageTrim;                // 델리게이트 인스턴스 생성, MessageTrim으로 초기화
        otherDelegate += MessageAllTrim;            // 델리게이트 체인에 MessageAllTrim 추가
        otherDelegate += MessageDuplicate;          // 델리게이트 체인에 MessageDuplicate 추가
        otherDelegate += MessageLower;              // 델리게이트 체인에 MessageLower 추가
                                                    
        otherDelegate -= MessageAllTrim;            // 델리게이트 체인에 MessageAllTrim 제거

        otherDelegate?.Invoke("  Hello World  ");

        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        otherDelegate -= MessageDuplicate;          // 이렇게 하면 제일 마지막에 쌓인 MessageDuplicate를 제거함

        // 델리게이트 체인은 일종의 Stack 구조, 같은 메소드 중에서만 선입 후출로 제거된다.
        // 델리게이트 인스턴스를 새로 생성해서 대입
        otherDelegate = MessageTrim;    // + 를 안하고 이렇게 하면 위에 추가한 것들 모두 취소되고 얘만 출력됨

        otherDelegate?.Invoke("  Hello World  ");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : 문자열에서 맨 앞과 맨 뒤 공백을 제거하여 반환
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replate()를 이용하여 문자열 내부의 공백까지 모두 제거
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        // string.ToLower() : 문자열의 영문자 대문자를 모두 소문자로 바꿔 반환
        print(message.ToLower());
    }
}
