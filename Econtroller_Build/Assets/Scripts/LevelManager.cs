using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameLevel gameLevel;
    [SerializeField]
    private List<SaveLevelPrefab> prefabList = new List<SaveLevelPrefab>();

    bool boolean = false;

    private void Update()
    {
        if (boolean == false) 
        {
            SaveLevel();
            LoadCurrentLevel();
        }
    }

    private void UpdatePrefabList()
    {

    }

    private void SaveLevel()
    {
        gameLevel.ClearList();

        SaveLevelObject[] levelObjects = FindObjectsOfType<SaveLevelObject>();
        foreach(SaveLevelObject levelObject in levelObjects)
        { 
            gameLevel.AddLevelObjectInfo(levelObject);
        }

        UnityEditor.EditorUtility.SetDirty(gameLevel);
    }

    private void LoadCurrentLevel()
    {
        gameLevel.ClearList();
        foreach (LevelObjectInfo levelObject in gameLevel.levelObjectList)
        {


            GameObject prefab = null;
            foreach (SaveLevelPrefab levelPrefab in prefabList)
            {
                if (levelObject.type == levelPrefab.type)
                {
                    prefab = levelPrefab.prefab;
                    break;
                }
            }

            if(prefab == null)
            {
                continue;
            }

            GameObject newInstance = Instantiate(prefab);
            newInstance.transform.position = levelObject.pos;
            newInstance.transform.rotation = levelObject.rot;
            newInstance.transform.localScale = levelObject.scale;

        }
    }

    public void LoadLevel(GameLevel level)
    {
        this.gameLevel = level;
        LoadCurrentLevel();
    }

    private void ClearLevel()
    {
        SaveLevelObject[] levelObjects = FindObjectsOfType<SaveLevelObject>();
        foreach(SaveLevelObject levelObject in levelObjects)
        {
            if(levelObject == null) continue;

            if (Application.isEditor)
            {
                DestroyImmediate(levelObject.gameObject);
            }
            else Destroy(levelObject.gameObject);
        }
    }
}
