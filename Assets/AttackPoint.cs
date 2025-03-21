using System.Collections;
using UnityEngine;

public class AttackPoint: MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int attackDamage = 20;
    public float attackRange = 0.5f;
    public float attackCooldown = 1f; // Delay serangan
    private bool canAttack = true;

    public Transform attackPoint; // Posisi serangan
    public LayerMask enemyLayer; // Layer musuh yang bisa diserang

    public AudioSource audioSource;
    public AudioClip attackSound;

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Ambil komponen Animator
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack) // Klik kiri mouse
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false; // Tidak bisa menyerang selama cooldown
        animator.SetTrigger("Attack"); // Memainkan animasi serangan

        // 🔊 Mainkan suara serangan
        if (audioSource != null && attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }

        // Deteksi musuh dalam jangkauan
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(attackCooldown); // Tunggu cooldown
        canAttack = true; // Bisa menyerang lagi
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
