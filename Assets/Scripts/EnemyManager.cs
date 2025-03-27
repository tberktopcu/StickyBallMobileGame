using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] prefabContainer;
    public List<GameObject> spawnContainer;

    void Awake()
    {
        for (int i = 0; i < 1; i++)
        {
            spawnContainer.Add(prefabContainer[Random.Range(0,prefabContainer.Length)]);
        }
        


        //initialize type
        for (int i = 0; i < prefabContainer.Length; i++)
        {
            prefabContainer[i].GetComponent<Enemy>().type = i;
        }
    }

    public void DespawnAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Enemy>())
            {
                transform.GetChild(i).GetComponent<Enemy>().DestroyMe();
            }
            
        }
    }

    public void UpdateSpawnContainer()
    {
        spawnContainer.Add(prefabContainer[Random.Range(0,prefabContainer.Length)]);
        print("NextBall:  " + spawnContainer[0].name);
        GAMEMANAGER.singleton.healthController.UpdateHealthBarColor(spawnContainer[0].GetComponent<Enemy>().color);
        GAMEMANAGER.singleton.scoreRenderer.material.SetColor("_GlowColor", spawnContainer[0].GetComponent<Enemy>().color * 10);
    }

    public void RemoveSpawnedEnemyFromEnemyList()
    {
        spawnContainer.RemoveAt(0);
    }
}
