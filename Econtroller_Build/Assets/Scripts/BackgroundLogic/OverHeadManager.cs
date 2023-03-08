//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OverHeadManager : MonoBehaviour
//{
//    //static private OverHeadManager Instance = null;
//    public Overhead overhead_;
//    public EnergyTracker energyTrack;
//    public EnergyTracker energyTrack2;
//    public EnergyTracker energyTrack3;

//    public static float energyTrack_amount;
//    public static float energyTrack2_amount;
//    public static float energyTrack3_amount;


//    public float new_energyTrack_amount;
//    public float new_energyTrack2_amount;
//    public float new_energyTrack3_amount;

//    private static bool firstPlay=true;


//    void Awake()
//    {
//        //if(Instance!=null)
//        //{
//        //    Destroy(this);
//        //    return;
//        //}
//        //else if (Instance == null)
//        //{
//        //    Instance = this;

//        //    //PlayerPrefs.DeleteAll();

//        //    overhead_.SetEnergy(0);
//        //    PlayerPrefs.SetFloat("Overall_energy", 0);
//        //    PlayerPrefs.SetFloat("Energy", 0);
//        //    energyTrack.EnergyProperty = 0;
//        //    energyTrack2.EnergyProperty = 0;

//        //    //DontDestroyOnLoad(Instance);
//        //}

//        //if(firstPlay != false)
//        //{
//        //    PlayerPrefs.SetInt("FirstPlay", 1);
//        //}

//        //if(PlayerPrefs.GetInt("Firstplay")== 1)
//        //{
//        //    //runNow = false;
//        //    PlayerPrefs.SetInt("FirstPlay", 0);
//        //    PlayerPrefs.Save();
//        //    Debug.Log("Starting...\n");
//        //    firstPlay = true;
//        //}
//        //else
//        //{
//        //    //runNow = true;
//        //    Debug.Log("Running...\n");
//        //    firstPlay = false;
//        //}

//        if(firstPlay == true)
//        {
//            Debug.Log("Starting...\n");
//            //PlayerPrefs.DeleteAll();

//            overhead_.SetEnergy(0);
//            //PlayerPrefs.SetFloat("Overall_energy", 0);
//            //PlayerPrefs.SetFloat("Energy", 0);

//            energyTrack.EnergyProperty = 0;
//            energyTrack2.EnergyProperty = 0;
//            energyTrack3.EnergyProperty = 0;
//            energyTrack.IncreaseProperty = 1;
//            energyTrack2.IncreaseProperty = 1;
//            energyTrack3.IncreaseProperty = 1;
//            energyTrack.ActivatedProperty = false;
//            energyTrack2.ActivatedProperty = false;
//            energyTrack3.ActivatedProperty = false;

//            energyTrack_amount = 0.0f;
//            energyTrack2_amount = 0.0f;
//            energyTrack3_amount = 0.0f;

//            firstPlay = false;
//        }
//        else
//        {
//            Debug.Log("Running...\n");

//            if (!energyTrack.ActivatedProperty)
//            {
//                if (energyTrack.EnergyProperty > energyTrack_amount)
//                {
//                    Debug.Log(energyTrack.EnergyProperty);
//                    //Not doing anything
//                    new_energyTrack_amount = energyTrack.EnergyProperty - energyTrack_amount;
//                    energyTrack.EnergyProperty = new_energyTrack_amount;
//                    Debug.Log(energyTrack.EnergyProperty);
//                }
//            }

//            //if (!energyTrack2.ActivatedProperty)
//            //{
//            //    if (energyTrack2.EnergyProperty > energyTrack2_amount)
//            //    {
//            //        new_energyTrack2_amount = energyTrack2.EnergyProperty - energyTrack2_amount;
//            //        energyTrack2.EnergyProperty = new_energyTrack2_amount;
//            //    }
//            //}

//            if (!energyTrack3.ActivatedProperty)
//            {

//                if (energyTrack3.EnergyProperty > energyTrack3_amount)
//                {
//                    new_energyTrack3_amount = energyTrack3.EnergyProperty - energyTrack3_amount;
//                    energyTrack3.EnergyProperty = new_energyTrack3_amount;
//                }
//            }
//        }
//    }

//    private void OnDestroy()
//    {
//        energyTrack_amount = energyTrack.EnergyProperty;
//        //energyTrack2_amount = energyTrack2.EnergyProperty;
//        energyTrack3_amount = energyTrack3.EnergyProperty;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadManager : MonoBehaviour
{
    //static private OverHeadManager Instance = null;
    public Overhead overhead_;
    public EnergyTracker energyTrack;
    public EnergyTracker energyTrack2;

    public SliderState slide_state;
    public bool now_state;
    //public EnergyTracker energyTrack3;

    public static float energyTrack_amount;
    public static float energyTrack2_amount;
   // public static float energyTrack3_amount;


    public float new_energyTrack_amount;
    public float new_energyTrack2_amount;
   // public float new_energyTrack3_amount;

    private static bool firstPlay = true;


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

        if (firstPlay == true)
        {
            //Debug.Log("Starting...\n");
            //PlayerPrefs.DeleteAll();

            overhead_.SetEnergy(0);
            //PlayerPrefs.SetFloat("Overall_energy", 0);
            //PlayerPrefs.SetFloat("Energy", 0);

            energyTrack.EnergyProperty = 0;
            energyTrack2.EnergyProperty = 0;
         //   energyTrack3.EnergyProperty = 0;
            energyTrack.IncreaseProperty = 1;
            energyTrack2.IncreaseProperty = 1;
       //    energyTrack3.IncreaseProperty = 1;
            energyTrack.ActivatedProperty = false;
            energyTrack2.ActivatedProperty = false;
       //     energyTrack3.ActivatedProperty = false;

            energyTrack_amount = 0.0f;
            energyTrack2_amount = 0.0f;
            //     energyTrack3_amount = 0.0f;

            slide_state.StateProperty = false;

            firstPlay = false;
        }
        else
        {
            //Debug.Log("Running...\n");

            now_state = slide_state.StateProperty;

            if (!energyTrack.ActivatedProperty)
            {
                if (energyTrack.EnergyProperty > energyTrack_amount)
                {
                    //Debug.Log(energyTrack.EnergyProperty);
                    //Not doing anything
                    new_energyTrack_amount = energyTrack.EnergyProperty - energyTrack_amount;
                    energyTrack.EnergyProperty = new_energyTrack_amount;
                    //Debug.Log(energyTrack.EnergyProperty);
                }
            }

            //if (!energyTrack2.ActivatedProperty)
            //{
            //    if (energyTrack2.EnergyProperty > energyTrack2_amount)
            //    {
            //        new_energyTrack2_amount = energyTrack2.EnergyProperty - energyTrack2_amount;
            //        energyTrack2.EnergyProperty = new_energyTrack2_amount;
            //    }
            //}

            //if (!energyTrack3.ActivatedProperty)
            //{

            //    if (energyTrack3.EnergyProperty > energyTrack3_amount)
            //    {
            //        new_energyTrack3_amount = energyTrack3.EnergyProperty - energyTrack3_amount;
            //        energyTrack3.EnergyProperty = new_energyTrack3_amount;
            //    }
            //}
        }
    }

    private void OnDestroy()
    {
        energyTrack_amount = energyTrack.EnergyProperty;
        slide_state.StateProperty = now_state;
        //energyTrack2_amount = energyTrack2.EnergyProperty;
        //energyTrack3_amount = energyTrack3.EnergyProperty;
    }
}
