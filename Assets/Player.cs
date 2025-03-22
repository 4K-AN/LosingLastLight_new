using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    public int damage = 15;
    public float moveSpeed = 5f;
    private int currentHealth; 
    private bool isDead = false;

   
    public int CurrentHealth => currentHealth;
    public int Health => currentHealth; 


    [Header("UI & Components")]
    public Image healthBar;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

   

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip attackSound;
    private Collider2D enemyTarget;

    [Header("Game Over")]
    public GameObject GameOverScreen;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false); 
        }
    }

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return; 

        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HitEffect());
        }
    }


    IEnumerator HitEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Attack()
    {
        if (enemyTarget != null)
        {
            Debug.Log("Menyerang musuh: " + enemyTarget.name);

            Enemy enemy = enemyTarget.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.LogError("Musuh tidak memiliki script Enemy.cs!");
            }

            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound);
            }
        }
        else
        {
            Debug.LogWarning("⚠ Tidak ada musuh dalam jangkauan serangan!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Musuh masuk jangkauan: " + collision.name);
            enemyTarget = collision;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Musuh keluar jangkauan: " + collision.name);
            enemyTarget = null;
        }
    }

    void Die()
    {
        if (isDead) return; 
        isDead = true;

        Debug.Log("Player mati! Menampilkan GameOverScreen...");
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("⚠ GameOverScreen masih NULL!");
        }

        Time.timeScale = 0.1f; 
        this.enabled = false; 

        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }

}
