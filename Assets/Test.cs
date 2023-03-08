using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private ScriptableObjectsTest scriptableObjectsTest;

    private void Start()
    {
        Debug.Log(scriptableObjectsTest.myString);
    }
}
