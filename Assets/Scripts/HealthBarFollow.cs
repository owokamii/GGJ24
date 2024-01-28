using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollow : MonoBehaviour
{
    public Transform player;
    public RectTransform healthBarUI;
    public Vector3 offset = new Vector3(0, 2, 0);

    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(player.position + offset);

        healthBarUI.position = screenPosition;
    }
}
