using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogUI; // UI dialog (Canvas Panel)
    public Text dialogText; // TMP atau Text biasa
    public Button nextButton; // Tombol "Lanjut"
    public GameObject door; // Drag GameObject pintu di Inspector
    private bool doorDestroyed = false; // Flag untuk mengecek apakah pintu sudah dihancurkan

    [TextArea(3, 10)]
    public string[] dialogLines; // Array teks dialog
    private int currentLine = 0;

    void Start()
    {
        dialogUI.SetActive(false); // Sembunyikan UI saat awal
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextDialog);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowDialog();
        }
    }

    void DestroyDoor()
    {
        if (!doorDestroyed && door != null) // Pastikan pintu masih ada sebelum dihancurkan
        {
            Destroy(door);
            doorDestroyed = true; // Tandai bahwa pintu sudah dihancurkan
            Debug.Log("Pintu telah dihancurkan!");
        }
    }

    void ShowDialog()
    {
        if (dialogLines.Length == 0)
        {
            Debug.LogError("Dialog NPC belum diisi!");
            return;
        }

        dialogUI.SetActive(true);
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
    }

    public void NextDialog()
    {
        currentLine++;

        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
        }
        else
        {
            dialogUI.SetActive(false); // Tutup dialog jika selesai
            DestroyDoor(); // Hancurkan pintu hanya jika belum dihancurkan sebelumnya
        }
    }
}
