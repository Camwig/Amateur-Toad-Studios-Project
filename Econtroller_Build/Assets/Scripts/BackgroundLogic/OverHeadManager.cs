using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadManager : MonoBehaviour
{
    //static private OverHeadManager Instance = null;
    public Overhead overhead_;
    public EnergyTracker energyTrack;
    public EnergyTracker energyTrack2;
    public EnergyTracker energyTrack3;

   private static bool firstPlay=true;


    void Awake()
    {
        //if(Instance!=null)
        //{
        //    Destroy(this);
        //    return;
        //}
        //else if (Instance == null)
        //{
        //    Instance = this;

        //    //PlayerPrefs.DeleteAll();

        //    overhead_.SetEnergy(0);
        //    PlayerPrefs.SetFloat("Overall_energy", 0);
        //    PlayerPrefs.SetFloat("Energy", 0);
        //    energyTrack.EnergyProperty = 0;
        //    energyTrack2.EnergyProperty = 0;

        //    //DontDestroyOnLoad(Instance);
        //}

        //if(firstPlay != false)
        //{
        //    PlayerPrefs.SetInt("FirstPlay", 1);
        //}

        //if(PlayerPrefs.GetInt("Firstplay")== 1)
        //{
        //    //runNow = false;
        //    PlayerPrefs.SetInt("FirstPlay", 0);
        //    PlayerPrefs.Save();
        //    Debug.Log("Starting...\n");
        //    firstPlay = true;
        //}
        //else
        //{
        //    //runNow = true;
        //    Debug.Log("Running...\n");
        //    firstPlay = false;
        //}

        if(firstPlay == true)
        {
            Debug.Log("Starting...\n");
            //PlayerPrefs.DeleteAll();

            overhead_.SetEnergy(0);
            //PlayerPrefs.SetFloat("Overall_energy", 0);
            //PlayerPrefs.SetFloat("Energy", 0);

            energyTrack.EnergyProperty = 0;
            energyTrack2.EnergyProperty = 0;
            energyTrack3.EnergyProperty = 0;
            energyTrack.IncreaseProperty = 1;
            energyTrack2.IncreaseProperty = 1;
            energyTrack3.IncreaseProperty = 1;
            energyTrack.ActivatedProperty = false;
            energyTrack2.ActivatedProperty = false;
            energyTrack3.ActivatedProperty = false;

            firstPlay = false;
        }
        else
        {
            Debug.Log("Running...\n");
        }
    }
}
