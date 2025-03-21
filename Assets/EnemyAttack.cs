using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time > lastAttackTime + attackCooldown)
            {
                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    Debug.Log("Musuh menyerang Player!");
                }
                lastAttackTime = Time.time;
            }
        }
    }
}