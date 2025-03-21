using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private Animator anim;
    private Movement movementScript;

    void Start()
    {
        anim = GetComponent<Animator>();
        movementScript = GetComponent<Movement>();

        if (anim == null)
            Debug.LogError("Animator tidak ditemukan pada " + gameObject.name);
        if (movementScript == null)
            Debug.LogError("Script Movement tidak ditemukan pada " + gameObject.name);
    }

    void Update()
    {
        if (movementScript != null)
        {
            if (movementScript.isUsingSword)
            {
                if (Input.GetMouseButtonDown(0)) // Klik kiri
                {
                    Debug.Log("Menyerang dengan pedang!");
                    anim.SetTrigger("attackSword");
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Menyerang tanpa pedang!");
                    anim.SetTrigger("attack");
                }
            }
        }
    }
}
