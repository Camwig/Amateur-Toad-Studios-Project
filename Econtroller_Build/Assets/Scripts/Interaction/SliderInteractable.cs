using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    //public GameObject selectedObject;

    [Header("Events")]

    private EventSytem onSliderActivate;

    private void Start()
    {
        OriginPos = this.gameObject.transform.localPosition.y;

        //EventSytem new_event = new EventSytem();
        //Need to load it as a script asset
        //onSliderActivate = (EventSytem)Resources.Load("Assets/Scenes/Data/Events/ProductRateRaised.asset");
        onSliderActivate = Resources.Load<EventSytem>("ProductRateRaised");
        //if(onSliderActivate == null)
        //{
        //    int i = 0;
        //}
        //EventSytem.CreateInstance("Room Activate.asset");
        //AssetDatabase.CreateAsset(new_event, "Assets/Scenes/Data/Events/MyEvent");
    }

    // Update is called once per frame
    void Update()
    /*This works by setting the Selected Object reference to the parent object of the Collider 
     * that’s under the mouse whenever the left mouse button is pressed down.*/
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
        if (is_being_held == true)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, mousePosition.y - newpos_y, 0);
        }

        if(this.gameObject.transform.localPosition.y >= OriginPos)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, OriginPos, 0);
            onSliderActivate.Raise(this, false);
        }

        if (this.gameObject.transform.localPosition.y <= OriginPos - 1.5f)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, OriginPos - 1.5f, 0);
            onSliderActivate.Raise(this, true);
        }
    }

    private void OnMouseDown()
    {
        //startpos_x = mousePosition.x - selectedObject.transform.localPosition.x;
        newpos_y = mousePosition.y - this.transform.localPosition.y;

        is_being_held = true;
    }

    private void OnMouseUp()
    {
        is_being_held = false;
    }
}
