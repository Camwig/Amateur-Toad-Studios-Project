using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnergyTracker : ScriptableObject
{
    //propfull then double tap tab

    private float NewEnergy;

    public float EnergyProperty
    {
        get { return NewEnergy; }
        set { NewEnergy = value; }
    }

    private float RateOfIncrease;

    public float IncreaseProperty
    {
        get { return RateOfIncrease; }
        set { RateOfIncrease = value; }
    }


    private bool Activated;

    public bool ActivatedProperty
    {
        get { return Activated; }
        set { Activated = value; }
    }


    //private void OnValidate()
    //{
    //    DontDestroyOnLoad(this);
    //}

}
