using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private GridSystem grid;
    [SerializeField] private Transform testTransform;

    private void Start()
    {
        /*18,10*/
        grid = new GridSystem(18, 10, 2f, new Vector3(-9,-5));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 new_vector;
            new_vector = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            grid.SetThisValue(GetMouseWorldPosition(), 75);

        }

        if(Input.GetMouseButtonDown(0))
        {
            grid.GetXY(GetMouseWorldPosition(), out int x, out int y);
            Instantiate(testTransform,grid.GetWorldPosition(x,y), Quaternion.identity);
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionZ(Input.mousePosition, Camera.main);
        vec.z = 0.0f;
        return vec;
    }

    private static Vector3 GetMouseWorldPositionZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
