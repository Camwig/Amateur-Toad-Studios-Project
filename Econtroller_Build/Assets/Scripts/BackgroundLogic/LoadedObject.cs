using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loadable Object", menuName = "LoadableObject")]
[SerializeField]
public class LoadedObject : ScriptableObject
{
    public Vector3 Position;
    public GameObject LoadedPrefab;
}
