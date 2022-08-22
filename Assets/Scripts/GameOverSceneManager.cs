using UnityEngine;

public class GameOverSceneManager : MonoBehaviour
{
    public static GameOverSceneManager Instance;
    
    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GoBackToMainMenu()
    {
        GameManager.Instance.LoadMainMenuScene();
    }
}
