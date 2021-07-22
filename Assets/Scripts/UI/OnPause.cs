using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPause : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject pauseMenuUI;
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        IsGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        IsGamePaused = true;
    }

    public void LoadScene()
    {
        Debug.Log("main menu scene");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("quit application");
        Application.Quit();
    }


}
