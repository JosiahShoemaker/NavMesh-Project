using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour
{
    public int gap;
    public Vector2 gridSize;
    public float heightFluct = 1.5f;

    public GameObject[] objectsToSpawn;
    private GameObject[] objectsCurrSpawned;

    Vector3 spawnLocation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        objectsCurrSpawned = new GameObject[(int)(gridSize.x * gridSize.y)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GenerateObjects();
        }
        //instantiate(whatObj, vector3, rotations?)
    }
    void GenerateObjects()
    {
        float rowDistanceFromCenter = (gridSize.x * gap) / 2;
        float columnDistanceFromCenter = (gridSize.y * gap) / 2;

        int indexCount = 0;

        for (float x = -rowDistanceFromCenter; x < rowDistanceFromCenter; x += gap)
        {
            for (float z = -columnDistanceFromCenter; z < columnDistanceFromCenter; z += gap)
            {
                RemoveObj(indexCount);
                spawnLocation.z = z;
                spawnLocation.x = x;
                objectsCurrSpawned[indexCount] = SpawnObj (spawnLocation);
                indexCount++;
            }
        }
    }

    void RemoveObj(int indexCount)
    {
        if (objectsCurrSpawned[indexCount])
        {
            Destroy(objectsCurrSpawned[indexCount]);
        }
    }

    private GameObject SpawnObj(Vector3 spawnLocation)
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        GameObject chosenObj = objectsToSpawn[randomIndex];
        GameObject ObjClone = Instantiate(chosenObj, spawnLocation, Quaternion.identity);

        ObjClone.transform.localScale = ObjClone.transform.localScale + (Vector3.up* Random.Range(-heightFluct/2, heightFluct));
        return ObjClone;
    }
}
     