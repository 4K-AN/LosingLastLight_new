using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class OnTorch : MonoBehaviour
{
    public Light2D torchLight; 

    private void Start()
    {
        torchLight.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            torchLight.enabled = true; 
        }
    }
}
