using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //public static MainManager Instance;

    private float NewEnergy;

    [SerializeField]
    public EventSytem CheckActivation;

    [SerializeField]
    public EventSytem SetupEnergy;

    [SerializeField]
    private EnergyTracker energyTrack;

    //private void Awake()
    //{
    //    if(Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    private void Awake()
    {
        //CheckActivation.Raise(this, energyTrack.ActivatedProperty);

        //if(energyTrack.ActivatedProperty == true)
        //{
        //    SetupEnergy.Raise(this, energyTrack.EnergyProperty);
        //}
    }

    public void Addenergy(Component sender, object data)
    {
        if(data is float)
        {
            NewEnergy = (float)data;
            energyTrack.EnergyProperty = NewEnergy;
            //PlayerPrefs.SetFloat("Energy", NewEnergy);
        }
    }

    public void SetRoomOn(Component sender, object data)
    {
        if(data is bool)
        {
            energyTrack.ActivatedProperty = (bool)data;
        }
    }

    public void SetRoomIncriment(Component sender, object data)
    {
       if(data is int)
        {
            energyTrack.IncreaseProperty = (int)data;
        }
    }

    public float ReturnEnergy()
    {
        return NewEnergy;
    }

}
