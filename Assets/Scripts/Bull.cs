using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public int Damage;
    void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            Enemy.gameObject.GetComponent<EnemyStats>().hp -= Damage;
            Destroy(gameObject);
        }
    }
}
