using UnityEngine;

public class HealthManaItem : MonoBehaviour
{
    public int manaAmount = 20; // Jumlah mana yang dipulihkan

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Mana playerMana = collision.GetComponent<Mana>();

            if (playerMana != null)
            {
                playerMana.RestoreMana(manaAmount); // Tambah mana
            }
            else
            {
                Debug.LogError("⚠ Komponen Mana tidak ditemukan pada Player!");
            }

            Destroy(gameObject); // Hancurkan item setelah digunakan
        }
    }
}