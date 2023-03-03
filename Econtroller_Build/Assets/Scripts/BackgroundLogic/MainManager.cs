using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //public static MainManager Instance;

    private float NewEnergy;

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
       if(data is float)
        {
            energyTrack.IncreaseProperty = (float)data;
        }
    }

    public float ReturnEnergy()
    {
        return NewEnergy;
    }

}
