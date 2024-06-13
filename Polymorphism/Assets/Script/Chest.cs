using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        Debug.Log("interact");

        if (GetComponent<Animator>().GetBool("isOpen"))
        {
            GetComponent<Animator>().SetBool("isOpen", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

}
