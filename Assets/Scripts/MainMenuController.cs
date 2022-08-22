using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;

    public GameObject storyBox;
    public GameObject explanationBox;
    public GameObject creditsBox;
    
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
        explanationBox.SetActive(false);
        creditsBox.SetActive(false);
    }

    public void ExplanationButton()
    {
        bool activate = !explanationBox.activeInHierarchy;
        explanationBox.SetActive(activate);
        storyBox.SetActive(false);
        creditsBox.SetActive(false);
    }

    public void CreditsButton()
    {
        bool activate = !creditsBox.activeInHierarchy;
        creditsBox.SetActive(activate);
        storyBox.SetActive(false);
        explanationBox.SetActive(false);
        
    }

    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
