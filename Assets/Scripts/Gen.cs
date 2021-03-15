using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gen : MonoBehaviour
{
    public int gap;
    public Vector2 gridSize;
    public float heightFluct = 1.5f;
    public GameObject player;
    public GameObject[] objectsToSpawn;
    GameObject clonePlayer;
    private GameObject[] objectsCurrSpawned;
    bool playerSpawned = false;
    Vector3 spawnLocation = Vector3.zero;
    public NavMeshSurface surf;
    // Start is called before the first frame update
    void Start()
    {
        objectsCurrSpawned = new GameObject[(int)(gridSize.x * gridSize.y)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (playerSpawned)
            { Destroy(clonePlayer);
                playerSpawned = false;
            }

            GenerateObjects();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            surf.BuildNavMesh();
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
    //
    void RemoveObj(int indexCount)
    {
        if (objectsCurrSpawned[indexCount])
        {
            Destroy(objectsCurrSpawned[indexCount]);
        }
    }
    //
    private GameObject SpawnObj(Vector3 spawnLocation)
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        GameObject chosenObj = objectsToSpawn[randomIndex];
        if (chosenObj.name == "Empty" && !playerSpawned)
        {
            clonePlayer = Instantiate(player, spawnLocation, Quaternion.identity);
            playerSpawned = true;
        }

        GameObject ObjClone = Instantiate(chosenObj, spawnLocation, Quaternion.identity);

        ObjClone.transform.localScale = ObjClone.transform.localScale + (Vector3.up * Random.Range(-heightFluct / 2, heightFluct));

        return ObjClone;
    }
}
     