
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    private Vector3 mousePosition;
    private Collider2D targetObject;
    private Vector3 offset;
    private bool is_being_held = false;
    private static float angle;
    private float roatationSpeed;

    private static float new_angle;
    //private enum Cardinal_points { E, S, W, N };
    //Cardinal_points curr_point;
    //private int power;
    // private int rotation;

    public ObjectPositioing these_objects;

    public GameObject selectedObject;

    [Header("Events")]

    public EventSytem onLeverActivate;

    private void Start()
    {
        //curr_point = Cardinal_points.E;
        //power = 0;
        //rotation = 0;
        roatationSpeed = FrictionSpeed.LeverSpeed;

        //selectedObject.transform.localPosition = these_objects.gameObjects[0].transform.localPosition;
        //selectedObject.transform.rotation = these_objects.gameObjects[0].transform.rotation;
        //selectedObject.transform.localRotation = these_objects.gameObjects[0].transform.localRotation;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        Vector2 direction = mousePosition - selectedObject.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //angle = Mathf.Clamp(angle, 30, 330);

        //Clamps it between certain angles
        //annoying that it isnt in the same format
        //Have to remeber this 
        if ((angle > 30))
        {
            angle = 30;
        }

        if (angle < -30)
        {
            angle = 330;
        }

        //Debug.Log(power);

        //
        Quaternion old_rotate = selectedObject.transform.rotation;


        if (is_being_held == true)
        {

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Slerping is spherically interpolating
            selectedObject.transform.rotation = Quaternion.Slerp(selectedObject.transform.rotation, rotation, roatationSpeed * Time.deltaTime);

            //
            //if(selectedObject.transform.rotation.z >= 330 && selectedObject.transform.rotation.z >= 30)
            //{
            //    //Never runs
            //    selectedObject.transform.rotation = old_rotate;
            //}
            //

            if (angle >= 20)
            {
                onLeverActivate.Raise(this, true);
            }
            else
            {
                onLeverActivate.Raise(this, false);
            }
        }

        //Only increases rotation at 135 degrees
    }

    private void OnMouseDown()
    {
        is_being_held = true;
    }

    private void OnMouseUp()
    {
        is_being_held = false;
    }

    private void OnDestroy()
    {
        //these_objects.gameObjects[0].transform.localPosition = selectedObject.transform.localPosition;
        these_objects.gameObjects[0].transform.rotation = selectedObject.transform.rotation;
    }
}
