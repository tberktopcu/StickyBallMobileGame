using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastManager : MonoBehaviour
{
    [HideInInspector]
    public Vector3 destination;

    private void Awake()
    {
        destination = transform.position;
    }

    void Update()
    {
        CalculateDestinationPosition();
    }

    void CalculateDestinationPosition()
    {
        float offset = 1;

        Vector3 point1;
        RaycastHit hit;
        Vector3 direction = new Vector3();

        if (GAMEMANAGER.singleton.inputManager.firstTouch)
        {
            direction = (TransformRawTouchInputIntoWorldPoint(GAMEMANAGER.singleton.inputManager.touch.position) - transform.position);
            direction = new Vector3(direction.x, 0, direction.z);
        }


        if (GAMEMANAGER.singleton.inputManager.touch.phase == TouchPhase.Began && !GAMEMANAGER.singleton.playerMovementManager.IsPlayerMoving())
        {
            Physics.Raycast(transform.position, direction, out hit, 400,7);
            point1 = hit.point - (Vector3.Normalize(hit.point - transform.position) * offset);
            destination = (point1 + hit.point) / 2;
            destination = new Vector3(destination.x, transform.position.y, destination.z);
        }

    }

    Vector3 TransformRawTouchInputIntoWorldPoint(Vector3 rawTouchInput)
    {
        RaycastHit hit;
        Vector3 worldPositionOnCameraPlane = Camera.main.ScreenToWorldPoint(rawTouchInput);
        
        Physics.Raycast(worldPositionOnCameraPlane, Camera.main.transform.forward, out hit, 400, 7!);
        return hit.point;
        
    }
}
