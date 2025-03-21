using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image itemDisplay; // Referensi ke UI Image di Canvas

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ShowItem(Sprite sprite)
    {
        itemDisplay.sprite = sprite; // Ubah gambar UI sesuai item yang diambil
        itemDisplay.gameObject.SetActive(true); // Tampilkan gambar item
    }
}
