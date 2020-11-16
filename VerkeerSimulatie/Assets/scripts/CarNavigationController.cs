using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigationController : MonoBehaviour
{
    
    private Rigidbody2D rb;    
    public Transform transform;  
    public float accelerationPower = 4f;   
    public float steeringPower = 5f;   
    public float stopDistance = 0.4f;
    public Vector3 destination;
    public float displayAngle;  

    

    public bool reachedDestinatoion;
    public bool waitingAtLight;
    float steeringAmount, speed, direction;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 destinationDirection = (destination - transform.position);      
        float destinationDistance = destinationDirection.magnitude;
        destinationDirection.z = 0;
        
        if (destinationDistance >= stopDistance && !waitingAtLight){
            reachedDestinatoion = false;
          
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, destinationDirection);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * steeringPower);
            rb.AddRelativeForce(Vector2.up * accelerationPower); 

        }
        else if (destinationDistance <= stopDistance){                      
            reachedDestinatoion = true;
        }  
    
    }

    public void SetDestination(Vector2 destination){
        this.destination = destination;
        reachedDestinatoion = false;
    }

    public void Teleport(Vector2 destination){
        rb.position = destination;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col is CapsuleCollider2D){
            waitingAtLight = true;
        }           
    }

    void OnTriggerExit2D(Collider2D col){     
        StartCoroutine(DriveAgain(2));      
    }

    IEnumerator DriveAgain(float time){
        yield return new WaitForSeconds(time);

        waitingAtLight = false;
    }

    

    
}
