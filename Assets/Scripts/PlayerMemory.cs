using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemory : MonoBehaviour
{
    public delegate void MemoryUpdate();
    public static event MemoryUpdate OnMemoryUpdate;

    public int memoryPointer = 0;
    public int memorySize = 10;
    public int count = 0;


    public Memory[] memory;

    Vector3 nextDestination;

    void Awake()
    {
        memory = new Memory[memorySize];
    }

    void Start()
    {
        OnMemoryUpdate += GAMEMANAGER.singleton.enemyPatrolCoupleManager.PassPatrolInformation;
        OnMemoryUpdate += GAMEMANAGER.singleton.enemyManager.UpdateSpawnContainer;
    }

    void Update()
    {
        if (GAMEMANAGER.singleton.playerMovementManager.IsPlayerMoving()) { return; }//w8 for till ball reaches wall

        if(nextDestination != GAMEMANAGER.singleton.playerRaycastManager.destination)
        {
            if(memoryPointer < memorySize)
            {
                memory[memoryPointer] = new Memory(GAMEMANAGER.singleton.playerRaycastManager.destination, count);
                nextDestination = memory[memoryPointer].destinationPoint;

                if (OnMemoryUpdate != null)
                {
                    OnMemoryUpdate();
                }

                memoryPointer++;
                count++;
            }
            else
            {
                memoryPointer = 0;
            }
        }
    }
}

public struct Memory
{
    public Vector3 destinationPoint;
    public int index;

    public Memory(Vector3 destinationPoint, int index)
    {
        this.destinationPoint = destinationPoint;
        this.index = index;
    }
}
