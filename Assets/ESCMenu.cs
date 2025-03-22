using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    public GameObject settingsMenu; // Assign GUI Settings Menu di Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC ditekan!"); // Cek apakah ESC terdeteksi
            ToggleMenu();
        }
    }


    void ToggleMenu()
    {
        isPaused = !isPaused;
        settingsMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
