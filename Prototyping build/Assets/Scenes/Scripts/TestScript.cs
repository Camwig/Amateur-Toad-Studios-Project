using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        GridSystem grid = new GridSystem(4, 2, 10f);
    }
}
