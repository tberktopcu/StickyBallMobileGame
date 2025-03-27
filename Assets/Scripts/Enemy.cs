using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    public float speed;
    public float damage;
    public float delayBeforeMove;

    public int type;
    public int patrolBehaviour;
    public int bounceLimit;

    public Color color;

    private void Awake()
    {
    }

    void Start()
    {
        if (!gameObject.GetComponent<EnemyPatrolBetween>())
        {
            EnemyPatrolBetween enemyPatrolBetween = gameObject.AddComponent<EnemyPatrolBetween>();

            enemyPatrolBetween.pointA = pointA;
            enemyPatrolBetween.pointB = pointB;

            enemyPatrolBetween.speed = speed;
            enemyPatrolBetween.damage = damage;

        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
