using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{

    CarNavigationController controller;
    public Waypoint currentWaypoint;
    public Waypoint busSpawnPoint;

    private void Awake(){
        controller = GetComponent<CarNavigationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {


        if(!currentWaypoint.isRed){
            if(controller.reachedDestinatoion){
                if(currentWaypoint.isLastWaypoint){
                    if(gameObject.tag == "Bus"){
                        controller.Teleport(busSpawnPoint.GetPosition());
                        currentWaypoint = busSpawnPoint;
                    }
                    else{
                    controller.Teleport(currentWaypoint.nextWaypoint.GetPosition());
                    }
                }
                
                currentWaypoint = currentWaypoint.nextWaypoint;
                controller.SetDestination(currentWaypoint.GetPosition());
                
            }
        }
    }
}
