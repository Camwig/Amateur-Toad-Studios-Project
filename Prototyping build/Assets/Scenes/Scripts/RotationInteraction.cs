using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInteraction : MonoBehaviour
{
    private Vector3 mousePosition;
    //private Collider2D targetObject;
    private Vector3 offset;
    public GameObject selectedObject;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        float roatationSpeed = 10f;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButton(0))
        {

            //targetObject = Physics2D.OverlapPoint(mousePosition);
            //if (targetObject)
            //{
                //selectedObject = targetObject.transform.gameObject;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //Slerping is spherically interpolating
                selectedObject.transform.rotation = Quaternion.Slerp(selectedObject.transform.rotation, rotation, roatationSpeed * Time.deltaTime);
            //}
        }
    }
}
