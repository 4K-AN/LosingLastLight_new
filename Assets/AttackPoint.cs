using System.Collections;
using UnityEngine;

public class AttackPoint: MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int attackDamage = 20;
    public float attackRange = 0.5f;
    public float attackCooldown = 1f; 
    private bool canAttack = true;

    public Transform attackPoint; 
    public LayerMask enemyLayer; 

    public AudioSource audioSource;
    public AudioClip attackSound;

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack) 
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false; 
        animator.SetTrigger("Attack");

       
        if (audioSource != null && attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }

  
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; 
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
