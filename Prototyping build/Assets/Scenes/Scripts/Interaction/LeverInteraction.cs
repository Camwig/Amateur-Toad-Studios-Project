
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    private Vector3 mousePosition;
    private Collider2D targetObject;
    private Vector3 offset;
    private bool is_being_held = false;
    private float angle;
    //private enum Cardinal_points { E, S, W, N };
    //Cardinal_points curr_point;
    //private int power;
   // private int rotation;

    public GameObject selectedObject;

    //private void Start()
    //{
    //    //curr_point = Cardinal_points.E;
    //    //power = 0;
    //    //rotation = 0;
    //}

void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        float roatationSpeed = 10f;

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
}
