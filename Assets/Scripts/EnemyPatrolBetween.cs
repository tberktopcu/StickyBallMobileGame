using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBetween : Enemy
{
    bool patrolSwitch = false;

    private void Update()
    {
        PatrolBetween();
    }
    void PatrolBetween()
    {
        if (transform.position == pointA)
        {
            patrolSwitch = true;
        }
        if (transform.position == pointB)
        {
            patrolSwitch = false;
        }

        switch (patrolSwitch)
        {
            case true:
                transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
                break;
            case false:
                transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
                break;
        }
    }
}
