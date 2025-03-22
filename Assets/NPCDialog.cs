using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    [System.Serializable]
    public class DialogLine
    {
        public string speakerName; 
        [TextArea(3, 10)]
        public string text; 
    }

    public static NPCDialog activeDialog; 

    public GameObject dialogUI;
    public Text nameText; 
    public Text dialogText; 
    public Button nextButton; 
    public GameObject door; 
    private bool doorDestroyed = false; 
    public DialogLine[] dialogLines; 
    private int currentLine = 0;
    private bool isDialogActive = false;

    void Start()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextDialog);
        }

        
        if (dialogUI != null)
        {
            dialogUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDialogActive)
        {
           
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
            
            
        }
    }

    void DestroyDoor()
    {
        if (!doorDestroyed && door != null) 
        {
            Destroy(door);
            doorDestroyed = true; 
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