using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public GameObject Sphere;

    static Queue<Color> colr = new Queue<Color>();
    static Queue<Vector3> vec3 = new Queue<Vector3>();

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
            if (colr.Count > 0 && vec3.Count > 0)
            {
                Vector3 v3 = vec3.Dequeue();
                Color cl = colr.Dequeue();

                Debug.Log(v3);
                Debug.Log(cl);

                Sphere.transform.position = v3;
                Sphere.GetComponent<Renderer>().material.color = cl;
            }

            yield return new WaitForSeconds(1.0f);


        }

    }
}
