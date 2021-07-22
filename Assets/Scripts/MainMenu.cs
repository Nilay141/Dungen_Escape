using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("you hit the start buttton");
        SceneManager.LoadScene("Game");
    }


    public void QuitButton()
    {
        Debug.Log("you hit the quit buttton");
        Application.Quit();
    }
}
