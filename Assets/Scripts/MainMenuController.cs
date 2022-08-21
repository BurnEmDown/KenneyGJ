using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;

    public GameObject storyBox;
    
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

    public void PlayGameButton()
    {
        GameManager.Instance.LoadGameScene();
    }

    public void StoryButton()
    {
        bool activate = !storyBox.activeInHierarchy;
        storyBox.SetActive(activate);
    }

    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
