using UnityEngine;
using UnityEngine.Rendering.Universal;
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
    [SerializeField] private GameObject door;

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
                Debug.LogError($"Light2D belum di-assign untuk obor ID {torch.torchID}");
            }
        }
    }

    public void RegisterTorchActivation(int torchID)
    {
        if (activationOrder.Contains(torchID)) return;

        var targetTorch = torches.Find(t => t.torchID == torchID);
        if (targetTorch == null)
        {
            Debug.LogError($"Obor dengan ID {torchID} tidak ditemukan!");
            return;
        }

        targetTorch.isActivated = true;
        targetTorch.torchLight.enabled = true;
        activationOrder.Add(torchID);

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

        if (isCorrect) OpenDoor();
        else ResetPuzzle();
    }

    void OpenDoor()
    {
        if (door != null) door.SetActive(false);
        Debug.Log("Puzzle Solved! Pintu terbuka");
    }

    void ResetPuzzle()
    {
        Debug.Log("Urutan salah! Reset...");

        foreach (var torch in torches)
        {
            torch.isActivated = false;
            if (torch.torchLight != null) torch.torchLight.enabled = false;
        }
        activationOrder.Clear();
    }
}