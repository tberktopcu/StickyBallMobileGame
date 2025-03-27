using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Touch touch;

    [HideInInspector]
    public bool firstTouch = false;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            firstTouch = true;
        }
    }
}
