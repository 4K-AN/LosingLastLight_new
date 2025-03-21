using UnityEngine;

public class TorchController : MonoBehaviour
{
    [SerializeField] private int torchID;

   
    private TorchPuzzleSystem puzzleSystem;
    private Collider2D col;

    void Start()
    {
        
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

      
        puzzleSystem.RegisterTorchActivation(torchID);
        col.enabled = false;
    }
}