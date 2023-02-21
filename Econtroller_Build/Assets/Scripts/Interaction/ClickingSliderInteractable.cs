using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingSliderInteractable : MonoBehaviour
{
    //Need to make sure it only moves along the y-axis
    //Limit it on the y-axis

    private Vector3 mousePosition;
    private float OriginPos;
    //private Collider2D targetObject;
    //private Vector3 offset;
    private bool is_being_held = false;
    // private float startpos_x;
    private float newpos_y;

    private float new_time;
    private bool check_time;
    private float origin_time;

    public GameObject selectedObject;
    enum Option {A,B,C};

    private void Start()
    {
        OriginPos = selectedObject.gameObject.transform.localPosition.y;

        check_time = false;
        new_time = 0;
        origin_time = 0;
    }

    // Update is called once per frame
    void Update()
    /*This works by setting the Selected Object reference to the parent object of the Collider 
     * that’s under the mouse whenever the left mouse button is pressed down.*/
    {
        if(check_time == true)
        {
            //origin_time = Time.deltaTime;
            if (new_time >= origin_time + 0.05f)
            {
                check_time = false;
                new_time = 0;
                origin_time = 0;
            }
            else
            {
                new_time += Time.deltaTime;
            }
        }
        else if(check_time == false)
        {
            mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
            if (is_being_held == true)
            {
                selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, mousePosition.y - newpos_y, 0);
            }

            if (selectedObject.gameObject.transform.localPosition.y >= OriginPos)
            {
                selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos, 0);
            }

            //Need to have it stop at certain points defined between two diffrent heights

            if (selectedObject.gameObject.transform.localPosition.y <= OriginPos - 3.0f)
            {
                selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos - 3.0f, 0);
            }

            if (selectedObject.gameObject.transform.localPosition.y <= OriginPos - 1.5f && selectedObject.gameObject.transform.localPosition.y >= OriginPos - 1.6f)
            {
                check_time = true;
                origin_time = Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        //startpos_x = mousePosition.x - selectedObject.transform.localPosition.x;
        newpos_y = mousePosition.y - selectedObject.transform.localPosition.y;

        is_being_held = true;
    }

    private void OnMouseUp()
    {
        is_being_held = false;
    }
}
