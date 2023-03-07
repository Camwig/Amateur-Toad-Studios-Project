
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameLevel", menuName = "NewGameLevel")]

public class GameLevel : ScriptableObject
{
    [SerializeField]
    public List<LevelObjectInfo> levelObjectList;

   // public UnityEngine.Events.UnityEvent buttonEvent;

    public void ClearList()
    {
       levelObjectList.Clear();
    }

    public void AddLevelObjectInfo(SaveLevelObject Object)
    {
        LevelObjectInfo LevelObjectinfo = new LevelObjectInfo(Object);
        levelObjectList.Add(LevelObjectinfo);
    }

}
