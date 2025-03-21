using UnityEngine;

public class TorchController : MonoBehaviour
{
    [SerializeField] private int torchID;

    // Auto-referensi jika lupa di-set di Inspector
    private TorchPuzzleSystem puzzleSystem;
    private Collider2D col;

    void Start()
    {
        // Cari sistem puzzle otomatis
        puzzleSystem = FindObjectOfType<TorchPuzzleSystem>();
        col = GetComponent<Collider2D>();

        if (puzzleSystem == null)
        {
            Debug.LogError("TorchPuzzleSystem tidak ditemukan di scene!");
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (puzzleSystem.IsTorchActivated(torchID)) return;

        // Aktifkan obor dan nonaktifkan collider
        puzzleSystem.RegisterTorchActivation(torchID);
        col.enabled = false;
    }
}