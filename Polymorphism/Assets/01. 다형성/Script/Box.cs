using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IHitable, IInteractable
{
    public float maxDamage = 10;
    public LayerMask someLayer;

    private void Start()
    {
        //print(someLayer.value);


        //Ray ray = new Ray(Vector3.zero,Vector3.up);
        //Physics.Raycast(ray, Mathf.Infinity, someLayer);

    }


    public void Hit(float damage)
    {

        if (damage >= maxDamage)
        {
            //Destroy(gameObject);
        }

        print($"{name} hitted and damaged : {damage}");
    }





    public void Interact()
    {
        Destroy(gameObject);
    }


}
