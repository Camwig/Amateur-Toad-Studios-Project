using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SliderState : ScriptableObject
{
    private bool OnOff;

    public bool StateProperty
    {
        get { return OnOff; }
        set { OnOff = value; }
    }

}
