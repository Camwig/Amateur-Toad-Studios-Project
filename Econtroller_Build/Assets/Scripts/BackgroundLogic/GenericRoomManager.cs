using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRoomManager : MonoBehaviour
{
    public GameObject lever;

    public ObjectPositioing these_objects;

    public GenericRoom this_room;

    public EnergyTracker energyTracker;

    private static bool firstPlay = true;


    void Awake()
    {

        if (firstPlay == true)
        {
            Debug.Log("Starting...\n");
            firstPlay = false;

            this_room.SetupState();
        }
        else
        {
            Debug.Log("Running...\n");
            //Store the angle the lever was at after exit
            lever.transform.position = these_objects.gameObjects[0].transform.position;
            lever.transform.rotation = these_objects.gameObjects[0].transform.rotation;

            this_room.ActivateRoom(this,energyTracker.ActivatedProperty);
            this_room.SetupInitialEnergy(this, energyTracker.EnergyProperty);
        }
    }
}
