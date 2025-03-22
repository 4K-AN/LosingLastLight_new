using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.1f;  
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene("Dungeon"); 
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Halaman Utama");
    }
}
