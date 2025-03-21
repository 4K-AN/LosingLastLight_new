using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // Tambahkan variabel untuk suara
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>(); // Pastikan ada AudioSource di GameObject
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Play sound effect ketika kena damage
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject);
    }
}