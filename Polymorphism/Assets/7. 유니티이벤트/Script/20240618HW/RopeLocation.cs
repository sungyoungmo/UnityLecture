using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class RopeLocation : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        
        this.transform.rotation = Quaternion.AngleAxis(45f, Vector3.forward);
    }

    public void OnValueChange(Vector2 value)
    {
        target.transform.position = new Vector3((value.x-0.5f) * 2, (value.y - 0.5f) * 2, 0);
        // 업데이트 문에 있는 함수를 통해 회전할건데 밸류의 값에 따라 돌아가게 만들거야 함
        // https://blog.spiralmoon.dev/entry/%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D-%EC%9D%B4%EB%A1%A0-%EB%91%90-%EC%A0%90-%EC%82%AC%EC%9D%B4%EC%9D%98-%EC%A0%88%EB%8C%80%EA%B0%81%EB%8F%84%EB%A5%BC-%EC%9E%AC%EB%8A%94-atan2
    }

}
