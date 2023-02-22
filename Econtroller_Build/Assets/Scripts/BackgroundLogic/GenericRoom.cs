using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenericRoom : MonoBehaviour
{
    public float Energy;
    enum Room_state {Tracking_energy,Inactive,Ending_tracking};
    private Room_state curr_state;


    public float Rate_of_production;
    public float Energy_consumption;

    [Header("Events")]

    public EventSytem onEnergyChanged;

    // Start is called before the first frame update
    void Start()
    {
        curr_state = Room_state.Ending_tracking;
        Energy = 10;
        Setting_factors(10.0f, 5.0f);
    }

    public void Setting_factors(float New_rate, float New_Consumption)
    {
        Rate_of_production = New_rate;
        Energy_consumption = New_Consumption;
    }

    public void ActivateRoom(bool on_off)
    {
        if (on_off == true)
        {
            curr_state = Room_state.Tracking_energy;
        }
        else if(on_off==false)
        {
            if(curr_state == Room_state.Tracking_energy)
            {
                curr_state = Room_state.Ending_tracking;
            }
        }
    }

    public float GiveEnergy(float value)
    {
        return value;
    }

    private void IncreasseEnergy()
    {
        Energy += 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(curr_state)
        {
            case Room_state.Tracking_energy:
                //Increase energy according to calculation
                break;
            case Room_state.Ending_tracking:
                onEnergyChanged.Raise(this,Energy);
                //Stop the track of energy and pass it to the overhead
                break;
            case Room_state.Inactive:
                //Idle
                break;
        }
    }
}
