using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public Sprite deadSprite; // Masukkan sprite mati di Inspector
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ambil komponen sprite
    }

    void Update()
    {
        Player player = GetComponent<Player>(); // Ambil script Player

        if (player != null && player.Health <= 0 && !isDead) // ✅ Gunakan player.Health

        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        spriteRenderer.sprite = deadSprite;
        Debug.Log("✅ Player mati! Sprite berubah menjadi: " + deadSprite.name);
    }

}
