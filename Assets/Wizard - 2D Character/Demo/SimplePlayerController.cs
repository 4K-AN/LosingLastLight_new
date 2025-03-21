using UnityEngine;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 15f; // Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;
        private bool alive = true;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Move();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }

        void Move()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);

            // Horizontal movement (A / D)
            if (Input.GetKey(KeyCode.A)) // Tombol A untuk kiri
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRun", true);
            }
            if (Input.GetKey(KeyCode.D)) // Tombol D untuk kanan
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRun", true);
            }

            // Vertical movement (W / S)
            if (Input.GetKey(KeyCode.W)) // Tombol W untuk atas
            {
                moveVelocity = Vector3.up;
                anim.SetBool("isRun", true);
            }
            if (Input.GetKey(KeyCode.S)) // Tombol S untuk bawah
            {
                moveVelocity = Vector3.down;
                anim.SetBool("isRun", true);
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }


        void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("attack");
            }
        }

        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("hurt");
                float forceDirection = direction == 1 ? -5f : 5f;
                rb.AddForce(new Vector2(forceDirection, 1f), ForceMode2D.Impulse);
            }
        }

        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }

        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}