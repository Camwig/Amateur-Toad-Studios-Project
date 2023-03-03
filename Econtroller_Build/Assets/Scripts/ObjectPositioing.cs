using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Positions", menuName = "ObjectPositions")]
[SerializeField]
public class ObjectPositioing : ScriptableObject
{
    public List<GameObject> gameObjects = new List<GameObject>();
}
