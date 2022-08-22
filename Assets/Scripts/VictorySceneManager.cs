using UnityEngine;

public class VictorySceneManager : MonoBehaviour
{
    public static VictorySceneManager Instance;
    
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