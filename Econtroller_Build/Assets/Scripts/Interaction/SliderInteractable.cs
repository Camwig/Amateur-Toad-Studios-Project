using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderInteractable : MonoBehaviour
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
    public GameObject selectedObject;

    [Header("Events")]

    public EventSytem onSliderActivate;

    private void Start()
    {
        OriginPos = selectedObject.gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    /*This works by setting the Selected Object reference to the parent object of the Collider 
     * that’s under the mouse whenever the left mouse button is pressed down.*/
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
        if (is_being_held == true)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, mousePosition.y - newpos_y, 0);
        }

        if(selectedObject.gameObject.transform.localPosition.y >= OriginPos)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos, 0);
            onSliderActivate.Raise(this, false);
        }

        if (selectedObject.gameObject.transform.localPosition.y <= OriginPos - 1.5f)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos - 1.5f, 0);
            onSliderActivate.Raise(this, true);
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
