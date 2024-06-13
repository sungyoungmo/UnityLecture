using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    public GameObject Sphere;

    protected Queue<Color> colr = new Queue<Color>();
    protected Queue<Vector3> vec3 = new Queue<Vector3>();

    private void Awake()
    {
        Sphere = GameObject.Find("Sphere");
    }

    private void Start()
    {
        StartCoroutine(setRand());
    }

    protected virtual void setColor()
    {
        Color clr = GetComponent<Image>().color;
        colr.Enqueue(clr);
    }

    protected virtual void setPosition()
    {
        float frndXVal = Random.Range(1, 3);
        float frndYVal = Random.Range(1, 3);
        float frndZVal = Random.Range(1, 3);

        Vector3 mVec = new Vector3(frndXVal, frndYVal, frndZVal);

        vec3.Enqueue(mVec);
    }

    IEnumerator setRand()
    {
        while (true)
        {


            //if (colr.TryPeek() && colr.Contains)
            //{
            //    Sphere.transform.position = vec3.Dequeue();
            //    Sphere.GetComponent<Renderer>().material.color = colr.Dequeue();

            //    yield return new WaitForSeconds(1.0f);
            //}
        }

    }


}
