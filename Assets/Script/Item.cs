using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("u was click E");
        Destroy(gameObject);
    }
}