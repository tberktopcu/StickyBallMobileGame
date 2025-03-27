using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER singleton { get; private set; }

    public InputManager inputManager { get; private set; }
    public HealthController healthController { get; private set; }

    public PlayerMovementManager playerMovementManager { get; private set; }  
    public PlayerRaycastManager playerRaycastManager { get; private set; }
    public PlayerMemory playerMemory { get; private set; }
    public Player player { get; private set; }

    public EnemyManager enemyManager { get; private set; }
    public EnemySpawnManager enemySpawnManager { get; private set; }
    public EnemyPatrolCoupleManager enemyPatrolCoupleManager { get; private set; }
    
    public int score = 0;
    public GameObject scoreIndicator;
    public Renderer scoreRenderer { get; private set; }

    private void Awake()
    {
        singleton = this;

        scoreRenderer = scoreIndicator.GetComponent<Renderer>();

        inputManager = GetComponentInChildren<InputManager>();
        healthController = GetComponentInChildren<HealthController>();

        playerMovementManager = GetComponentInChildren<PlayerMovementManager>();
        playerRaycastManager = GetComponentInChildren<PlayerRaycastManager>();
        playerMemory = GetComponentInChildren<PlayerMemory>();
        player = GetComponentInChildren<Player>();

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemySpawnManager = GetComponentInChildren<EnemySpawnManager>();
        enemyPatrolCoupleManager  = GetComponentInChildren<EnemyPatrolCoupleManager>();
    }


    public void UpdateScore(int amount)
    {
        score += amount;
        scoreIndicator.GetComponent<TextMeshPro>().text = score.ToString();
    }

    public void Reset()
    {
        player.health = 100;
        healthController.ResetHealthBar();
        score = 0;

        enemyManager.DespawnAll();

        player.transform.position = player.startPosition;
        playerRaycastManager.destination = player.startPosition;
        playerMemory.count = 0;
        playerMemory.memoryPointer = 0;
    }
}
