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

    private enum slide_state {Down,Up,Down_active,Up_active,None};
    private slide_state curr_state;

    public ObjectPositioing these_objects;

    [SerializeField]
    private SliderState slider_state_;

    public GameObject selectedObject;

    //private bool on_off;
    private bool on_off2;

    [Header("Events")]

    public EventSytem onSliderActivate;

    private void Start()
    {
        OriginPos = selectedObject.gameObject.transform.localPosition.y;

        //EventSytem new_event = new EventSytem();
        //Need to load it as a script asset
        //onSliderActivate = (EventSytem)Resources.Load("Assets/Scenes/Data/Events/ProductRateRaised.asset");
        //onSliderActivate = Resources.Load<EventSytem>("ProductRateRaised");
        //if (onSliderActivate == null)
        //{
        //    int i = 0;
        //}

        if(slider_state_.StateProperty == false)
        {
            //curr_state = slide_state.Up_active;
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos, 0);
        }
        
        if(slider_state_.StateProperty == true)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos - 1.5f, 0);
        }

        curr_state = slide_state.None;
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
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, mousePosition.y - newpos_y, 0);
        }

        if(selectedObject.gameObject.transform.localPosition.y < OriginPos && selectedObject.gameObject.transform.localPosition.y > OriginPos - 1.5f)
        {
            curr_state = slide_state.None;
        }

        if(selectedObject.gameObject.transform.localPosition.y >= OriginPos)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos, 0);
            if (curr_state == slide_state.None)
            {
                curr_state = slide_state.Up;
            }
        }

        if (selectedObject.gameObject.transform.localPosition.y <= OriginPos - 1.5f)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(selectedObject.gameObject.transform.localPosition.x, OriginPos - 1.5f, 0);
            if (curr_state == slide_state.None)
            {
                curr_state = slide_state.Down;
            }
        }

        CheckState();
    }

    private void CheckState()
    {
        if(curr_state == slide_state.Up)
        {
            onSliderActivate.Raise(this, false);
            on_off2 = false;
            curr_state = slide_state.Up_active;
        }
        else if(curr_state == slide_state.Down)
        {
            onSliderActivate.Raise(this, true);
            on_off2 = true;
            curr_state = slide_state.Down_active;
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

    private void OnDestroy()
    {
        //these_objects.gameObjects[1].transform.position = new Vector3(selectedObject.transform.position.x, OriginPos, 0);
        these_objects.gameObjects[1].transform.position = selectedObject.transform.position;
        slider_state_.StateProperty = on_off2;
        //these_objects.gameObjects[1].transform.rotation = this.transform.rotation;
    }
}
