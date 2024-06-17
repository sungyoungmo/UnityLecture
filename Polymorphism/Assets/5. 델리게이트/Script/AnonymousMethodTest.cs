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


    // ���� �޼����
    // Ŭ�������� �ƴ� �޼��� ������ ���ǵǴ� �޼���
    // �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ��� �ش� Delegate�� �Ű� ������ ��ȯ���� Ÿ���� ��ġ�ؾ� ��.

    // ���� �޼����� ����: ��ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ���� �������� �����ϴ� ������ �ִ�.
    // ���� ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���� ��� �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� �����ϹǷ� 
    // ���ʿ��ϰ� �Լ��� �޸𸮸� �����ϴ� ���� ������ �� �ִ�.

    // ���: ������ �Ⱦ��� �Լ��� �޸𸮸� �Ƴ��� ���� ����ϴ� ���� ����

    // ���� �޼����� ����: ��������Ʈ ü�̴��� ����� ��, �ش� �޼��常 ü�ο��� �����ϴ� ���� �Ұ����ϴ�.
    // someAction2�� ����� someAction�� someAction2�� �Ҵ��ؼ� ����ϸ� ����� ���� ����
    // ����, �� �޼��忡�� ���� ����޼��� ���� �ÿ� ������ �������� ������ �� �ִ�.

    // ���: ü���� ��������� �� ���������� �����ϸ� �������� ��������.


    // ���ٽ�: ����޼����� ���� ǥ��
    // (C# ��������) ���ٽ� = ����޼��� �����

    private void Awake()
    {
        // �̷��� ����ϴ� ���� ���� �޼���
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

        // ���� �޼��� �Ҵ翡�� �Ű����� ������ ���ʿ��� ��� ���� ����
        autoCastPlus += delegate
        {
            print("Calc Finished!");
        };

        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("�Էµ� �Ķ���ʹ� ");
            sb.Append(a);
            sb.Append("�Դϴ�. ");

            return sb.ToString();
        };

        // ���ٽ� ǥ�����
        someAction += (/*�Ķ����*/) => { /*�Լ� ����*/ };

        // delegate Ű���� ��� => ��ȣ�� ���� ���� �޼������� ���
        someFunc += (int a) => {return a + " is intager."; };

        // �ڷ����� �Ͻ������� ���� ����, �Լ������� �߰�ȣ�� return�� �Բ� �����ϸ� ���� ����.
        // �߰��� �Ķ���Ͱ� �� ����� �Ұ�ȣ ���� ����
        someFunc += a => a + " is intager.";

        // �Ű������� 2�� �̻��� ��� �ݵ�� ��ȣ �ȿ� �Ű� �������� ����.
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
