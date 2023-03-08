using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    private bool on_off;

    [Header("Events")]

    public EventSytem onButtonActivate;

    // Start is called before the first frame update
    void Start()
    {
        on_off = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    switch(on_off)
    //    {
    //        case true:
    //            Debug.Log("ON!\n");
    //            break;
    //        case false:
    //            Debug.Log("OFF!\n");
    //            break;
    //    }
    //}

    private void OnMouseDown()
    {
        switch(on_off)
        {
            case true:
                on_off = false;
                break;
            case false:
                on_off = true;
                break;
        }
        onButtonActivate.Raise(this, on_off);
    }
}
