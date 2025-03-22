using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Atur kesehatan awal
    }

    public void HealPlayer(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Jangan melebihi batas
        }

        Debug.Log("✅ Player disembuhkan! HP sekarang: " + currentHealth);
    }
}
