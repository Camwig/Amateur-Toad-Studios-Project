using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullieInteraction : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool is_being_held = false;
    private float startpos_y;
    private float Initial_y;
    public GameObject selectedObject;

    private void Start()
    {
        Initial_y = selectedObject.gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Need it to naturally move back until it reaches the original point
        //Startingpoint and the current point 

        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        if (is_being_held == true)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, mousePosition.y - startpos_y, 0);
        }
        else
        {
            //Cant use while loops in update
            float new_y = Initial_y - selectedObject.gameObject.transform.localPosition.y;
            if (selectedObject.gameObject.transform.localPosition.y < Initial_y)
            {
                selectedObject.gameObject.transform.localPosition += new Vector3(0, 0.01f, 0);
            }
        }

        if (selectedObject.gameObject.transform.localPosition.y >= Initial_y)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, Initial_y, 0);
        }

        if (selectedObject.gameObject.transform.localPosition.y <= -1.5f)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, -1.5f, 0);
        }
    }

    private void OnMouseDown()
    {
        startpos_y = mousePosition.y - selectedObject.transform.localPosition.y;
        is_being_held = true;
    }

    private void OnMouseUp()
    {
        is_being_held = false;
    }
}
