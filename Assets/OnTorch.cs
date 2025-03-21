using UnityEngine;
using UnityEngine.Rendering.Universal; // Import untuk Light2D

public class OnTorch : MonoBehaviour
{
    public Light2D torchLight; // Komponen Light2D untuk obor

    private void Start()
    {
        torchLight.enabled = false; // Matikan cahaya saat awal permainan
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            torchLight.enabled = true; // Nyalakan cahaya saat Player menabrak
        }
    }
}
