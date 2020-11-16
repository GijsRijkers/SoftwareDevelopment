using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Waypoint SpawnPoint;
    public int carsToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn(){
        if(SpawnPoint != null){
            int count = 0;
            while(count < carsToSpawn){
                GameObject obj = Instantiate(carPrefab);
                obj.GetComponent<WaypointNavigator>().currentWaypoint = SpawnPoint.nextWaypoint;
                obj.transform.position = SpawnPoint.transform.position;
                obj.transform.rotation = SpawnPoint.transform.rotation;

                yield return new WaitForSeconds(5);

                count++;
            }
        }
    }
    

    
}
