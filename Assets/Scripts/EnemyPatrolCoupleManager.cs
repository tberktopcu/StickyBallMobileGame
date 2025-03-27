using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolCoupleManager : MonoBehaviour
{
    public delegate void PatrolCoupleSet();
    public static event PatrolCoupleSet OnPatrolCoupleSet;

    public PatrolCouple patrolCouple;

    void Start()
    {
        patrolCouple = new PatrolCouple();
        OnPatrolCoupleSet += GAMEMANAGER.singleton.enemySpawnManager.Spawn;
    }

    public void PassPatrolInformation()
    {

        if (GAMEMANAGER.singleton.playerMemory.count < 2) {return;}

        int pointer = GAMEMANAGER.singleton.playerMemory.memoryPointer;
        int temp = pointer - 1;

        if (temp < 0)
        {
            temp = GAMEMANAGER.singleton.playerMemory.memorySize - 1;
        }

        patrolCouple = new PatrolCouple
            (GAMEMANAGER.singleton.playerMemory.memory[temp].destinationPoint, 
            GAMEMANAGER.singleton.playerMemory.memory[pointer].destinationPoint);

        if (OnPatrolCoupleSet != null)
        {
            OnPatrolCoupleSet();
        }

    }

    public struct PatrolCouple
    {
        public Vector3 patrolA;
        public Vector3 patrolB;

        public PatrolCouple(Vector3 patrolA, Vector3 patrolB)
        {
            this.patrolA = patrolA;
            this.patrolB = patrolB;
        }
    }
}
