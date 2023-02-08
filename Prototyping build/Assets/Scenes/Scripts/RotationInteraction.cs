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
    public GameObject selectedObject;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        float roatationSpeed = 10f;

        Vector2 direction = mousePosition - selectedObject.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (is_being_held == true)
        {
            //Need to check its actually overlapping
            //Boolean to check if its being held


            //targetObject = Physics2D.OverlapPoint(mousePosition);
            //if (targetObject)
            //{
                //selectedObject = selectedObject.transform.gameObject;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //Slerping is spherically interpolating
                selectedObject.transform.rotation = Quaternion.Slerp(selectedObject.transform.rotation, rotation, roatationSpeed * Time.deltaTime);
            //}
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
