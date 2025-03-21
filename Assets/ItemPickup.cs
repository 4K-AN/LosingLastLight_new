using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.AddItem(itemSprite); // Tambahkan ke inventory
            Destroy(gameObject);
        }
    }
}
