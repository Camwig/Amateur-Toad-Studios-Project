using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRoomManager : MonoBehaviour
{
    public GameObject lever;

    //--------------------------
    public GameObject slider;

    //public SliderInteractable slider;
    //--------------------------

    public ObjectPositioing these_objects;

    public GenericRoom this_room;

    public EnergyTracker energyTracker;

    public SliderState new_slide_state;

    private static bool firstPlay = true;


    void Awake()
    {
        if (firstPlay == true)
        {
            Debug.Log("Starting...\n");
            firstPlay = false;
            //new_slide_state.StateProperty = false;
            this_room.SetupState();
        }
        else
        {
            Debug.Log("Running...\n");
            //Store the angle the lever was at after exit
            lever.transform.localPosition = these_objects.gameObjects[0].transform.position;
            lever.transform.rotation = these_objects.gameObjects[0].transform.rotation;

            //--------------------------
            //slider.transform.position = these_objects.gameObjects[1].transform.position;
            //slider.transform.rotation = these_objects.gameObjects[1].transform.rotation;
            //--------------------------

            this_room.ActivateRoom(this,energyTracker.ActivatedProperty);
            this_room.SetupInitialEnergy(this, energyTracker.EnergyProperty);
        }
    }
}
