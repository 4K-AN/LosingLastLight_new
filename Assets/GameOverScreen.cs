using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.1f;  // Jangan 0 agar UI masih responsif
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;  // Kembalikan ke normal
        SceneManager.LoadScene("Dungeon"); // Ganti dengan nama scene game
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Halaman Utama");
    }
}
