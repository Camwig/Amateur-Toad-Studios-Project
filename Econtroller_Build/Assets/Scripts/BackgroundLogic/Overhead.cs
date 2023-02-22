using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Version 1 for the initial milestone

public class Overhead : MonoBehaviour
{
    //public EventHandler OnEnergyChanged;

    //Replace later with clock function
    private float time_;
    private float Overall_Energy;

    // Start is called before the first frame update
    void Start()
    {
        time_ = 0;
        Overall_Energy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check clock
       
        //How much energy consumed

        //While it is not the end of the day keep tracking the energy

        if(time_ < 100.0f)
        {
            time_ += Time.deltaTime;
            Debug.Log(Overall_Energy);
        }

    }


    public void AddEnergy(Component sender, object data)
    {
        if (data is float)
        {
            float energy = (float)data;
            Overall_Energy += energy;
            //Debug.Log("ASASHSAJBSh\n");
        }
    }


    //public void AddEnergytototal(float new_energy)
    //{
    //    Overall_Energy += new_energy;
    //    if (OnEnergyChanged != null) OnEnergyChanged(null, EventArgs.Empty);
    //}
}
