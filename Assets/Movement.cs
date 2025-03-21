using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveInput;
    private bool facingRight = true;

    public bool isUsingSword = false; // Ubah ke public agar bisa diakses oleh script lain

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Input gerakan
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Cek apakah sedang bergerak
        bool isMoving = moveInput != Vector2.zero;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isUsingSword", isUsingSword);

        // Jika menabrak pedang (Collider akan diatur di script lain)
        // Tidak perlu tombol "E" untuk mengganti senjata

        // Cek arah gerakan dan balikkan karakter
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Gerakkan karakter dengan Rigidbody2D
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Balik arah
        transform.localScale = scale;
    }

    public void PickUpSword() // Fungsi ini akan dipanggil saat menabrak pedang
    {
        isUsingSword = true;
    }
}
