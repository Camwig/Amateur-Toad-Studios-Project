using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnergyTracker : ScriptableObject
{
    private float NewEnergy;

    public float EnergyProperty
    {
        get { return NewEnergy; }
        set { NewEnergy = value; }
    }

    //private void OnValidate()
    //{
    //    DontDestroyOnLoad(this);
    //}

}
