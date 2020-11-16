using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;
    public string name;
    public bool isLastWaypoint;
    public bool isStoplicht;
    public bool isRed;

    [Range(0f, 5f)]
    public float width = 0.05f;

    public Vector3 GetPosition(){
        Vector3 minBound = transform.position + transform.right * width /2f;
        Vector3 maxBound = transform.position - transform.right * width /2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 0.01f));
    }

    void Update(){
        Color red = new Color(1, 0, 0);
        Color green = new Color(0, 1, 0);


        if(isStoplicht){
        this.transform.GetChild(0).transform.position = transform.position + new Vector3(0,0,-0.1f);

            if (isRed){
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = red;
            }
            else{
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = green;
            }
        }
    }    
}
