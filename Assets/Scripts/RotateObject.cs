using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;

    GameObject stationarySphere;

    float totalMoveDistance;
    Vector3 startingLocation;   

    // Start is called before the first frame update
    void Start()
    {
        totalMoveDistance = 10f;
        startingLocation = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceTraveled = GetDistanceTraveled();

        if (distanceTraveled > totalMoveDistance)
        {
            FlipMoveDirection();
        }
        MoveObject thisMoveObject = GetComponent<MoveObject>();
        //gameObject.transform.Translate(moveDirection * moveSpeed);
    
    }
    
    void OnTriggerEnter(Collider other)
    {
        gameObject.transform.Rotate(moveDirection * moveSpeed);
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.transform.Rotate(-moveDirection * moveSpeed);
    }



    void FlipMoveDirection()
    {
        moveDirection = -moveDirection;
    }

    float GetDistanceTraveled()
    {
        return Vector3.Distance(gameObject.transform.position, startingLocation);
    }
}

