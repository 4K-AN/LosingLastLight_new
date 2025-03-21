using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite; // Gambar item yang akan ditampilkan di layar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Jika Player menyentuh item
        {
            UIManager.instance.ShowItem(itemSprite); // Tampilkan item di UI
            Destroy(gameObject); // Hancurkan item setelah diambil
        }
    }
}
