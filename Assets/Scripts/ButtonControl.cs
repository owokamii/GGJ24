using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.RegisterButton(this.name, this);
    }

}
