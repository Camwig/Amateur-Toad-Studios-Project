using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        //Debug.Log(width + "" + height);
        for (int x =0; x < gridArray.GetLength(0); x++)
        {
            for (int y=0; y<gridArray.GetLength(1); y++)
            {
                //Debug.Log(x + " " + y);
                CreateWorldText(null,gridArray[x,y].ToString(), GetWorldPosition(x,y),20,Color.white, TextAnchor.MiddleCenter, TextAlignment.Center,1);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);                
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width,height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x,int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    //private static TextMesh CreateWorldText(string text, Transform parent =null, Vector3 localPosition = default(Vector3),int fontSize = 40, Color color, TextAnchor textAnchor , TextAlignment textAlignment, int sortingOrder)
    //{
    //    if (color == null) color = Color.white;
    //    return CreateWorldText(parent,text,localPosition,fontSize,(Color)color,textAnchor,textAlignment,sortingOrder);
    //}


    private static TextMesh CreateWorldText(Transform parent, string text,Vector3 localPosition,int fontSize,Color colour,TextAnchor textAnchor, TextAlignment textAlignment,int sortingOrder)
    {
        GameObject gameobject = new GameObject("World Text", typeof(TextMesh));
        Transform transform = gameobject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameobject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = colour;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;

    }
}
