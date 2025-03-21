using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Perjalanan"; // Nama scene tujuan

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Pastikan Player memiliki Tag "Player"
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
