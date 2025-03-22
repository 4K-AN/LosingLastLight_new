using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public Sprite deadSprite; 
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        Player player = GetComponent<Player>(); 

        if (player != null && player.Health <= 0 && !isDead) 

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
