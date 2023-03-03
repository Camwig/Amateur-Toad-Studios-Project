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

    //[Header("Layout")]

    //public RoomObject RoomObject_1;

    [Header("Events")]

    public EventSytem onEnergyChanged;

    public EventSytem onActivation;

    public EventSytem UpdateProductionRate;

    // Start is called before the first frame update
    void Start()
    {
        //Energy = 0;
        Setting_factors(10.0f, 5.0f);
        string_text = "Default";
        IncreaseProduct = 1;

        //for(int i=0; i< RoomObject_1.List_of_object.Length;i++)
        //{
        //    Instantiate(RoomObject_1.List_of_object[i].LoadedPrefab, new Vector3(RoomObject_1.List_of_object[i].Position.x, RoomObject_1.List_of_object[i].Position.y, 0), Quaternion.identity, transform);
        //}
    }

    private void Awake()
    {
        UpdateProductionRate.Raise(this, IncreaseProduct);
    }

    public void Setting_factors(float New_rate, float New_Consumption)
    {
        Rate_of_production = New_rate;
        Energy_consumption = New_Consumption;
    }

    public void SetupState()
    {
        curr_state = Room_state.Inactive;
        Energy = 0;
    }

    public void SetupInitialEnergy(Component sender, object data)
    {
       if(data is float)
        {
            Energy = (float)data;
        }
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
            UpdateProductionRate.Raise(this, IncreaseProduct);
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

        //UpdateProductionRate.Raise(this, IncreaseProduct);

        switch (curr_state)
        {
            case Room_state.Tracking_energy:
                //Increase energy according to calculation
                IncreasseEnergy();
                onEnergyChanged.Raise(this, Energy);
                onActivation.Raise(this, true);
                //Debug.Log(Energy);
                break;
            case Room_state.Ending_tracking:
                //onEnergyChanged.Raise(this,Energy);
                onActivation.Raise(this, false);
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
