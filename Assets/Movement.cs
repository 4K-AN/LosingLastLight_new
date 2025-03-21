using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveInput;
    private bool facingRight = true;

    public bool isUsingSword = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
      
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

       
        bool isMoving = moveInput != Vector2.zero;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isUsingSword", isUsingSword);

        

        
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
       
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }

    public void PickUpSword() 
    {
        isUsingSword = true;
    }
}
