using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    Enemy enemy;

    public void Spawn()
    {
        GameObject gameObject = Instantiate
            (GAMEMANAGER.singleton.enemyManager.spawnContainer[0],
            GAMEMANAGER.singleton.enemyPatrolCoupleManager.patrolCouple.patrolA,
            Quaternion.identity, this.transform);


        GAMEMANAGER.singleton.enemyManager.RemoveSpawnedEnemyFromEnemyList();

        enemy = gameObject.GetComponent<Enemy>();
        
        enemy.pointA = GAMEMANAGER.singleton.enemyPatrolCoupleManager.patrolCouple.patrolA;
        enemy.pointB = GAMEMANAGER.singleton.enemyPatrolCoupleManager.patrolCouple.patrolB;


    }
}
