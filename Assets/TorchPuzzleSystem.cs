using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class TorchPuzzleSystem : MonoBehaviour
{
    [System.Serializable]
    public class TorchData
    {
        public GameObject torchObject;
        public int torchID;
        public Light2D torchLight;
        [HideInInspector] public bool isActivated;
    }

    [Header("Settings")]
    [SerializeField] private List<TorchData> torches = new List<TorchData>();
    [SerializeField] private List<int> correctOrder = new List<int> { 1, 2, 3 };

    [Header("References")]
    [SerializeField] private List<GameObject> doors = new List<GameObject>();

    private List<int> activationOrder = new List<int>();

    void Start()
    {
        InitializeAllTorches();
    }

    void InitializeAllTorches()
    {
        foreach (var torch in torches)
        {
            if (torch.torchLight != null)
            {
                torch.torchLight.enabled = false;
                torch.isActivated = false;
            }
            else
            {
                Debug.LogError($"❌ Light2D belum di-assign untuk obor ID {torch.torchID}");
            }
        }
    }

    public void RegisterTorchActivation(int torchID)
    {
        if (activationOrder.Contains(torchID))
        {
            Debug.Log($"⚠ Obor {torchID} sudah dinyalakan, abaikan input.");
            return;
        }

        var targetTorch = torches.Find(t => t.torchID == torchID);
        if (targetTorch == null)
        {
            Debug.LogError($"❌ Obor dengan ID {torchID} tidak ditemukan!");
            return;
        }

        targetTorch.isActivated = true;
        if (targetTorch.torchLight != null)
        {
            targetTorch.torchLight.enabled = true;
            Debug.Log($"✅ Obor {torchID} dinyalakan.");
        }

        activationOrder.Add(torchID);
        Debug.Log($"🔢 Urutan saat ini: {string.Join(", ", activationOrder)}");

        CheckPuzzleProgress();
    }

    public bool IsTorchActivated(int torchID)
    {
        return torches.Exists(t => t.torchID == torchID && t.isActivated);
    }

    void CheckPuzzleProgress()
    {
        if (activationOrder.Count != correctOrder.Count) return;

        bool isCorrect = true;
        for (int i = 0; i < correctOrder.Count; i++)
        {
            if (activationOrder[i] != correctOrder[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            OpenDoors();
        }
        else
        {
            Debug.Log($"❌ Urutan salah! Reset... ({string.Join(", ", activationOrder)})");
            StartCoroutine(ResetPuzzle());
        }
    }

    void OpenDoors()
    {
        if (doors.Count == 0)
        {
            Debug.LogError($"❌ Tidak ada pintu yang di-assign!");
            return;
        }

        foreach (var door in doors)
        {
            if (door != null)
            {
                door.SetActive(false);
                Debug.Log($"🚪 Puzzle Solved! Pintu {door.name} terbuka.");
            }
            else
            {
                Debug.LogError("⚠ Ada pintu yang belum di-assign di list!");
            }
        }
    }

    IEnumerator ResetPuzzle()
    {
        Debug.Log("🔄 Puzzle gagal! Reset dalam 1 detik...");

        yield return new WaitForSeconds(1f); // Tunggu sebentar untuk efek visual

        // Matikan semua obor dan atur ulang statusnya
        foreach (var torch in torches)
        {
            torch.isActivated = false; // Penting: Set ulang status aktivasi
            if (torch.torchLight != null)
            {
                torch.torchLight.enabled = false;
            }
            Debug.Log($"⚠ Obor {torch.torchID} di-reset.");

            if (torch.torchObject != null)
            {
                Collider2D col = torch.torchObject.GetComponent<Collider2D>();
                if (col != null)
                {
                    col.enabled = true;
                }
            }
        }

        // Kosongkan urutan aktivasi
        activationOrder.Clear();

        Debug.Log("✅ Puzzle telah di-reset.");
    }
}
