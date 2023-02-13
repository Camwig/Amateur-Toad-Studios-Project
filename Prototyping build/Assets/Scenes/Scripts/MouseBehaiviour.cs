using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaiviour : MonoBehaviour
{
    public GameObject selectedObject;
    private Vector3 mousePosition;
    private Vector3 origin_pos;
    private bool is_being_held = false;
    private SpriteRenderer sprender;
    private LineRenderer line;
    private bool got_pos = false;

    // Start is called before the first frame update
    void Start()
    {
        //is_being_held = false;
        //sprender = selectedObject.gameObject.GetComponent<SpriteRenderer>();
        sprender = selectedObject.gameObject.GetComponentInChildren<SpriteRenderer>();
        line = selectedObject.gameObject.GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            is_being_held = true;
            line.enabled = true;
            mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
            selectedObject.gameObject.transform.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            if (got_pos ==false)
            {
                origin_pos = selectedObject.gameObject.transform.localPosition;
                got_pos = true;
            }

            line.SetPosition(0,origin_pos);
            line.SetPosition(1, selectedObject.gameObject.transform.localPosition);

            //Draw a line from the current gameobject to the mouse position
        }
        else
        {
            is_being_held = false;
            got_pos = false;

            line.enabled = false;
            //Delete the line
            //Or at least make it invisible
        }

        if (is_being_held == true)
        {
            Debug.Log("Bums\n");
            sprender.enabled = true;
        }
        
        if(is_being_held == false)
        {
            sprender.enabled = false;
        }
    }
}
