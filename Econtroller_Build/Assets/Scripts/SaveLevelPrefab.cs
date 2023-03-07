using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelPrefab : MonoBehaviour
{
   public SaveLevelPrefab(LevelObjectType _type)
    {
        this.type = _type;
    }

    public LevelObjectType type;
    public GameObject prefab;
}
