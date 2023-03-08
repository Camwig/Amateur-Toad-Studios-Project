using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestScriptableObject", menuName = "ScriptableObjects/TestScriptableObject")]

public class ScriptableObjectsTest : ScriptableObject
{
    public string myString;
    public Vector2 pos;
    public Vector3 scale;
    public Sprite buttonImage;
    public AudioClip buttonSound;
    public UnityEngine.Events.UnityEvent buttonEvent;
}
