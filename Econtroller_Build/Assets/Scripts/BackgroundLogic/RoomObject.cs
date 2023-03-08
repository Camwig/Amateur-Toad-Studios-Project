using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room Object", menuName = "RoomObject")]
[SerializeField]
public class RoomObject : ScriptableObject
{
    public LoadedObject[] List_of_object;
}
