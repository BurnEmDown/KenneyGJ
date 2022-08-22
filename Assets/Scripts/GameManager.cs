using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
