using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaiviour : MonoBehaviour
{
    public GameObject selectedObject;
    private Vector3 mousePosition;
    private Vector3 origin_pos;
    private Vector3 offset;
    private SpriteRenderer sprender;
    private LineRenderer line;
    private bool got_pos = false;

    private Collider2D targetObject;

    // Start is called before the first frame update
    void Start()
    {

        Color c1 = Color.cyan;

        //is_being_held = false;
        //sprender = selectedObject.gameObject.GetComponent<SpriteRenderer>();
        sprender = selectedObject.gameObject.GetComponentInChildren<SpriteRenderer>();
        sprender.enabled = false;
        line = selectedObject.gameObject.GetComponentInChildren<LineRenderer>();
        line.sortingOrder = 2;

        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor= c1;
        line.endColor= c1;

        targetObject = null;

        offset = new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            sprender.enabled = true;
            //is_being_held = true;
            mousePosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));
            selectedObject.gameObject.transform.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            if (got_pos == false)
            {
                targetObject = Physics2D.OverlapPoint(mousePosition);
                //offset = new Vector3(0, 0, 1);
                //offset = mousePosition - targetObject.transform.position;
                //origin_pos = targetObject.transform.position + offset;
                //origin_pos = selectedObject.gameObject.transform.localPosition;

                offset.x = mousePosition.x - targetObject.transform.position.x;
                offset.y = mousePosition.y - targetObject.transform.position.y;
                //offset = mousePosition - targetObject.transform.position;

                got_pos = true;
            }

            if (targetObject != null)
            {
                line.enabled = true;

                //Offset will have to be comparative to where the mouse clicked it
                /*Vector3 offset = targetObject.transform.position - mousePosition;*/
                //offset = mousePosition - targetObject.transform.position;
                origin_pos = new Vector3 (targetObject.transform.position.x /*+ offset.x*/, targetObject.transform.position.y /*+ offset.y*/,1);
                line.SetPosition(0, origin_pos);
                line.SetPosition(1, selectedObject.gameObject.transform.localPosition);
            }

            //Draw a line from the current gameobject to the mouse position
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            //is_being_held = false;
            sprender.enabled = false;
            got_pos = false;
            line.enabled = false;
            targetObject = null;
            origin_pos = new Vector3(0, 0, 0);

            //Delete the line
            //Or at least make it invisible
        }

        //if (is_being_held == true)
        //{
        //    //Debug.Log("Bums\n");
        //    sprender.enabled = true;
        //}
        
        //if(is_being_held == false)
        //{
        //    sprender.enabled = false;
        //}
    }
}
