using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour
{

    // �̷��� ����� Start�� �ڵ����� StartCoroutine ���ش�
    IEnumerator Start()
    {
        print(@"""Start""start.");
        yield return new WaitForSeconds(5.0f);
        print(@"""Start""end.");

    }
}
