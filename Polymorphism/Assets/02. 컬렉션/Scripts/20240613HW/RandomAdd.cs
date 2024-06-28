using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomAdd : MonoBehaviour
{
    List<Vector3> vec3 = new List<Vector3>();
    List<Color> colrs = new List<Color>();

    //public GameObject GObject;

    private void Start()
    {
        RandomPos();
        RandomColor();

        StartCoroutine(waitOneSec());
    }


    private void RandomPos()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomVal = UnityEngine.Random.Range(0, 5);

            switch (randomVal)
            {
                case 0:
                    vec3.Add(new Vector3(1, 1, 1));
                    break;
                case 1:
                    vec3.Add(new Vector3(-1, 1, 1));
                    break;
                case 2:
                    vec3.Add(new Vector3(-1, -1, 1));
                    break;
                case 3:
                    vec3.Add(new Vector3(1, -1, 1));
                    break;
                case 4:
                    vec3.Add(new Vector3(-1, -1, -1));
                    break;
                default:
                    break;
            }

        }
    }

    private void RandomColor()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomVal = UnityEngine.Random.Range(0, 5);

            switch (randomVal)
            {
                case 0:
                    colrs.Add(Color.black);
                    break;
                case 1:
                    colrs.Add(Color.blue);
                    break;
                case 2:
                    colrs.Add(Color.red);
                    break;
                case 3:
                    colrs.Add(Color.white);
                    break;
                case 4:
                    colrs.Add(Color.yellow);
                    break;
                default:
                    break;
            }

        }
    }



    IEnumerator waitOneSec()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.position = vec3[i];
            GetComponent<Renderer>().material.color = colrs[i];


            yield return new WaitForSeconds(1.0f);
        }

        
    }
}


