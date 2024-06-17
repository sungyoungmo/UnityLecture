using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Delegate (�븮��)
C++ �� �Լ� �����Ϳ� ������ ���
�޼��带 ����ó�� ���������� Ȱ���� �� �ִ� ���

Delegate ���� -> ������ (���۷���)�ڷ���ó�� ������ �����ϵ��� �����ؾ� �Ѵ�.

Delegate ���� ��ġ�� class, enum ��� �����ϴ�.


*/


//[������] delegate [��ȯ��] [�̸�] ([�Ű����� ����]);
public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);


public class DelegateTest : MonoBehaviour
{
    // delegate �ʵ� ����
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    public float x;
    public float y;

    private void Start()
    {
        //someDelegate = Minus;
        //�����ҰŸ� �Ķ���� ���� �� �ڷ���, ��ȯ�� ��� ��ġ�ؾ� �Ѵ�.

        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        //otherDelegate = PrintMessage;
        //otherDelegate = print; // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����

        //Delegate�� �ν��Ͻ��� �����ϴ� �������� ������
        otherDelegate = null;
        //otherDelegate("Hello"); �̰� �ȵ�
        otherDelegate = new OtherDelegateMethod(PrintMessage); // �̰� ���� ���� Plus�� �����ؼ� ����� �� �ְ� ����� ���� ��

        //otherDelegate("");
        otherDelegate?.Invoke("");  // ?�� null üũ�� �ϰ� �ڿ� �ִ� �Լ��� ���� �ϴ� ���ο� ����, �����ϱ� ������ ���
        // if (otherDelegate != null) otherDelegate(""); �̰Ͱ� ��������

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
