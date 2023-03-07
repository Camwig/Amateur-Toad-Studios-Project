using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObjectInfo
{
    public LevelObjectInfo(SaveLevelObject levelObject)
    {
        this.type = levelObject.type;
        this.pos = levelObject.transform.position;
        this.rot= levelObject.transform.rotation;
        this.scale= levelObject.transform.localScale;
    }

    public LevelObjectType type;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
}
