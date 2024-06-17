using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        otherDelegate = MessageTrim;                // ��������Ʈ �ν��Ͻ� ����, MessageTrim���� �ʱ�ȭ
        otherDelegate += MessageAllTrim;            // ��������Ʈ ü�ο� MessageAllTrim �߰�
        otherDelegate += MessageDuplicate;          // ��������Ʈ ü�ο� MessageDuplicate �߰�
        otherDelegate += MessageLower;              // ��������Ʈ ü�ο� MessageLower �߰�
                                                    
        otherDelegate -= MessageAllTrim;            // ��������Ʈ ü�ο� MessageAllTrim ����

        otherDelegate?.Invoke("  Hello World  ");

        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        otherDelegate -= MessageDuplicate;          // �̷��� �ϸ� ���� �������� ���� MessageDuplicate�� ������

        // ��������Ʈ ü���� ������ Stack ����, ���� �޼ҵ� �߿����� ���� ����� ���ŵȴ�.
        // ��������Ʈ �ν��Ͻ��� ���� �����ؼ� ����
        otherDelegate = MessageTrim;    // + �� ���ϰ� �̷��� �ϸ� ���� �߰��� �͵� ��� ��ҵǰ� �길 ��µ�

        otherDelegate?.Invoke("  Hello World  ");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : ���ڿ����� �� �հ� �� �� ������ �����Ͽ� ��ȯ
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replate()�� �̿��Ͽ� ���ڿ� ������ ������� ��� ����
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        // string.ToLower() : ���ڿ��� ������ �빮�ڸ� ��� �ҹ��ڷ� �ٲ� ��ȯ
        print(message.ToLower());
    }
}
