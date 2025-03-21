using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<Image> itemSlots;  // Daftar slot UI untuk item
    private List<Sprite> collectedItems = new List<Sprite>();

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddItem(Sprite sprite)
    {
        if (collectedItems.Count < itemSlots.Count) // Pastikan ada slot kosong
        {
            collectedItems.Add(sprite);
            UpdateInventoryUI();
        }
        else
        {
            Debug.Log("Inventory penuh!");
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < collectedItems.Count)
            {
                itemSlots[i].sprite = collectedItems[i];
                itemSlots[i].gameObject.SetActive(true);
            }
            else
            {
                itemSlots[i].gameObject.SetActive(false);
            }
        }
    }
}
