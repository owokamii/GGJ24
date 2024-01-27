using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public void Interact()
    {
        Debug.Log("u was click E");
        CalculationSystem.UpdateItemStatus(itemType, true);
        Destroy(gameObject);
    }
}