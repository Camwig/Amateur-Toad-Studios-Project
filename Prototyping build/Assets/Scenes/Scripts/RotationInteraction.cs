using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInteraction : MonoBehaviour
{
    private Vector3 mousePosition;
    private Collider2D targetObject;
    private Vector3 offset;
    private bool is_being_held = false;
    private float angle;
    private enum Cardinal_points {E,S,W,N};
    Cardinal_points curr_point;
    private int power;
    private int rotation;

    public GameObject selectedObject;

    private void Start()
    {
        curr_point = Cardinal_points.E;
        power = 0;
        rotation = 0;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        float roatationSpeed = 10f;

        Vector2 direction = mousePosition - selectedObject.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Debug.Log(rotation);

        if (is_being_held == true)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Slerping is spherically interpolating
            selectedObject.transform.rotation = Quaternion.Slerp(selectedObject.transform.rotation, rotation, roatationSpeed * Time.deltaTime);
        }

        //Only increases rotation at 135 degrees

        if(angle >= 45 && angle <= -45)
        {
            if(curr_point == Cardinal_points.N)
            {
                if(rotation >= 3)
                {
                    //Never runs
                    power++;
                    rotation = 0;
                }
            }

            //if(curr_point==Cardinal_points.S)
            //{
            //    if(rotation >=-3)
            //    {
            //        //Never runs
            //        power--;
            //        rotation = 0;
            //    }
            //}

            curr_point = Cardinal_points.E;
        }

        if(angle >= -45 && angle>= -135)
        {
            if(curr_point == Cardinal_points.E)
            {
                rotation++;
            }
            //if(curr_point==Cardinal_points.W)
            //{
            //    rotation--;
            //}
            curr_point = Cardinal_points.S;
        }


        if(angle <=-135 && angle >= 135)
        {
            //Never true
            if(curr_point==Cardinal_points.S)
            {
                rotation++;
            }
            //if(curr_point==Cardinal_points.N)
            //{
            //    rotation--;
            //}
            curr_point = Cardinal_points.W;
        }

        if(angle >= 135 && angle <= 45)
        {
            if (curr_point == Cardinal_points.W)
            {
                rotation++;
            }
            //if (curr_point == Cardinal_points.E)
            //{
            //    rotation--;
            //}
            curr_point = Cardinal_points.N;
        }
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
