using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelObject : MonoBehaviour
{
    public LevelObjectType type;
}

public enum LevelObjectType
{
    clock,
    lever,
    button
}   