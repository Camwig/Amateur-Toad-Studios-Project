using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenericRoom : MonoBehaviour
{
    public float Energy;
    enum Room_state {Tracking_energy,Inactive,Ending_tracking};
    private Room_state curr_state;
    private string string_text;
    private int IncreaseProduct;


    public float Rate_of_production;
    public float Energy_consumption;

    public Text textelement;

    [Header("Events")]

    public EventSytem onEnergyChanged;

    // Start is called before the first frame update
    void Start()
    {
        curr_state = Room_state.Inactive;
        Energy = 0;
        Setting_factors(10.0f, 5.0f);
        string_text = "Default";
        IncreaseProduct = 1;
    }

    public void Setting_factors(float New_rate, float New_Consumption)
    {
        Rate_of_production = New_rate;
        Energy_consumption = New_Consumption;
    }

    public void ActivateRoom(Component sender, object data)
    {
        if (data is bool)
        {
            bool on_off = (bool)data;

            if (on_off == true)
            {
                curr_state = Room_state.Tracking_energy;
            }
            else if (on_off == false)
            {
                if (curr_state == Room_state.Tracking_energy)
                {
                    curr_state = Room_state.Ending_tracking;
                }
            }
        }
    }

    public void IncreaseProduction(Component sender, object data)
    {
        if (data is bool)
        {
            bool on_off = (bool)data;

            if(on_off == true)
            {
                IncreaseProduct = 10;
            }
            else
            {
                IncreaseProduct = 1;
            }
        }
    }

    public float GiveEnergy(float value)
    {
        return value;
    }

    private void IncreasseEnergy()
    {
        Energy += 0.1f * IncreaseProduct;
    }

    // Update is called once per frame
    void Update()
    {
        string_text = "Room Energy : " + Energy.ToString();
        textelement.text = string_text;

        switch (curr_state)
        {
            case Room_state.Tracking_energy:
                //Increase energy according to calculation
                IncreasseEnergy();
                //Debug.Log(Energy);
                break;
            case Room_state.Ending_tracking:
                onEnergyChanged.Raise(this,Energy);
                Energy = 0;
                curr_state = Room_state.Inactive;
                //Stop the track of energy and pass it to the overhead
                break;
            case Room_state.Inactive:
                //Idle
                break;
        }
    }
}
