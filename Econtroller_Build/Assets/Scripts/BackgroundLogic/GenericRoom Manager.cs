using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRoomManager : MonoBehaviour
{
    public GameObject lever;
    private static bool firstPlay = true;


    void Awake()
    {

        if (firstPlay == true)
        {
            Debug.Log("Starting...\n");
            firstPlay = false;
        }
        else
        {
            Debug.Log("Running...\n");
            //Store the angle the lever was at after exit
        }
    }
}
