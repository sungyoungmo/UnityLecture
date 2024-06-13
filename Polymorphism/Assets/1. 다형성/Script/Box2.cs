using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2 : MonoBehaviour, IInteractable
{
    public Transform parent;

    public bool isHasParent = false;

    public  void Interact()
    {
        if (!isHasParent)
        {
            this.transform.SetParent(parent, false);
            this.transform.position = new Vector3(parent.position.x, 1.5f, parent.position.z);
        }
        else
        {
            this.transform.SetParent(null);
            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10.0f,ForceMode.Impulse);
        }

        
    }

    
}
