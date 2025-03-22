using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    [System.Serializable]
    public class DialogLine
    {
        public string speakerName; // Nama karakter
        [TextArea(3, 10)]
        public string text; // Isi dialog
    }

    public static NPCDialog activeDialog; // Dialog NPC yang sedang aktif

    public GameObject dialogUI; // UI Panel untuk dialog
    public Text nameText; // UI untuk nama karakter
    public Text dialogText; // UI untuk teks dialog
    public Button nextButton; // Tombol "Lanjut"
    public GameObject door; // Pintu yang bisa dihancurkan
    private bool doorDestroyed = false; // Flag apakah pintu sudah dihancurkan
    public DialogLine[] dialogLines; // Array dialog dengan karakter berbeda
    private int currentLine = 0;
    private bool isDialogActive = false;

    void Start()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextDialog);
        }

        // Pastikan UI tersembunyi saat awal
        if (dialogUI != null)
        {
            dialogUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDialogActive)
        {
            // Hanya tampilkan dialog jika tidak ada dialog lain yang sedang aktif
            if (activeDialog == null || !activeDialog.isDialogActive)
            {
                ShowDialog();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDialogActive && activeDialog == this)
        {
            // Opsional: Tutup dialog saat player meninggalkan area
            // CloseDialog();
        }
    }

    void DestroyDoor()
    {
        if (!doorDestroyed && door != null) // Cek apakah pintu masih ada
        {
            Destroy(door);
            doorDestroyed = true; // Tandai pintu sudah dihancurkan
            Debug.Log("🚪 Pintu telah dihancurkan!");
        }
    }

    void ShowDialog()
    {
        if (dialogLines.Length == 0)
        {
            Debug.LogError("⚠ Dialog NPC belum diisi!");
            return;
        }

        // Set dialog ini sebagai dialog yang aktif
        activeDialog = this;
        isDialogActive = true;

        // Aktifkan UI dialog
        dialogUI.SetActive(true);
        currentLine = 0;
        UpdateDialogUI();
    }

    void CloseDialog()
    {
        dialogUI.SetActive(false);
        isDialogActive = false;

        // Reset dialog aktif jika ini adalah dialog yang aktif
        if (activeDialog == this)
        {
            activeDialog = null;
        }
    }

    public void NextDialog()
    {
        // Hanya process jika ini adalah dialog yang aktif
        if (activeDialog != this) return;

        if (currentLine < dialogLines.Length - 1) // Masih ada dialog tersisa
        {
            currentLine++;
            UpdateDialogUI();
        }
        else
        {
            CloseDialog(); // Tutup dialog jika selesai
            DestroyDoor(); // Hancurkan pintu setelah dialog selesai
        }
    }

    void UpdateDialogUI()
    {
        nameText.text = dialogLines[currentLine].speakerName; // Set nama karakter
        dialogText.text = dialogLines[currentLine].text; // Set teks dialog
    }
}