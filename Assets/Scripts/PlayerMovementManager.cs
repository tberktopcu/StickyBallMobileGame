using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveToDestinationRB(GAMEMANAGER.singleton.playerRaycastManager.destination);
    }

    void Update()
    {
        //MoveToDestinationTR(GAMEMANAGER.singleton.playerRaycastManager.destination);
    }

    void MoveToDestinationRB(Vector3 destination)
    {
        rigidbody.position = Vector3.MoveTowards(transform.position, destination, Player.speed * Time.deltaTime);
    }

    void MoveToDestinationTR(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Player.speed * Time.deltaTime);
    }

    public bool IsPlayerMoving()
    {
        if(transform.position != GAMEMANAGER.singleton.playerRaycastManager.destination)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
