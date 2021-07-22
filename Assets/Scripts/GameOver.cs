using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void StartAgainButton()
    {
        Debug.Log("you hit the start again buttton");
        SceneManager.LoadScene("Game");
    }


    public void QuitButton()
    {
        Debug.Log("you hit the quit buttton");
        Application.Quit();
    }
}
