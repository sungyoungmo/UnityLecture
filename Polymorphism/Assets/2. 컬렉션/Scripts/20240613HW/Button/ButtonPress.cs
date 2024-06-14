using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public GameObject Sphere;

    protected static Queue<Color> colr = new Queue<Color>();
    protected static Queue<Vector3> vec3 = new Queue<Vector3>();

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
            Debug.Log(colr.Count);
            Debug.Log(vec3.Count);

            yield return new WaitForSeconds(1.0f);
            if (colr.Count > 0 && vec3.Count > 0)
            {
                Sphere.transform.position = vec3.Dequeue();
                Sphere.GetComponent<Renderer>().material.color = colr.Dequeue();
            }

            
        }

    }
}
