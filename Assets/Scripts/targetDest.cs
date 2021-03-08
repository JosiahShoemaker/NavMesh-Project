using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class targetDest : MonoBehaviour
{
     //agent
    public NavMeshAgent agent;
    //position of target
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    void SetDestination()
    {
        // position to vector3
        Vector3 targetVector = target.transform.position;
        //agent.SetDestination(Vector3)
        agent.SetDestination(targetVector);
    }
}


