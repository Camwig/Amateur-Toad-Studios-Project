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
   private Collider2D targetObject;
    private Vector3 offset;
   public GameObject selectedObject;

    // Update is called once per frame
    void Update()

    /*This works by setting the Selected Object reference to the parent object of the Collider 
     * that’s under the mouse whenever the left mouse button is pressed down.*/
    {
        mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            targetObject = Physics2D.OverlapPoint(mousePosition);
            if(targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}
