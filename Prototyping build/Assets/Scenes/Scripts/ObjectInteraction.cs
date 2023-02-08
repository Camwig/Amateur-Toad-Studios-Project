using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

   private Vector3 mousePosition;
   //private Collider2D targetObject;
   //private Vector3 offset;
   private bool is_being_held = false;
   private float startpos_x;
   private float startpos_y;
   public GameObject selectedObject;

    // Update is called once per frame
    void Update()

    /*This works by setting the Selected Object reference to the parent object of the Collider 
     * that’s under the mouse whenever the left mouse button is pressed down.*/
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
        if (is_being_held==true)
        {
            selectedObject.gameObject.transform.localPosition = new Vector3(mousePosition.x - startpos_x, mousePosition.y - startpos_y,0);
        }
    }

    private void OnMouseDown()
    {
        startpos_x = mousePosition.x - selectedObject.transform.localPosition.x;
        startpos_y = mousePosition.y - selectedObject.transform.localPosition.y;

        is_being_held = true;
    }

    private void OnMouseUp()
    {
        is_being_held = false;
    }
}
