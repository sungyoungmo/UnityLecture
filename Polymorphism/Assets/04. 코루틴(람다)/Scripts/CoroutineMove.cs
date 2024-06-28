using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMove : MonoBehaviour
{

    Coroutine mainCoroutine;
    Coroutine moveCoroutine;
    Coroutine rotateCoroutine;


    private void Start()
    {
        mainCoroutine =  StartCoroutine(MainCoroutine());


    }

    public void CoroutineStopButton()
    {
        
        if (mainCoroutine != null)
        {
            StopCoroutine(mainCoroutine);
        }

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        if (rotateCoroutine != null) 
        { 
            StopCoroutine(rotateCoroutine); 
        }
    }



    IEnumerator RotateCoroutine()
    {
        float endTime = Time.time + 5;

        while (Time.time < endTime)
        {
            transform.Rotate(new Vector3(60 * Time.deltaTime,0,0));
            yield return null;
        }

    }

    IEnumerator MoveCoroutine()
    {
        float endtime = Time.time + 5;
        
        while (Time.time < endtime)
        {
            transform.Translate(new Vector3(0, 1.0f * Time.deltaTime, 0));
            yield return null;
        }
    }

    IEnumerator MainCoroutine()
    {
        while (true)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine());
            yield return moveCoroutine;

            rotateCoroutine = StartCoroutine(RotateCoroutine());
            yield return rotateCoroutine;
        }
    }
}
