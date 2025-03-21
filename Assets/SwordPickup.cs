using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan Player memiliki tag "Player"
        {
            Movement playerMovement = other.GetComponent<Movement>();
            if (playerMovement != null)
            {
                playerMovement.PickUpSword();
                Destroy(gameObject); // Hapus pedang setelah diambil
            }
        }
    }
}
