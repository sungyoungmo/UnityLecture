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
        
    }

    public void OnValueChange(Vector2 value)
    {
        ObjectMove(value);

        RopeRotate();

        RopeLength();
    }

    private void ObjectMove(Vector2 value)
    {
        target.transform.position = new Vector3((value.x - 0.5f) * 4, (value.y - 0.5f) * 4, 0);
    }

    private void RopeRotate()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 기본 회전 방향이 위쪽(90도)인 경우 보정
        angle -= 90;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void RopeLength()
    {
        Vector2 currentSize = GetComponent<SpriteRenderer>().size;

        float height = Vector3.Distance(target.transform.position, transform.position);

        GetComponent<SpriteRenderer>().size = new Vector2(currentSize.x, height);


    }
}
