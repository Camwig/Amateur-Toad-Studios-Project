using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 OriginPos;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    private Transform transform;

    public GridSystem(int width, int height, float cellSize, Vector3 OriginPos)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.OriginPos = OriginPos;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        //Used to offest the grid to the upper left hand corner

        //Currently the half the width and the height of the camera view port

        //Base view size for the camera is 4 width and 2 height

        //Shouldnt matter too much later as well have a set size we will expnad as we go later
        int diffrence = 0;
        int diffrence2 = 0;

        //Debug.Log(width + "" + height);
        for (int y =0; y < gridArray.GetLength(1); y++)
        {
            for (int x=0; x<gridArray.GetLength(0); x++)
            {
                //Debug.Log(x + " " + y);
                //Need to move it to the camera space aka reduce the size of the grid
                debugTextArray[x,y] = CreateWorldText(null,(x + ", " + y)/*gridArray[x,y].ToString()*/, (GetWorldPosition(x - diffrence, y - diffrence2) + new Vector3(cellSize,cellSize)*0.5f),5,Color.white, TextAnchor.MiddleCenter, TextAlignment.Center,1);
                Debug.DrawLine(GetWorldPosition((x- diffrence), (y - diffrence2)), GetWorldPosition((x - diffrence), (y - diffrence2) + 1), Color.white, 100f);                
                Debug.DrawLine(GetWorldPosition((x - diffrence), (y - diffrence2)), GetWorldPosition((x - diffrence) + 1, (y - diffrence2)),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(-diffrence, height - diffrence2), GetWorldPosition(width- diffrence, height- diffrence2), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width - diffrence, -diffrence2), GetWorldPosition(width- diffrence, height- diffrence2), Color.white, 100f);

        //SetValue(2, 1, 53);
    }

    //public GridObject(Grid)

    public void SetTransform(Transform transform)
    {
        this.transform = transform;
    }

    public void ClearTransform()
    {
        transform = null;
    }

    public bool CanBuild()
    {
        return transform == null;
    }

    public Vector3 GetWorldPosition(int x,int y)
    {
        return new Vector3(x, y) * cellSize + OriginPos;
    }

    public void  GetXY(Vector3 worldPosition, out int x ,out int y)
    {
        x = Mathf.FloorToInt((worldPosition - OriginPos).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - OriginPos).y / cellSize);
    }

    public void SetValue(int x,int y,int value)
    {
        if(x >=0 && y >=0 && x < width && y <height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetThisValue(Vector3 worldPosition,int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
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
