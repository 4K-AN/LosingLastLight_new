using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pastikan tidak ada spasi yang salah

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Pindah ke scene index 1
    }

    public void QuitGame()
    {
        Debug.Log("Game keluar!"); // Debugging untuk cek apakah tombol berfungsi
        Application.Quit(); // Keluar dari game

        // Jika sedang di Unity Editor, gunakan ini agar keluar dari play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
