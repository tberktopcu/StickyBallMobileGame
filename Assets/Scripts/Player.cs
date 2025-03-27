using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  float health = 100;
    public static float speed = 50;
    public Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GAMEMANAGER.singleton.healthController.UpdateHealthBarValue(-damage);
    }
}
