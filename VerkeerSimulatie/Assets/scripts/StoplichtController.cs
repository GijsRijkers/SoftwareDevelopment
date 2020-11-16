using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class StoplichtController : MonoBehaviour
{

    public List<Waypoint> TrafficLights = new List<Waypoint>();


    public GameObject A1_1;
    public GameObject A1_2;
    public GameObject A1_3;
    public GameObject B1_1;
    public GameObject B1_2;
    public GameObject F1_1;
    public GameObject F1_2;
    public GameObject V1_1;
    public GameObject V1_2;
    public GameObject V1_3;
    public GameObject V1_4;
    public GameObject A2_1;
    public GameObject A2_2;
    public GameObject A2_3;
    public GameObject A2_4;
    public GameObject F2_1;
    public GameObject F2_2;
    public GameObject V2_1;
    public GameObject V2_2;
    public GameObject V2_3;
    public GameObject V2_4;
    public GameObject A3_1;
    public GameObject A3_2;
    public GameObject A3_3;
    public GameObject A3_4;
    public GameObject A4_1;
    public GameObject A4_2;
    public GameObject A4_3;
    public GameObject A4_4;
    public GameObject B4_1;
    public GameObject F4_1;
    public GameObject F4_2;
    public GameObject V4_1;
    public GameObject V4_2;
    public GameObject V4_3;
    public GameObject V4_4;
    public GameObject A5_1;
    public GameObject A5_2;
    public GameObject A5_3;
    public GameObject A5_4;
    public GameObject F5_1;
    public GameObject F5_2;
    public GameObject V5_1;
    public GameObject V5_2;
    public GameObject V5_3;
    public GameObject V5_4;
    public GameObject A6_1;
    public GameObject A6_2;
    public GameObject A6_3;
    public GameObject A6_4;



    



    // Start is called before the first frame update
    void Start()
    {
        TrafficLights.Add(A1_1.GetComponent<Waypoint>());
        TrafficLights.Add(A1_2.GetComponent<Waypoint>());
        TrafficLights.Add(A1_3.GetComponent<Waypoint>());
        TrafficLights.Add(B1_1.GetComponent<Waypoint>());
        TrafficLights.Add(B1_2.GetComponent<Waypoint>());
        TrafficLights.Add(F1_1.GetComponent<Waypoint>());
        TrafficLights.Add(F1_2.GetComponent<Waypoint>());
        TrafficLights.Add(V1_1.GetComponent<Waypoint>());
        TrafficLights.Add(V1_2.GetComponent<Waypoint>());
        TrafficLights.Add(V1_3.GetComponent<Waypoint>());
        TrafficLights.Add(V1_4.GetComponent<Waypoint>());
        TrafficLights.Add(A2_1.GetComponent<Waypoint>());
        TrafficLights.Add(A2_2.GetComponent<Waypoint>());
        TrafficLights.Add(A2_3.GetComponent<Waypoint>());
        TrafficLights.Add(A2_4.GetComponent<Waypoint>());
        TrafficLights.Add(F2_1.GetComponent<Waypoint>());
        TrafficLights.Add(F2_2.GetComponent<Waypoint>());
        TrafficLights.Add(V2_1.GetComponent<Waypoint>());
        TrafficLights.Add(V2_2.GetComponent<Waypoint>());
        TrafficLights.Add(V2_3.GetComponent<Waypoint>());
        TrafficLights.Add(V2_4.GetComponent<Waypoint>());
        TrafficLights.Add(A3_1.GetComponent<Waypoint>());
        TrafficLights.Add(A3_2.GetComponent<Waypoint>());
        TrafficLights.Add(A3_3.GetComponent<Waypoint>());
        TrafficLights.Add(A3_4.GetComponent<Waypoint>());
        TrafficLights.Add(A4_1.GetComponent<Waypoint>());
        TrafficLights.Add(A4_2.GetComponent<Waypoint>());
        TrafficLights.Add(A4_3.GetComponent<Waypoint>());
        TrafficLights.Add(A4_4.GetComponent<Waypoint>());
        TrafficLights.Add(B4_1.GetComponent<Waypoint>());
        TrafficLights.Add(F4_1.GetComponent<Waypoint>());
        TrafficLights.Add(F4_2.GetComponent<Waypoint>());
        TrafficLights.Add(V4_1.GetComponent<Waypoint>());
        TrafficLights.Add(V4_2.GetComponent<Waypoint>());
        TrafficLights.Add(V4_3.GetComponent<Waypoint>());
        TrafficLights.Add(V4_4.GetComponent<Waypoint>());
        TrafficLights.Add(A5_1.GetComponent<Waypoint>());
        TrafficLights.Add(A5_2.GetComponent<Waypoint>());
        TrafficLights.Add(A5_3.GetComponent<Waypoint>());
        TrafficLights.Add(A5_4.GetComponent<Waypoint>());
        TrafficLights.Add(F5_1.GetComponent<Waypoint>());
        TrafficLights.Add(F5_2.GetComponent<Waypoint>());
        TrafficLights.Add(V5_1.GetComponent<Waypoint>());
        TrafficLights.Add(V5_2.GetComponent<Waypoint>());
        TrafficLights.Add(V5_3.GetComponent<Waypoint>());
        TrafficLights.Add(V5_4.GetComponent<Waypoint>());
        TrafficLights.Add(A6_1.GetComponent<Waypoint>());
        TrafficLights.Add(A6_2.GetComponent<Waypoint>());
        TrafficLights.Add(A6_3.GetComponent<Waypoint>());
        TrafficLights.Add(A6_4.GetComponent<Waypoint>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setJson(dynamic json){
        foreach (Waypoint stoplicht in TrafficLights)
        {
            stoplicht.isRed = json[stoplicht.name] != 1;
        }
    }
}
