using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public TextMeshProUGUI textString;
    public Character playerCharacter; 
    private Character enemyTarget; 

    private SpriteRenderer spriteRender;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        spriteRender = rb.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
       
        movementInput.x = Input.GetAxisRaw("Horizontal");
        if(movementInput.x > 0)
        {
            spriteRender.flipX = false;
        } if(movementInput.x < 0)
        {
            spriteRender.flipX = true;
        }
        movementInput.y = Input.GetAxisRaw("Vertical");
        inputHandling();
    }

    void FixedUpdate()
    {
       
        rb.linearVelocity = movementInput.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("b-atas"))
        {
            textString.text = "Batas atas";
        }
         if(other.gameObject.CompareTag("b-bawah"))
        {
            textString.text = "Batas Bawah";

        }
         if(other.gameObject.CompareTag("b-kiri"))
        {
            textString.text = "Batas Kiri";
        }
         if(other.gameObject.CompareTag("b-kanan"))
        {
            textString.text = "Batas Kanan";
        }
    }
    void inputHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyTarget.healthCharacter -= playerCharacter.attackPower; 
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
                enemyTarget = collision.GetComponent<Character>();
        }
    }
}
