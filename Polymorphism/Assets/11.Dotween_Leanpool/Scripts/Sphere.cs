using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sphere : MonoBehaviour
{

    private void OnEnable()
    {
        transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
    }
}
