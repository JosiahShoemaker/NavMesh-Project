using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        //Check for Left Mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            //create new ray from camera at mouse position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //store whatever raycast hit
            RaycastHit hit;

            //check if the raycast hits anything
            if(Physics.Raycast(ray, out hit))
            {
                //Set destination for agent
                agent.SetDestination(hit.point);

                //Create target at hitpoint
                Instantiate(target, hit.point, Quaternion.identity);
            }
        }
    }
}
