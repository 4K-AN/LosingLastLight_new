using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject gameOverUI; // Drag panel game over ke sini di Inspector
    public void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Aktifkan UI Game Over
    }
    public void RestartButton()
    {
        // Buat manggil scene "Game" ketika button di pencet
        SceneManager.LoadScene("Game"); // Ganti nama scene setelah tutorialnya ke "Game"
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Game"); // sama kaya yang diatas cuma ini buat ke main menu
        // jangan lupa juga ganti nama scene nya ke main menu
    }
}
