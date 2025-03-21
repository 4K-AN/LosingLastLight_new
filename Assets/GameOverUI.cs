using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // ✅ Pastikan waktu kembali normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ✅ Restart Level
    }

    public void MainMenu()
    {
        Time.timeScale = 1f; // ✅ Pastikan waktu kembali normal
        SceneManager.LoadScene("MainMenu"); // ✅ Ganti dengan nama scene menu utama kamu
    }
}
