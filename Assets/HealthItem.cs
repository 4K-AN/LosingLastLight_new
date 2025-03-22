using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 20; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.HealPlayer(healAmount);
                Destroy(gameObject); 
            }
            else
            {
                Debug.LogError("⚠ Komponen PlayerHealth tidak ditemukan pada Player!");
            }
        }
    }
}
