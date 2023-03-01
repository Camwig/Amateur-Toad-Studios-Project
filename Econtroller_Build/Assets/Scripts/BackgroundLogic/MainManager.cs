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
            PlayerPrefs.SetFloat("Energy", NewEnergy);
        }
    }

    public float ReturnEnergy()
    {
        return NewEnergy;
    }

}
