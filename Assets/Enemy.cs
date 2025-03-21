using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float chaseRadius = 5f;
    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 10;
    public Image healthBar;
    public float knockbackForce = 5f;
    public float attackCooldown = 1.5f;
    private float nextAttackTime = 0f;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("GameObject Player tidak ditemukan! Periksa apakah sudah ada di scene.");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) < chaseRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(name + " menerima damage: " + amount);

        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log(name + " mati!");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(HitEffect());
            Knockback();
        }
    }


    IEnumerator HitEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    void Knockback()
    {
        if (rb != null && player != null)
        {
            Vector2 knockbackDirection = (transform.position - player.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            Player playerComponent = collision.gameObject.GetComponent<Player>();
            if (playerComponent != null)
            {
                playerComponent.TakeDamage(damage);
                nextAttackTime = Time.time + attackCooldown;
            }
            else
            {
                Debug.LogError("Player tidak memiliki script Player.cs! Pastikan sudah ditambahkan.");
            }
        }
    }
}
