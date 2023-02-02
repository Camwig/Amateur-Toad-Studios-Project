using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Based of the code from here https://gamedev.stackexchange.com/questions/197288/how-to-spawn-gameobjects-at-random-positions-in-unity
//Using this as a bit of help aswell https://stackoverflow.com/questions/871230/how-do-i-use-linq-in-monodevelop-2-0-on-os-x/875704#875704

public class FloorSpawner : MonoBehaviour
{

    //public GameObject[] floor_tiles;

    public GameObject flooring;

    public Vector3 minPos;
    public Vector3 maxPos;

    public List<GameObject> floor_list = new List<GameObject>();

    public int numRunTry;

    GameObject floor_object;
    float distance;

    int GridX = 1, GridY = 1;

    // Start is called before the first frame update
    void Start()
    {
        //floor_tiles = GameObject.FindGameObjectsWithTag("Floor");
        floor_object = Instantiate(flooring, new Vector3(0, 0, 0), Quaternion.identity);

        floor_list.Add(floor_object);

        SpawnFloors();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click\n");

            //Need to put that into game space
            Vector3 new_pos;

            new_pos.x = Mathf.Round(Input.mousePosition.x / GridX) * GridX;
            new_pos.y = Mathf.Round(Input.mousePosition.y / GridY) * GridY;


            floor_object = Instantiate(flooring, Camera.main.ScreenToWorldPoint(new Vector3(new_pos.x, new_pos.y,Camera.main.nearClipPlane)), Quaternion.identity);

            floor_list.Add(floor_object);

            //SpawnFloors();
        }
    }

    void SpawnFloors()
    {
        for(int i=0; i < numRunTry; i++)
        {
            Vector3 randomSpawnpos = new Vector3 (Random.Range(minPos.x,maxPos.x), Random.Range(minPos.y, maxPos.y),0);
            foreach(GameObject Floor in floor_list)
            {
                distance = Mathf.Sqrt(Mathf.Pow((Floor.transform.position.x - randomSpawnpos.x),2) + Mathf.Pow((Floor.transform.position.y - randomSpawnpos.y),2));
                
                if(distance < 1)
                {
                    break;
                }
                else if (distance >= 1 && floor_list.Last())
                {
                    floor_object = Instantiate(flooring, randomSpawnpos, Quaternion.identity);

                    floor_list.Add(floor_object);

                    break;
                }
            }
        }
    }
}
