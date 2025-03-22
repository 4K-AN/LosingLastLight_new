using UnityEngine;

public class Mana : MonoBehaviour
{
    public int maxMana = 100;
    private float currentMana;

    // Tambahkan variabel untuk suara
    public AudioClip useManaSound;
    private AudioSource audioSource;

    void Start()
    {
        currentMana = maxMana;
        audioSource = GetComponent<AudioSource>(); // Pastikan ada AudioSource di GameObject
        InvokeRepeating("DecreaseManaOverTime", 0.5f, 0.5f); // Kurangi mana setiap 0.5 detik
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;

        // Play sound effect ketika mana digunakan
        if (audioSource != null && useManaSound != null)
        {
            audioSource.PlayOneShot(useManaSound);
        }

        if (currentMana <= 0)
        {
            OutOfMana();
        }
    }

    void DecreaseManaOverTime()
    {
        if (currentMana > 0)
        {
            currentMana -= 0.5f; // Sesuaikan jumlah pengurangan jika diperlukan
            Debug.Log("Mana berkurang: " + currentMana);
        }

        if (currentMana <= 0)
        {
            OutOfMana();
        }
    }

    void OutOfMana()
    {
        Debug.Log(gameObject.name + " is out of mana.");
    }
    public void RestoreMana(int amount)
{
    currentMana = Mathf.Min(currentMana + amount, maxMana);
    Debug.Log("Mana ditambahkan: " + amount + ". Mana sekarang: " + currentMana);
}
}

