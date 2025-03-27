using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Enemy>())
        {
            if(this.GetComponentInParent<Enemy>().type == other.GetComponentInParent<Enemy>().type)
            {
                GAMEMANAGER.singleton.UpdateScore(10);
                this.GetComponentInParent<Enemy>().DestroyMe();
            }
        }

        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().TakeDamage(this.GetComponentInParent<Enemy>().damage);
            this.GetComponentInParent<Enemy>().DestroyMe();
        }

    }
}
