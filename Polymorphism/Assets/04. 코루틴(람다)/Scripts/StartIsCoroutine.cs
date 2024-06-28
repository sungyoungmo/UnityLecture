using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour
{

    // 이렇게 만들면 Start를 자동으로 StartCoroutine 해준다
    IEnumerator Start()
    {
        print(@"""Start""start.");
        yield return new WaitForSeconds(5.0f);
        print(@"""Start""end.");

    }
}
