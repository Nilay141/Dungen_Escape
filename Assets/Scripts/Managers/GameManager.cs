using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager n_instance;
    public static GameManager Instance
    {
        get
        {
            if(n_instance == null)
            {
                Debug.LogError("GameManage is null;");
            }
            return n_instance;
        }
    }

    public bool HasKeyTocastle { get; set; }
    public bool HasBootsofFlight { get; set; }
    public bool HasFlameSword { get; set; }

    public Player n_player { get; private set; }
    //private Player player;
    private void Awake()
    {
        n_instance = this;
        n_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
