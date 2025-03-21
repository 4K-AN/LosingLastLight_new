using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 15;
    public float moveSpeed = 5f;

    [Header("UI & Components")]
    public Image healthBar;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip attackSound;

    private Collider2D enemyTarget;  // Menyimpan musuh yang bisa diserang

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        Move();

        // 🗡️ Menyerang musuh saat menekan tombol "Fire1" (Default: Mouse Kiri / Ctrl)
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
        Debug.Log("Player terkena hit! Mengurangi HP sebesar: " + amount);
        currentHealth -= amount;
        UpdateHealthBar();

        if (audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Player mati!");
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

    // 🗡️ **Menyerang musuh**
    void Attack()
    {
        if (enemyTarget != null)
        {
            Debug.Log("Menyerang musuh!");

            // Pastikan musuh punya script Enemy.cs dengan fungsi TakeDamage()
            enemyTarget.GetComponent<Enemy>().TakeDamage(damage);

            // 🔊 Mainkan suara serangan jika ada
            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound);
            }
        }
        else
        {
            Debug.Log("Tidak ada musuh dalam jangkauan!");
        }
    }

    // 🎯 **Mendeteksi musuh dalam jangkauan serangan**
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyTarget = collision;  // Simpan referensi musuh
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyTarget = null;  // Hapus referensi musuh saat keluar jangkauan
        }
    }
}
